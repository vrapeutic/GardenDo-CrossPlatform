using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SocketIO;
using System;
using System.Collections;
using SimpleTCP;

namespace Tachyon
{
    public class NetworkManager : MonoBehaviour
    {
        #region Serializable Fields
        public string nextSceneName;
        [SerializeField] string lobbySceneName;
        [SerializeField] string moduleName = "ModuleName";
        static bool isStandalone;
        #endregion
     
        #region Private Members
        private VRClient client;
        private string serverUrl = "ws://1.1.1.1:3000/SocketIOComponent.instance.io/?EIO=4&transport=webSocketIOComponent.instance";
        private static JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
        private bool isConnected = false;
        private string androidURL = "";
        private bool gotServerUrl = false;
        #endregion

        #region Public Members
        public static NetworkManager instance = null;
        #endregion

        #region Public Functions

        public static void SetStandaloneValue(bool value)
        {
            isStandalone = value;
        }

        public static void InvokeServerMethod(string functionName, string gameObjectName, params object[] parameters)
        {
            jsonObject.SetField("functionName", functionName);
            jsonObject.SetField("gameObjectName", gameObjectName);
            AddMethodParametersToJSON(parameters);

            try
            {
                if (!isStandalone)
                    SocketIOComponent.instance.Emit(functionName, jsonObject);
                else
                    LocalEventManager.InvokeLocalEvent(functionName, jsonObject);
            }
            catch (NullReferenceException ex)
            {
                LocalEventManager.InvokeLocalEvent(functionName, jsonObject);
            }
            catch (Exception e)
            {
                LocalEventManager.InvokeLocalEvent(functionName, jsonObject);
                Debug.Log(e);
            }

            RemoveMethodParametersFromJSON(parameters);
        }

        public static void InvokeClientMethod(string functionName, InvokationManager invokationManager)
        {
            try
            {
                if (!isStandalone)
                {
                    jsonObject.SetField("functionName", functionName);
                    SocketIOComponent.instance.Emit("registerFunction", jsonObject);

                    SocketIOComponent.instance.On(functionName, invokationManager.InvokeFunction);
                }
                else
                {
                    LocalEventManager.On(functionName, invokationManager.InvokeFunction);
                }
            }
            catch (NullReferenceException ex)
            {
                LocalEventManager.On(functionName, invokationManager.InvokeFunction);
            }
            catch (Exception e)
            {
                LocalEventManager.On(functionName, invokationManager.InvokeFunction);
                Debug.Log(e);
            }
        }
        #endregion

        #region Private Functions
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }

        void Start()
        {
            OnStart();
        }

        private void OnDestroy()
        {
            //instance.OnStart();
        }

        void OnStart()
        {
#if UNITY_ANDROID
            StartCoroutine(InitTCPServer());
            StartCoroutine(InitializeConnectionToServer());
            StartCoroutine(InitializeListeners());
#endif

#if UNITY_STANDALONE
            string url = "ws://127.0.0.1:3000/socket.io/?EIO=4&transport=websocket";
            ConnectToServer(url);
            StartCoroutine(InitializeListeners());
#endif      
        }
#if UNITY_ANDROID
        private SimpleTcpServer server;
        IEnumerator InitTCPServer()
        {
            yield return new WaitForSeconds(0.1f);
            // if IP is in PlayerPref
            //   then serverUrl = PlayerPref['url']
            //        ConnectToServer
            // else
            //   then open the TCP server normally/*
            /*  AndroidJavaObject jo = new AndroidJavaObject("android.os.Build");
              string serial = jo.GetStatic<string>("SERIAL");*/
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
            AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
            string AndroidIdLowerCase = secure.CallStatic<string>("getString", contentResolver, "android_id");
            string Android_ID = AndroidIdLowerCase.ToUpper();
            Debug.Log(Android_ID);
            server = new SimpleTcpServer().Start(8910);
            Debug.Log("INIT TCP @ PORT 8910");
            server.DataReceived += (sender, msg) =>
            {
                //msg.Reply("Content-Type: text/plain\n\nHello from my web server!");
                //Debug.Log(msg.MessageString);
                //string[] words = msg.MessageString.Split(' ');
               
                if (msg.MessageString.Contains("requestInfo"))
                {
                    //Debug.Log(msg.MessageString);
                    //Debug.Log("Did not receive 'requestInfo' msg");
                    msg.Reply("headsetSerial " + Android_ID + " headsetModuleName " + PusherManager.instance.OrgPackageName);
                }
                if (msg.MessageString.Contains("IP"))
                {
                    string[] splitText = msg.MessageString.Split(' ');
                    string ip = splitText[1];
                    string url = "ws://" + ip + ":3000/socket.io/?EIO=4&transport=websocket";
                    this.serverUrl = url;
                    this.gotServerUrl = true;
                    //Debug.Log(ip);
                    //Debug.Log("connecting to server: " + url);
                    msg.Reply("gotServerUrl");
                }
                else
                {
                    //Debug.Log("Did not receive IP msg");
                }
            };
        }

