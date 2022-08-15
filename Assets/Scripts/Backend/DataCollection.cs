using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class DataCollection : ScriptableObject
{
    public string session_start_time = "yyyy/MM/dd hh:mm:ss tt";
    public string attempt_start_time = "yyyy/MM/dd hh:mm:ss tt";
    public string attempt_end_time = "yyyy/MM/dd hh:mm:ss tt";
    public float expected_duration_in_seconds = 30;
    public float actual_duration_in_seconds = 40;
    public string level = "1";
    public string attempt_type = "Open";
    public float actual_attention_time = 20;
    public float flowerSustained = 20;
    public float wellSustained = 20;
    public float totalSustained = 20;
    public float nonSustained = 20;
    public float impulsivity_score = 1;
    public float response_time = 20;
    public float omission_score = 0;
    public float distractibility_score = 16;
    public float flower_min_height=0.36f;
    public float flower_max_height = 0.36f;
    public float flower_average_height = 0.36f;
    public float flower_count=4;
    public float des = 20;
    public float score = 20;
    public string flowr_position = " ";
    public string flower_heights = " ";

    //public float total_arches_count = 15;
    //public float consumed_arches = 10;
    //public float success_arches_count = 10;
    //public float distance = 10;
    //public float total_prizes = 10;
    //public float remaining_prizes = 5;
    //public float distraction_endurance_score = 2;

    #region Performance_Data
    public string handToolsDataList =" ";

    #endregion
}