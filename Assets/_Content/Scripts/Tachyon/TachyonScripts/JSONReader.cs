using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

namespace Tachyon
{
    class JSONReader : MonoBehaviour
    {
        public string ip = "";
        public static JSONReader instance = null;

        private void Awake()
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

        private void Start()
        {
#if UNITY_ANDROID
            Debug.Log("starting coroutine...");
            StartCoroutine(GetIPFromFile());
#endif
        }

        public IEnumerator GetIPFromFile()
        {
            string temp = (Application.persistentDataPath.Replace("Android", "")).Split(new string[] { "//" }, System.StringSplitOptions.None)[0] + "/Download";
            string filePath = string.Format("file:///{0}/{1}", temp, "ip.json");

            Debug.Log("file path: " + filePath);

            yield return StartCoroutine(DeserializeData(filePath));

            Debug.Log("IP is: " + ip + " ip string size: " + ip.Length);
        }

        public IEnumerator DeserializeData(string filePath)
        {
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            www.chunkedTransfer = false;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("www.isNetworkError " + www.isNetworkError);
                Debug.Log("www.isHttpError " + www.isHttpError);
                Debug.Log("www.error");
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                ip = FetchIP(jsonText);
                Debug.Log("Got ip!! " + ip);
            }
        }

        public string FetchIP(string jsonData)
        {
            return JsonUtility.FromJson<JSONFile>(jsonData).ip;
        }

        public string getIP()
        {
            return ip;
        }
    }


    [Serializable]
    public class JSONFile
    {
        public string ip;
    }
}