        private IEnumerator InitializeConnectionToServer()
        {
            while (gotServerUrl == false)
            {
                yield return new WaitForSeconds(0.5f);
            }
            //
            // must be added when Hossam modifies the desktop app so that the client TCP server
            // script is being run only once when the user presses Play button
            //
            //**//
            if (isConnected == false)
            {
                Debug.Log("I got server URL, I'm gonna connect!");
                ConnectToServer(serverUrl);
            }
            else
            {
                Debug.Log("SocketIOComponent.instance.IsConnected = true");
            }
            //server.Stop();
            //Debug.Log("Server is stopped");
        }
#endif


        private IEnumerator InitializeListeners()
        {
            while (isConnected == false)
            {
                yield return new WaitForSeconds(0.5f);
            }
            #region Listeners
            SocketIOComponent.instance.On("register", OnRegister);
            SocketIOComponent.instance.On("requestModuleName", OnRequestModuleName);
            SocketIOComponent.instance.On("requestClientType", OnRequestClientType);
            SocketIOComponent.instance.On("clientDisconnected", OnClientDisconnected);
            SocketIOComponent.instance.On("connectionRejected", OnConnectionRejected);
            SocketIOComponent.instance.On("roomReady", OnRoomReady);
            #endregion
        }

        private void ConnectToServer(string url)
        {
            SocketIOComponent.instance.autoConnect = true;
            SocketIOComponent.instance.url = url;
            Debug.Log(url);
            SocketIOComponent.instance.Awake();
            SocketIOComponent.instance.Connect();
            isConnected = true;
            // Once connected -> delete serverUrl from PlayerPref
            Debug.Log("connected " + url);
        }

        private static void AddMethodParametersToJSON(object[] parameters = null)
        {
            for (int i = 0; parameters != null && i < parameters.Length; i++)
            {
                string fieldName = "param" + i.ToString();
                Type objType = parameters[i].GetType();
                if (objType == typeof(int))
                {
                    jsonObject.SetField(fieldName, (int)parameters[i]);
                }
                else if (objType == typeof(float))
                {
                    jsonObject.SetField(fieldName, (float)parameters[i]);
                }
                else if (objType == typeof(string))
                {
                    jsonObject.SetField(fieldName, (string)parameters[i]);
                }
                else if (objType == typeof(bool))
                {
                    jsonObject.SetField(fieldName, (bool)parameters[i]);
                }
            }
        }

        private static void RemoveMethodParametersFromJSON(object[] parameters = null)
        {
            for (int i = 0; parameters != null && i < parameters.Length; i++)
            {
                string fieldName = "param" + i.ToString();
                jsonObject.RemoveField(fieldName);
            }
        }

        private void OnRegister(SocketIOEvent e)
        {
            string clientId = e.data["id"].str;
            client = new VRClient(clientId);

#if UNITY_ANDROID
            client.setClientType(ClientType.Headset);
            client.setModuleName(moduleName);
#endif

#if UNITY_STANDALONE
            client.setClientType(ClientType.Desktop);
            client.setModuleName(moduleName);
#endif
        }

        private void OnRequestClientType(SocketIOEvent e)
        {
            jsonObject.SetField("clientType", client.getClientType().ToString());
            SocketIOComponent.instance.Emit("updateClientType", jsonObject);
        }

        private void OnRequestModuleName(SocketIOEvent e)
        {
            jsonObject.SetField("moduleName", client.getModuleName());
            SocketIOComponent.instance.Emit("updateModuleName", jsonObject);
        }

        public void OnClientDisconnected(SocketIOEvent e)
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif

#if UNITY_ANDROID
            Debug.Log("Loading " + lobbySceneName);
            SceneManager.LoadSceneAsync(lobbySceneName);
            SocketIOComponent.instance.Close();
#endif
        }

        private void OnConnectionRejected(SocketIOEvent e)
        {
            Debug.Log("Connection Rejected");
            SocketIOComponent.instance.Close();
        }

        private void OnRoomReady(SocketIOEvent e)
        {
            Debug.Log("Room is ready");
            SceneManager.LoadSceneAsync(nextSceneName);
        }
        #endregion

        public void DisconnectToServer()
        {
            Debug.Log("Disconnect tor server");
            SocketIOComponent.instance.Close();
            Destroy(this.gameObject);
        }

        private void OnApplicationQuit()
        {
            DisconnectToServer();
        }

    }
}