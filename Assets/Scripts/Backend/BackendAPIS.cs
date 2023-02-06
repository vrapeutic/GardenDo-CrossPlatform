using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackendAPIS : MonoBehaviour
{
    SessionElements getSessionData;
    DataCollection currentData;
    SessionStats CurrentStats;
    CreateSession sessionElements;

    
    #region CreateSession
    public IEnumerator SendSessionElements(string patient_id,int vr_module_id, string auth)
    {
        string json = ConvertElementsTojson(patient_id, vr_module_id);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        string url = "http://vrapeutic-rails-production.eba-2nd4efne.eu-west-1.elasticbeanstalk.com/api/v1/module_sessions/create_without_headset/";
        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        Debug.Log("StartSession :" + json);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer "+auth);
        yield return www.SendWebRequest();
        sessionElements = JsonUtility.FromJson<CreateSession>(www.downloadHandler.text);
        Debug.Log(sessionElements);
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else if (www.downloadHandler.text != null)
        {
            Debug.Log("all" + www.downloadHandler.text);
        }
    }
    string ConvertElementsTojson(string patient_id, int vr_module_id)
    {
        SessionElements elements = new SessionElements();
        elements.patient_id = patient_id;
        elements.vr_module_id = vr_module_id;
        return JsonUtility.ToJson(elements);
    }
    public CreateSession SessioResponseElements()
    {
        return sessionElements;
    }
    #endregion  
    #region setStats
    public DataCollection SetStats(DataCollection _currentData)
    {
        return currentData = _currentData;
    }
    #endregion
    #region SendStats
   public IEnumerator SendSessionData(string auth)
    {
        string json = ConvertDataToJson( );
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        string url = "http://vrapeutic-rails-production.eba-2nd4efne.eu-west-1.elasticbeanstalk.com/api/v1/statistics/create_without_headset";
        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        Debug.Log("SendjsonIEnum :" + json);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer " + auth);
        yield return www.SendWebRequest();
        CurrentStats = JsonUtility.FromJson<SessionStats>(www.downloadHandler.text);
        Debug.Log("Send request Resonce code: " + www.responseCode);
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else if (www.downloadHandler.text != null)
        {

            Debug.Log("all" + www.downloadHandler.text);
        }

    }
    string ConvertDataToJson()

    {
        SessionStats statsVariables = new SessionStats();
        statsVariables.room_id = sessionElements.room_id;
        statsVariables.data.session_start_time = sessionElements.session_date;
        statsVariables.data.attempt_start_time = currentData.session_start_time;
        statsVariables.data.attempt_end_time =currentData.attempt_end_time;
        statsVariables.data.expected_duration_in_seconds = currentData.expected_duration_in_seconds;
        statsVariables.data.actual_duration_in_seconds = currentData.actual_duration_in_seconds;
        statsVariables.data.level = currentData.level;
        statsVariables.data.attempt_type = currentData.attempt_type;
        statsVariables.data.flower_sustained = currentData.flowerSustained;
        statsVariables.data.well_sustained = currentData.wellSustained;
        statsVariables.data.total_sustained = currentData.totalSustained;
        statsVariables.data.non_sustained = currentData.nonSustained;
        statsVariables.data.impulsivity_score = currentData.impulsivity_score;
        statsVariables.data.response_time = currentData.response_time;
        statsVariables.data.omission_score = currentData.omission_score;
        statsVariables.data.distractibility_score = currentData.distractibility_score;
        statsVariables.data.actual_attention_time = currentData.actual_attention_time;
        statsVariables.data.distraction_endurance_score = currentData.des;
        statsVariables.data.score = currentData.score;
        statsVariables.data.flowr_position = currentData.flowr_position;
        statsVariables.data.flower_heights = currentData.flower_heights;
        statsVariables.data.flower_max_height = currentData.flower_max_height;
        statsVariables.data.flower_min_height = currentData.flower_min_height;
        statsVariables.data.flower_average_height = currentData.flower_average_height;
        statsVariables.data.flower_count = currentData.flower_count;
        return JsonUtility.ToJson(statsVariables);
    }
    public SessionStats SendStatsResponse()
    {
        return CurrentStats;
    }
    #endregion
    #region GetSesstionStats
  /*  public IEnumerator GetSessionData(int vr_module_id, int patient_id)
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Get("https://dashboard.myvrapeutic.com/api/v1/statistics/?patient_id=" + patient_id.ToString() + "&" + "vr_module_id=" + patient_id.ToString());
        //   www.chunkedTransfer = false;
        yield return www.Send();
        Debug.Log("https://dashboard.myvrapeutic.com/api/v1/module_sessions/find_room?headset=" + patient_id.ToString() + "&" + "vr_module_id=" + vr_module_id.ToString());
        statsData = JsonUtility.FromJson<GetStatsData>(www.downloadHandler.text);
        Debug.Log(statsData);
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else if (www.downloadHandler.text != null)
        {

            Debug.Log("all" + www.downloadHandler.text);
        }

    }
    public GetStatsData SessionDataResponse()
    {
        return statsData;
    }*/
    #endregion
}
