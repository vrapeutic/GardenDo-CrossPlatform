using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Tachyon;
using System;

public class CSVWriter_Old : MonoBehaviour
{
    string fileName;
    string attempStartTime;
    string attempEndTime;
    public float NPCInstructionsConsumedSeconds = 80;
    float DES = 0;
    float score = 0;
    float responseTime = 0;
    float TaR = 0;
    float timeTaken = 0;
    float typicalTime = 0;
    float TiR = 0;
    float implusivityScore = 0;
    float TAS = 0;
    float AAS = 0;
    float omissionScore = 0;
    float TFD = 0;
    int level;
    float wellSustained = 0;
    float flowerSustained = 0;

    bool isStatsSent = false;

    Statistics stats;

    CSVFileManager myCSVFileManager;
    String header;
    string dateTime;
    string timeString;
    DateTime StartDateTime;
    String data = "";
    void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("SendStatisticsRPC", invokationManager);
        attempStartTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        fileName = Application.dataPath + "/statistics.csv";
        stats = Statistics.instane;
        level = stats.level;
        WriteCSV();

    }


    private void WriteCSV()
    {

        if (File.Exists(fileName))
        {
            Debug.Log("file created");
        }
        else
        {
            InitiateStateVaribaleFields();
        }
    }

    public void SaveCognitiveDataToCSV(string session_start_time, string attempt_start_time, string attempt_end_time, float expected_duration_in_seconds,
         float actual_duration_in_seconds, string level, string attempt_type, float impulsivity_score, float response_time, float omission_score,
        float actual_attention_time, float flower_count, float flowerSustained, float wellSustained, float totalSustained, float nonSustained,
        float des, float score)
    {

        StartDateTime = DateTime.Now;
        dateTime = StartDateTime.ToString("dd-MM-yyyy");
        timeString = StartDateTime.ToString("hh-mm-ss");


        myCSVFileManager = gameObject.AddComponent(typeof(CSVFileManager)) as CSVFileManager;


        header = "session_start_time, attempt_start_time, attempt_end_time, expected_duration_in_seconds," +
         " actual_duration_in_seconds, level, attempt_type, flower_max_height, flower_min_height, flower_average_height" +
        ", impulsivity_score, response_time, omission_score, actual_attention_time, flower_count, flowerSustained" +
        ", wellSustained, totalSustained, nonSustained, des, score, flowr_position, flower_heights\n";

        data = session_start_time + ", " + attempt_start_time + ", " + attempt_end_time + ", " + expected_duration_in_seconds + ", " +
            actual_duration_in_seconds + ", " + level + ", " + attempt_type + ", " + impulsivity_score + ", " + response_time
          + ", " + omission_score + ", " + actual_attention_time + ", " + flower_count + ", " + flowerSustained + ", " +
          wellSustained + ", " + totalSustained + ", " + nonSustained + ", " + des + ", " + score;
        fileName = dateTime + "-" + timeString + "CognitiveData.csv";
        myCSVFileManager.writeStringToFile(header + data, fileName);

    }
    private void OnApplicationQuit()
    {
        if (!isStatsSent)
        {
            SendStatistics();
        }
        attempEndTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        //  WriteFinalStatistics();

    }
    public void WriteFinalStatistics()
    {
        TextWriter myTextWriter = new StreamWriter(fileName, true);

        myTextWriter.WriteLine(attempStartTime + "," + attempEndTime + "," + typicalTime + "," + timeTaken + "," + level + "," + flowerSustained
                + "," + wellSustained + "," + implusivityScore + "," + score + "," + omissionScore + "," + DES);
        myTextWriter.Close();
        Debug.Log("stats should be written");
    }



    private void InitiateStateVaribaleFields()
    {
        TextWriter myTextWriter = new StreamWriter(fileName, false);

        myTextWriter.WriteLine("session start time,attempt end time,typical time ,actual duration,level," +
            "flower suatained,well sustained,impulisvity score,score,omission score,distraction endurance score");
        myTextWriter.Close();
    }

    public void OnGameFinished()
    {
        attempEndTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        if (Statistics.android)
        {
            CalculateStatistics();
            SendStatistics();
        }

    }

    private void SendStatistics()
    {
        isStatsSent = true;
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("SendStatisticsRPC", this.gameObject.name, typicalTime, timeTaken, level, flowerSustained, wellSustained,
                implusivityScore, score, omissionScore, DES);
        }
    }


    public void TestSensStats()
    {
        SendStatisticsRPC(0, 1, 2, 3, 4, 5, 6, 7, 8);
    }

    public void SendStatisticsRPC(float _typicalTime, float _timeTaken, int _level, float _flowerSustained, float _wellSusutained, float _implusivityScore,
        float _score, float _omissionScore, float _DES)
    {

        typicalTime = _typicalTime;
        timeTaken = _timeTaken;
        level = _level;
        flowerSustained = _flowerSustained;
        wellSustained = _wellSusutained;
        implusivityScore = _implusivityScore;
        score = _score;
        omissionScore = _omissionScore;
        DES = _DES;

        Debug.Log(typicalTime.ToString() + "," + timeTaken.ToString() + "," + level + "," + flowerSustained + "," + wellSustained + "," + implusivityScore
            + "," + score + "," + omissionScore + "," + DES);
        Debug.Log("pc recieved stats");
        WriteFinalStatistics();



    }

    public void CalculateStatistics()
    {

        Debug.Log("Calculate statistics");

        TaR = 0;
        timeTaken = Time.timeSinceLevelLoad;
        typicalTime = stats.totalFlowerGrowth + 10 + NPCInstructionsConsumedSeconds;
        TiR = (float)timeTaken / (float)typicalTime;
        flowerSustained = stats.flowerSustained;
        wellSustained = stats.wellSustained;
        TAS = stats.totalFlowerGrowth + 10;
        AAS = stats.flowerSustained + stats.wellSustained;

        TFD = AAS - TAS;


        if (stats.flowerSustained == 0)
        {
            score = 0;
            omissionScore = 0;
        }
        else
        {
            score = ((float)stats.totalFlowerGrowth / (float)stats.flowerSustained) * 100;
            omissionScore = (float)((float)TAS / (AAS + Mathf.Epsilon));
        }

        if (stats.level == 1)
        {
            DES = 0;
        }
        else
        {
            DES = (1 - ((float)TFD / (float)TAS));
        }

        if (stats.level == 1 || stats.level == 2)
        {
            responseTime = (float)stats.wateringResponseTimeCounter / (stats.wateringResponseTimes);
        }
        else if (stats.level == 3)
        {
            responseTime = (((float)stats.wateringResponseTimeCounter / (stats.wateringResponseTimes)) + ((float)stats.birdFlyingResponseTimeCounter / stats.birdFlyingResponseTimes)) / 2;
        }

        if (stats.tasksWithLimitiedInterruptions == 0)
        {
            implusivityScore = 1;
        }
        else
        {
            TaR = (float)stats.tasksWithLimitiedInterruptions / (float)stats.totalNumberOfTasks;
            implusivityScore = (float)(1 / ((-TaR) * ((Mathf.Log10(TiR) - 1) + Mathf.Epsilon)));
        }




    }

}
