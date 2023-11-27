using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class StatisticsManager : MonoBehaviour
{
    float score;
    float responseTime = 0;
    float DES = 0;
    [HideInInspector]
    public float NPCInstructionsConsumedSeconds = 80;
    string attempStartTime;
    // string startTime;
    string attemptEndTime;
    // StatisticsJsonFile StatisticsJsonFileInstance = new StatisticsJsonFile();

    private bool canEnterSendStatistics = true;

    public static StatisticsManager instance = new StatisticsManager();

    Statistics stats;

    BackendSession currentSession;
    DataCollection dataCollection;

    public CSVWriter_Old csvWriter;
    private void Awake()
    {
        //currentSession = FindObjectOfType<BackendSession>();
        //dataCollection = FindObjectOfType<BackendSession>().MyStats;

        if (instance == null) instance = this;
        else Destroy(this);
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        stats = Statistics.instane;


        //  startTime = ServerRequest.instance.startTime;
        attempStartTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");

        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        ////  NetworkManager.InvokeClientMethod("SendAttemptStatistics", invokationManager);
        //NetworkManager.InvokeClientMethod("ResetStatisticsRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("OnSendStatisticsRPC", invokationManager);
    }

    private void Update()
    {
        if (stats.wateringResponseTimeCounterBegin)
        {
            stats.wateringResponseTimeCounter += Time.deltaTime;
            // if (stats.wateringResponseTimeCounter % 1 < 0.02) //Debug.Log("Response Time : Watering Respone Timer Counter: " + stats.wateringResponseTimeCounter);
        }
        if (stats.birdFlyingResponseTimeCounterBegin)
        {
            stats.birdFlyingResponseTimeCounter += Time.deltaTime;
            //if (stats.birdFlyingResponseTimeCounter % 1 < 0.02) //Debug.Log("Response Time : Bird Respone Timer Counter: " + stats.birdFlyingResponseTimeCounter);
        }
    }

    private void OnDestroy()
    {
        //  SendAttemptStatistics();
    }

    public void OnSendStatistics()
    {
        // SendAttemptStatistics();
        // Debug.Log("OnSendStatisticsclicked()");

        //if (!Statistics.android)
        //{
        //NetworkManager.InvokeServerMethod("OnSendStatisticsRPC", this.gameObject.name);
        //}
        OnSendStatisticsRPC();
    }

    public void OnSendStatisticsRPC()
    {
        TovaDataGet.ReturnTovaData().SetSessionEnd(true);
        Debug.Log("SendAttemptStatistics");
        Debug.Log(TovaDataGet.ReturnTovaData() + "dataset in stats");
        //string[] list=TovaDataGet.ReturnTovaData().GetTargetDataListPositions().ToArray();
        //  Debug.Log(list[1]+"this is position");
        Debug.Log("response time manager" + TovaDataGet.ReturnTovaData().GetTotalResponseTime());
        Debug.Log("omission time manager " + TovaDataGet.ReturnTovaData().GetTotalOmissionScore());
        Debug.Log("impusivity manager " + TovaDataGet.ReturnTovaData().GetTotalImpsScore());
        Invoke("SendAttemptStatistics", 3);
        Invoke("SendStatistics", 3);
        //SendAttemptStatistics();
        Debug.Log("OnSendStatisticsclicked()");
    }

    public void SendStatistics()
    {
        float timeTaken = Time.timeSinceLevelLoad;
        float typicalTime = stats.totalFlowerGrowth + 10 + NPCInstructionsConsumedSeconds;
        float AAS = TovaDataGet.ReturnTovaData().GetActualTimeSpan();
        float _score;
        float omissionScore;
        if (stats.flowerSustained == 0)
        {
            _score = 0;
            omissionScore = 0;
        }
        else
        {
            _score = ((float)stats.totalFlowerGrowth / (float)stats.flowerSustained) * 100;
            omissionScore = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
        }

        string session_start_time = attempStartTime;
        string attempt_start_time = attempStartTime;
        string attempt_end_time = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        float expected_duration_in_seconds = typicalTime;
        float actual_duration_in_seconds = timeTaken;
        string level = stats.level.ToString();
        string attempt_type = "open";
        float flower_max_height = TovaDataGet.ReturnTovaData().GetMax_Height();
        float flower_min_height = TovaDataGet.ReturnTovaData().GetMin_Height();
        float flower_average_height = TovaDataGet.ReturnTovaData().GetAver_Height();
        float impulsivity_score = TovaDataGet.ReturnTovaData().GetTotalImpsScore();
        float response_time = TovaDataGet.ReturnTovaData().GetTotalResponseTime();
        float omission_score = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
        //dataCollection.distractibility_score = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
        float actual_attention_time = TovaDataGet.ReturnTovaData().GetActualTimeSpan();
        float flower_count = stats.numberOfFlowers;
        float flowerSustained = stats.flowerSustained;
        float wellSustained = stats.wellSustained;
        float totalSustained = stats.flowerSustained + stats.wellSustained;
        float nonSustained = Time.timeSinceLevelLoad - (AAS + NPCInstructionsConsumedSeconds);
        float des = TovaDataGet.ReturnTovaData().GetTotalDES();
        float score = _score;
        string flowr_position = TovaDataGet.ReturnTovaData().GetTargetDataListPositions();
        string flower_heights = TovaDataGet.ReturnTovaData().GetTargetDataListHights();


        csvWriter.SaveCognitiveDataToCSV(session_start_time, attempt_start_time, attempt_end_time, expected_duration_in_seconds,
          actual_duration_in_seconds, level, attempt_type, impulsivity_score, response_time, omission_score,
         actual_attention_time, flower_count, flowerSustained, wellSustained, totalSustained, nonSustained,
         des, score);


    }
    public void SendAttemptStatistics()
    {
        if (Statistics.android)
        {
            if (canEnterSendStatistics)
            {
                Debug.Log("SendAttemptStatistics");
                Debug.Log(TovaDataGet.ReturnTovaData() + "dataset in stats2");

                Debug.Log("response time manager" + TovaDataGet.ReturnTovaData().GetTotalResponseTime());
                Debug.Log("omission time manager " + TovaDataGet.ReturnTovaData().GetTotalOmissionScore());
                Debug.Log("impusivity manager " + TovaDataGet.ReturnTovaData().GetTotalImpsScore());
                //float TaR = 0;
                float timeTaken = Time.timeSinceLevelLoad;
                float typicalTime = stats.totalFlowerGrowth + 10 + NPCInstructionsConsumedSeconds;
                float TiR = (float)timeTaken / (float)typicalTime;
                float implusivityScore;
                float TAS = TovaDataGet.ReturnTovaData().GetTAS();
                float AAS = TovaDataGet.ReturnTovaData().GetActualTimeSpan();
                float omissionScore;
                float TFD = TovaDataGet.ReturnTovaData().GetActualTimeSpan() - TovaDataGet.ReturnTovaData().GetTAS();
                float score;



                if (stats.flowerSustained == 0)
                {
                    score = 0;
                    omissionScore = 0;
                }
                else
                {
                    score = ((float)stats.totalFlowerGrowth / (float)stats.flowerSustained) * 100;
                    omissionScore = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
                }
                DES = TovaDataGet.ReturnTovaData().GetTotalDES();
                DES = (DES * (1f / 5f)) + 1f;
                if (stats.level == 1 || stats.level == 2)
                {


                    // responseTime = (float)stats.wateringResponseTimeCounter / 1;                

                    responseTime = TovaDataGet.ReturnTovaData().GetTotalResponseTime();



                }
                else if (stats.level == 3)
                {

                    responseTime = TovaDataGet.ReturnTovaData().GetTotalResponseTime();


                }
                implusivityScore = TovaDataGet.ReturnTovaData().GetTotalImpsScore();


                Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListPositions());
                Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListHights());


                dataCollection.session_start_time = attempStartTime;
                dataCollection.attempt_start_time = attempStartTime;
                dataCollection.attempt_end_time = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
                dataCollection.expected_duration_in_seconds = typicalTime;
                dataCollection.actual_duration_in_seconds = timeTaken;
                dataCollection.level = stats.level.ToString();
                dataCollection.attempt_type = "open";
                dataCollection.flower_max_height = TovaDataGet.ReturnTovaData().GetMax_Height();
                dataCollection.flower_min_height = TovaDataGet.ReturnTovaData().GetMin_Height();
                dataCollection.flower_average_height = TovaDataGet.ReturnTovaData().GetAver_Height();
                dataCollection.impulsivity_score = TovaDataGet.ReturnTovaData().GetTotalImpsScore();
                dataCollection.response_time = TovaDataGet.ReturnTovaData().GetTotalResponseTime();
                dataCollection.omission_score = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
                //dataCollection.distractibility_score = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
                dataCollection.actual_attention_time = TovaDataGet.ReturnTovaData().GetActualTimeSpan();
                dataCollection.flower_count = stats.numberOfFlowers;
                dataCollection.flowerSustained = stats.flowerSustained;
                dataCollection.wellSustained = stats.wellSustained;
                dataCollection.totalSustained = stats.flowerSustained + stats.wellSustained;
                dataCollection.nonSustained = Time.timeSinceLevelLoad - (AAS + NPCInstructionsConsumedSeconds);
                dataCollection.des = TovaDataGet.ReturnTovaData().GetTotalDES();
                dataCollection.score = score;
                dataCollection.flowr_position = TovaDataGet.ReturnTovaData().GetTargetDataListPositions();
                dataCollection.flower_heights = TovaDataGet.ReturnTovaData().GetTargetDataListHights();
                //  dataCollection.targetDataList = TovaDataGet.ReturnTovaData().GetTargetDataListPositions();

                currentSession.SendStatsData();
                Debug.Log(" TFD: " + TFD + " Time Taken: " + timeTaken + " Typical Time: " + typicalTime + " TAS: " + TAS + " Response time: " + responseTime + " AAS: " + AAS + " Task with limited interruption: " + stats.tasksWithLimitiedInterruptions);

                //call post json 
                //ServerRequest.instance.SendPostRequest(ServerRequest.headset,
                //                            ServerRequest.roomId,
                //                            attempStartTime,
                //                            attempStartTime,
                //                            System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt"),
                //                            "open",re
                //                            typicalTime,
                //                            stats.level.ToString(),
                //                            stats.flowerSustained,
                //                            stats.wellSustained,
                //                            stats.flowerSustained + stats.wellSustained,
                //                            Time.timeSinceLevelLoad - (AAS + NPCInstructionsConsumedSeconds),
                //                            timeTaken,
                //                            TovaDataGet.ReturnTovaData().GetActualTimeSpan(),
                //                            score,
                //                            TovaDataGet.ReturnTovaData().GetTotalImpsScore(),
                //                            TovaDataGet.ReturnTovaData().GetTotalResponseTime(),
                //                            TovaDataGet.ReturnTovaData().GetTotalOmissionScore(),
                //                            TovaDataGet.ReturnTovaData().GetTotalDES(), TovaDataGet.ReturnTovaData().GetTargetDataListPositions(), TovaDataGet.ReturnTovaData().GetTargetDataListHights());///,TovaDataGet.ReturnTovaData().GetTargetDataListPositions().ToArray()[1]);
                //ServerRequest.instance.SendPostRequest(ServerRequest.headset,
                //                   ServerRequest.roomId,
                //                   attempStartTime,
                //                   attempStartTime,
                //                   System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt"),
                //                   "open",
                //                   Time.timeSinceLevelLoad,
                //                   Statistics.level.ToString(),
                //                   Statistics.flowerSustained,
                //                   Statistics.wellSustained,
                //                  0,
                //                  0,
                //                  0,
                //                  0,
                //                  0,
                //                  0,
                //                  0,
                //                  0);
                Debug.Log("post");

                //  if (Statistics.android) JsonPreparation.instance.PostJson(JsonItemsInstanceString);
                TovaDataGet.ReturnTovaData().SetSessionEnd(false);
                ResetStatistics();
                canEnterSendStatistics = false;
            }
        }

    }

    public void ResetStatistics()
    {
        ResetStatisticsRPC();
        // NetworkManager.InvokeServerMethod("ResetStatisticsRPC", this.gameObject.name);
    }

    public void ResetStatisticsRPC()
    {

        stats.flowerSustained = 0f;
        stats.wellSustained = 0f;
        stats.totalFlowerGrowth = 0;
        stats.growthSpeed = 0f;
        stats.level = 1;

        stats.tasksWithLimitiedInterruptions = 0;
        stats.totalNumberOfTasks = 4;
        stats.wateringResponseTimeCounter = 0;
        stats.wateringResponseTimeCounterBegin = false;
        stats.birdFlyingResponseTimeCounter = 0;
        stats.birdFlyingResponseTimeCounterBegin = false;
        stats.birdFlyingResponseTimes = 0;
        stats.wateringResponseTimes = 0;
    }

    public void WateringResponseTimeController(bool _wateringResponseTimeCounterBegin)
    {
        stats.wateringResponseTimeCounterBegin = _wateringResponseTimeCounterBegin;
    }
}
