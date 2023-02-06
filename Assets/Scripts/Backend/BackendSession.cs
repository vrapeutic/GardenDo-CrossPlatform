using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackendSession : MonoBehaviour
{
    public BackendSession[] instance;
    BackendAPIS jsonAPIS = new BackendAPIS();
    SessionStats CurrentStats;
    CreateSession sessionElements;
    public DataCollection MyStats;
    int sessionId;
    public int moduleID = 13;//every module has unique id
    public  string patient_id;
    public string auth="";
    [SerializeField]
    InputField input;
    [HideInInspector]
    public  string currentRoomId;
    public static string startTimeSession = "yyyy/MM/dd hh:mm:ss tt"; // use System.DateTime.Now(start time) when level start to getstart time
    [HideInInspector]
    public string endTimeNow = "yyyy/MM/dd hh:mm:ss tt"; //use System.DateTime.Now(end time) when level end to get end time
    [SerializeField]
    private GameObject pop_up;

    private void Awake()
    {

        instance = FindObjectsOfType<BackendSession>();
        if (instance.Length > 1)
            Destroy(instance[0].gameObject);
        DontDestroyOnLoad(this.gameObject);

    }
    public void SetPatient()
    {
       patient_id = input.text;

    }
    public string GetPatient()
    {
        return patient_id;
    }
  
    void Start()
    {
        startTimeSession = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");

    }
    #region SessionStart
   public void StartSession()
    {
        //if (patient_id >= 100 && patient_id <= 115)

            StartCoroutine(SendSessionElements(patient_id, moduleID, auth));
        //else StartCoroutine(PopUp());
        
    }
   IEnumerator PopUp()
    {
        pop_up.SetActive(true);
        yield return new WaitForSeconds(2);
        pop_up.SetActive(false);

    }
    IEnumerator SendSessionElements(string patient_id , int moduleId,string auth)
    {
        yield return StartCoroutine(jsonAPIS.SendSessionElements(patient_id, moduleID,auth));
        sessionElements = jsonAPIS.SessioResponseElements();
            SartGame(sessionElements.id, sessionElements.room_id);
    }
    public void SartGame(int getId, string getRoom)
    {
        sessionId = getId;
        currentRoomId = getRoom;
        if (currentRoomId != null && SceneManager.GetActiveScene().name == "Session")
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//Load nextScene    

    }
    #endregion
    #region SendSessionData
    public void SendStatsData()
    {
        jsonAPIS.SetStats(MyStats);

        StartCoroutine(SendStats());
    }
    public IEnumerator SendStats()
    {
        yield return StartCoroutine(jsonAPIS.SendSessionData( auth));
        CurrentStats = jsonAPIS.SendStatsResponse();
    }
    #endregion
    #region GetStatsData
    /*  public void GetSTatsData()
      {
          StartCoroutine(GetStats(moduleID, patient_id));
      }
      IEnumerator GetStats(int VR_id, int patient_id)
      {
          Debug.Log("exit");
          if (save == false)
          {
              yield return StartCoroutine(jsonAPIS.GetSessionData(VR_id, patient_id));
              statsData = jsonAPIS.SessionDataResponse();
              save = true;
              Invoke("Exit",3f);
              Debug.Log("put");
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


      public void OnExit()
      {
          SendPutRequest();

      }*/
    #endregion
    #region Exit
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();

    }
    #endregion
}
