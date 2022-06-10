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
    public float total_sustained = 20;
    public float non_sustained = 20;
    public float impulsivity_score = 1;
    public float response_time = 20;
    public float omission_score = 0;
    public float distractibility_score = 16;
    public float actual_attention_time = 20;
    public float flowerSustained = 10;
    public float wellSustained = 5;
    public float totalSustained = 0;
    public float nonSustained = 0;
    public float des = 0;
    public float score = 0;
    public string flowr_position = "";
    public string flower_heights = "";
}