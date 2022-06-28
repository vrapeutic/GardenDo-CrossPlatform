using System;
using UnityEngine;
[Serializable]
public class CreateSession
{
    public int id;
    public string room_id;
    public string session_date;
}

[Serializable]
public class SessionStats
{
    public string room_id;
    public MyData data = new MyData();


}

//this class will be customized to every module
[Serializable]
public class MyData
{
    //add data attributes here 
    public string session_start_time;
    public string attempt_start_time;
    public string attempt_end_time;
    public float expected_duration_in_seconds;
    public float actual_duration_in_seconds;
    public string level;
    public string attempt_type;
    public float impulsivity_score;
    public float response_time;
    public float omission_score;
    public float distractibility_score;
    public float actual_attention_time;
    public float flowerSustained;
    public float wellSustained;
    public float totalSustained;
    public float nonSustained;
    public float des;
    public float score;
    public string flowr_position;
    public string flower_heights;
}

[Serializable]
public class SessionElements
{
    public int patient_id;
    public int vr_module_id;
}
[Serializable]
public class GetStatsData
{
    public SessionData sessionData;
}
[Serializable]
public class SessionData
{
    string desc;
}

