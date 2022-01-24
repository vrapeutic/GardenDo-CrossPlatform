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
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        stats = Statistics.instane;
        Debug.LogWarning(this.gameObject.name);

        //  startTime = ServerRequest.instance.startTime;
        attempStartTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");

        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //  NetworkManager.InvokeClientMethod("SendAttemptStatistics", invokationManager);
        NetworkManager.InvokeClientMethod("ResetStatisticsRPC", invokationManager);
        NetworkManager.InvokeClientMethod("OnSendStatisticsRPC", invokationManager);
    }

    private void Update()
    {
        if (stats.wateringResponseTimeCounterBegin)
        {
            stats.wateringResponseTimeCounter += Time.deltaTime;
            if (stats.wateringResponseTimeCounter % 1 < 0.02) Debug.Log("Response Time : Watering Respone Timer Counter: " + stats.wateringResponseTimeCounter);
        }
        if (stats.birdFlyingResponseTimeCounterBegin)
        {
            stats.birdFlyingResponseTimeCounter += Time.deltaTime;
            if (stats.birdFlyingResponseTimeCounter % 1 < 0.02) Debug.Log("Response Time : Bird Respone Timer Counter: " + stats.birdFlyingResponseTimeCounter);
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
        if (!Statistics.android)
        {
            NetworkManager.InvokeServerMethod("OnSendStatisticsRPC", this.gameObject.name);
        }

    }

    public void OnSendStatisticsRPC()
    {
        SendAttemptStatistics();
        Debug.Log("OnSendStatisticsclicked()");
    }

    public void SendAttemptStatistics()
    {
        if (Statistics.android)
        {
            if (canEnterSendStatistics)
            {
                Debug.Log("SendAttemptStatistics");

                float TaR = 0;
                float timeTaken = Time.timeSinceLevelLoad;
                float typicalTime = stats.totalFlowerGrowth + 10 + NPCInstructionsConsumedSeconds;
                float TiR = (float)timeTaken / (float)typicalTime;
                float implusivityScore;
                float TAS = stats.totalFlowerGrowth + 10;
                float AAS = stats.flowerSustained + stats.wellSustained;
                float omissionScore;
                float TFD = AAS - TAS;
                float score;

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


                    // responseTime = (float)stats.wateringResponseTimeCounter / 1;                

                    responseTime = (float)stats.wateringResponseTimeCounter / (stats.wateringResponseTimes);
                    if (responseTime.ToString() == "NaN")
                    {
                        responseTime = 5;
                    }


                }
                else if (stats.level == 3)
                {

                    responseTime = (((float)stats.wateringResponseTimeCounter / (stats.wateringResponseTimes)) + ((float)stats.birdFlyingResponseTimeCounter / stats.birdFlyingResponseTimes)) / 2;

                    if (responseTime.ToString() == "NaN")
                    {
                        responseTime = 5;
                    }
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


                Debug.Log(" TFD: " + TFD + " TaR: " + TaR + " Time Taken: " + timeTaken + " Typical Time: " + typicalTime + " TAS: " + TAS + " TiR: " + TiR + " AAS: " + AAS + " Task with limited interruption: " + stats.tasksWithLimitiedInterruptions);



                //call post json 
                ServerRequest.instance.SendPostRequest(ServerRequest.headset,
                                            ServerRequest.roomId,
                                            attempStartTime,
                                            attempStartTime,
                                            System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt"),
                                            "open",
                                            typicalTime,
                                            stats.level.ToString(),
                                            stats.flowerSustained,
                                            stats.wellSustained,
                                            stats.flowerSustained + stats.wellSustained,
                                            Time.timeSinceLevelLoad - (AAS + NPCInstructionsConsumedSeconds),
                                            timeTaken,
                                            AAS,
                                            score,
                                            implusivityScore,
                                           responseTime,
                                            omissionScore,
                                            DES);
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
                canEnterSendStatistics = false;
            }
        }

    }

    public void ResetStatistics()
    {
        NetworkManager.InvokeServerMethod("ResetStatisticsRPC", this.gameObject.name);
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
