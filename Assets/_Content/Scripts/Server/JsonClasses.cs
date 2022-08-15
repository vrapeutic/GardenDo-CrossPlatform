using System;

[Serializable]
public class GetRoomIDJson
{
    public int id;
    public string room_id;
}

public class StatisticsJsonFile
{
  
   
    public string headset;
    public string room_id;
    public Data data = new Data();


}

//this class will be customized to every module
[Serializable]
public class Data
{
    //add data attributes here 
    public string session_start_time;//this for example
    public string attempt_start_time;  //important
    public string attempt_end_time;
    public string attempt_type = "open";

    public float expected_duration_in_seconds = 120;//for flower from ui
    public string level = "3";

    public float flower_sustained;
    public float well_sustained;
    public float total_sustained;
    public float non_sustained;
    public float score;
    public float actual_duration_in_seconds;
    public float actual_attention_time;

    //New Data
    public float impulsivity_score;
    public float response_time;
    public float omission_score;
    public float distraction_endurance_score;
    public string flower_postitions;
    public string flower_Heights;

}

//to form json file put request
[Serializable]
public class PutRequstJson
{
    public int id;
    public string ended_at;//the current time when set put request
    public string headset;
}

//for recieving pusher json file
[Serializable]
public class PusherJson
{
    public string room_id;
    public string package;
    public string name;
}
