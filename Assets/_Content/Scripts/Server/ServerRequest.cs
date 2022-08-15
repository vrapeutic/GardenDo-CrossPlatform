using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
using UnityEngine.SceneManagement;

public class ServerRequest : MonoBehaviour
{
    public static ServerRequest instance;
    JsonAPIS jsonAPIS = new JsonAPIS();
    GetRoomIDJson getRoomIDInstance;
    StatisticsJsonFile statisticsInstance;
    Data itemsInstance;
    PutRequstJson requstJson;
    public int moduleID = 8;//every module has unique id
    public static int id;
    public static string roomId;
    public static string headset = "";
    [HideInInspector]
    public string startTime = "yyyy/MM/dd hh:mm:ss tt"; // use System.DateTime.Now(start time) when level start to getstart time
    [HideInInspector]
    public string endTime = "yyyy/MM/dd hh:mm:ss tt"; //use System.DateTime.Now(end time) when level end to get end time
    float score = 10;//this  is just example it can be anything 
    static bool quit;
    static bool save = false;

    // public  string json;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
        Session.EndSession();

        quit = false;
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("GetSerialRpc", invokationManager);
        NetworkManager.InvokeClientMethod("GetRpc", invokationManager);
        NetworkManager.InvokeClientMethod("OnExit", invokationManager);
        // GetSerialRpc(headset);
#if UNITY_ANDROID
        GetHeadsetSerial();
#endif
    }
    void Start()
    {
        startTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");

#if UNITY_ANDROID

        StartCoroutine(Get(moduleID, headset));

        NetworkManager.InvokeServerMethod("GetSerialRpc", this.gameObject.name, headset);
#endif
        Invoke("LoadMainMenu", 3); //here you load next scene after 3 seconds 
        Debug.Log(headset + "headset");

    }
    public void LoadMainMenu()
    {

        if (roomId != null)
        {
            Debug.Log(headset + "headset");
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("room id is null");
            SceneManager.LoadScene(0);
        }


    }
    public void GetHeadsetSerial()
    {
        //getting serial number of hedset
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
        string AndroidIdLowerCase = secure.CallStatic<string>("getString", contentResolver, "android_id");
        string Android_ID = AndroidIdLowerCase.ToUpper();
        headset = Android_ID;
        Debug.Log(headset);
#if UNITY_ANDROID
        NetworkManager.InvokeServerMethod("GetSerialRpc", this.gameObject.name, headset);
#endif
        /*
        */
    }
    public void GetSerialRpc(string serial)
    {
        Debug.Log("INfn");
        headset = serial;
        PlayerPrefs.SetString("serial", serial);
        PlayerPrefs.Save();
        headset = PlayerPrefs.GetString("serial");
        Debug.Log(headset + " headset serial");
    }
    IEnumerator Get(int moduleId, string serial)
    {
        yield return StartCoroutine(jsonAPIS.GetRequestJson(moduleId, serial));
        getRoomIDInstance = jsonAPIS.ReturnGetRoomID();
        Session.StartSession(getRoomIDInstance);
#if UNITY_ANDROID
        NetworkManager.InvokeServerMethod("GetRpc", this.gameObject.name, Session.GetData().id, Session.GetData().room_id);//or Use getRoomIDInstance.id,getRoomIDInstance.room_id
#endif
    }
    public void GetRpc(int getId, string getRoom)
    {
        id = getId;
        roomId = getRoom;
    }
    public void SendPostRequest(string headset, string roomid, string sessionStartTime, string attemptStartTime, string attemptEndTime, string attemptType, float expectedDurationInSeconds, string Level, float flowerSustained, float wellSustained, float totalSustained, float nonSustained, float actualDurationInSeconds, float actualAttentionTime, float score, float implusivityScore, float responseTime, float omissionScore, float DES,string flowr_position, string flower_heights)
    {
        StartCoroutine(Post(headset, roomid, startTime, attemptStartTime, attemptEndTime, attemptType, expectedDurationInSeconds, Level, flowerSustained, wellSustained, totalSustained, nonSustained, actualDurationInSeconds, actualAttentionTime, score, implusivityScore, responseTime, omissionScore, DES, flowr_position,flower_heights));
    }
    public IEnumerator Post(string headset, string roomid, string sessionStartTime, string attemptStartTime, string attemptEndTime, string attemptType, float expectedDurationInSeconds, string Level, float flowerSustained, float wellSustained, float totalSustained, float nonSustained, float actualDurationInSeconds, float actualAttentionTime, float score, float implusivityScore, float responseTime, float omissionScore, float DES,string flowr_position,string flower_heights)
    {
        yield return StartCoroutine(jsonAPIS.PostJsonItems(headset, roomid, sessionStartTime, attemptStartTime, attemptEndTime, attemptType, expectedDurationInSeconds, Level, flowerSustained, wellSustained, totalSustained, nonSustained, actualDurationInSeconds, actualAttentionTime, score, implusivityScore, responseTime, omissionScore, DES,flowr_position,flower_heights));
        statisticsInstance = jsonAPIS.ReturnSendStatistics();
        Session.SetStats(statisticsInstance);
    }
    public void SendPutRequest()
    {
        StartCoroutine(Put(id, System.DateTime.Now.ToString(endTime), headset));
    }
    IEnumerator Put(int id, string endedAt, string serial)
    {
        Debug.Log("exit");
        if (save == false)
        {
            yield return StartCoroutine(jsonAPIS.SendPutRequest(id, endedAt, serial));
            requstJson = jsonAPIS.ReturnPutRequstJson();
            Session.SetPut(requstJson);
            save = true;
            Invoke("Exit", 1.5f);
            Debug.Log("put" + headset + id + System.DateTime.Now.ToString(endTime));
        }
    }
    private void OnApplicationQuit()
    {
        if (quit == false)
        {

            OnExit();

            Application.CancelQuit();
        }
        if (quit == true)
            Application.Quit();
    }
#if UNITY_ANDROID
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            //  ExitRpc();

        }
    }
#endif

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            //            ExitRpc();
        }

    }
    //public void OnDestroy()
    //{
    //    if (quit != true)

    //        ExitRpc();
    //}
    public void ExitRpc()
    {
        NetworkManager.InvokeServerMethod("OnExit", this.gameObject.name);
    }
    public void OnExit()
    {
        Debug.Log("putExit" + headset);
        SendPutRequest();

    }
    public void Exit()
    {
        Session.EndSession();
        save = true;
        //  Destroy(this);
        Debug.Log("quit");
        quit = true;
        Application.Quit();

    }

}
