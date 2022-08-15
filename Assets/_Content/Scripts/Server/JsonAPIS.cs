using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonAPIS : MonoBehaviour
{
    GetRoomIDJson iDJsonInstance;
    Data itemsInstance;
    StatisticsJsonFile statisticsInstance;
    PutRequstJson putRequstJsonInstance;
    #region GetRequest
    public IEnumerator GetRequestJson(int id, string serial)
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Get("https://dashboard.myvrapeutic.com/api/v1/module_sessions/find_room?headset=" + serial + "&" + "vr_module_id=" + id.ToString());
        //   www.chunkedTransfer = false;
        yield return www.Send();
        Debug.Log("https://dashboard.myvrapeutic.com/api/v1/module_sessions/find_room?headset=" + serial + "&" + "vr_module_id=" + id.ToString());
        iDJsonInstance = JsonUtility.FromJson<GetRoomIDJson>(www.downloadHandler.text);
        Debug.Log(iDJsonInstance);
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else if (www.downloadHandler.text != null)
        {

            Debug.Log("all" + www.downloadHandler.text);
        }

    }
    public GetRoomIDJson ReturnGetRoomID()
    {
        return iDJsonInstance;
    }
    #endregion
    #region PostRequest
    public IEnumerator PostJsonItems(string headset, string roomid, string sessionStartTime, string attemptStartTime, string attemptEndTime, string attemptType, float expectedDurationInSeconds, string Level, float flowerSustained, float wellSustained, float totalSustained, float nonSustained, float actualDurationInSeconds, float actualAttensionTime, float score, float implusivityScore, float responseTime, float omissionScore, float DS,string flowr_position,string flower_heights)
    {
        string json = ConvertPostToJson(headset, roomid, sessionStartTime, attemptStartTime, attemptEndTime, attemptType, expectedDurationInSeconds, Level, flowerSustained, wellSustained, totalSustained, nonSustained, actualDurationInSeconds, actualAttensionTime, score, implusivityScore, responseTime, omissionScore, DS,flowr_position,flower_heights);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        string url = "https://dashboard.myvrapeutic.com/api/v1/statistics";
        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        Debug.Log("SendjsonIEnum :" + json);
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        statisticsInstance = JsonUtility.FromJson<StatisticsJsonFile>(www.downloadHandler.text);
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
    string ConvertPostToJson(string headset, string roomid, string sessionStartTime, string attemptStartTime, string attemptEndTime, string attemptType, float expectedDurationInSeconds, string Level, float flowerSustained, float wellSustained, float totalSustained, float nonSustained, float actualDurationInSeconds, float actualAttentionTime, float score, float implusivityScore, float responseTime, float omissionScore, float DES,string flowr_position,string flower_heights)
    {
        StatisticsJsonFile postRequest =new StatisticsJsonFile();
        postRequest.headset = headset;
        postRequest.room_id = roomid;

        postRequest.data.session_start_time = sessionStartTime;
        postRequest.data.attempt_start_time = attemptStartTime;
        postRequest.data.attempt_end_time = attemptEndTime;
        postRequest.data.attempt_type = attemptType;
        postRequest.data.expected_duration_in_seconds = expectedDurationInSeconds;
        postRequest.data.level = Level;
        postRequest.data.flower_sustained = flowerSustained;
        postRequest.data.well_sustained = wellSustained;
        postRequest.data.total_sustained = totalSustained;
        postRequest.data.non_sustained = nonSustained;
        postRequest.data.actual_duration_in_seconds = actualDurationInSeconds;
        postRequest.data.actual_attention_time = actualAttentionTime;
        postRequest.data.score = score;

        postRequest.data.impulsivity_score = implusivityScore;
        postRequest.data.response_time = responseTime;
        postRequest.data.omission_score = omissionScore;
        postRequest.data.distraction_endurance_score = DES;
        postRequest.data.flower_postitions=flowr_position;
        postRequest.data.flower_Heights=flower_heights;

        return JsonUtility.ToJson(postRequest);
    }
    public StatisticsJsonFile ReturnSendStatistics()
    {
        return statisticsInstance;
    }
    #endregion
    #region PutRequest
    public IEnumerator SendPutRequest(int id, string endedAt, string serial)
    {
        string json = ConvertPutTojson(id, endedAt, serial);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        string url = "https://dashboard.myvrapeutic.com/api/v1/module_sessions";
        string putUrl = url + "/" + id + "?" + "ended_at=" + endedAt + "&" + "headset=" + serial;
        UnityWebRequest www = UnityWebRequest.Put(putUrl, postData);
        yield return www.SendWebRequest();
        Debug.Log(putUrl);
        putRequstJsonInstance = JsonUtility.FromJson<PutRequstJson>(www.downloadHandler.text);
        Debug.Log(putRequstJsonInstance);
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else if (www.downloadHandler.text != null)
        {
            Debug.Log("all" + www.downloadHandler.text);
        }
    }
    string ConvertPutTojson(int id, string endedAt, string serial)
    {
        PutRequstJson putRequst = new PutRequstJson();
        putRequst.id = id;
        putRequst.ended_at = endedAt;
        putRequst.headset = serial;
        return JsonUtility.ToJson(putRequst);
    }
    public PutRequstJson ReturnPutRequstJson()
    {
        return putRequstJsonInstance;
    }
    #endregion
}
