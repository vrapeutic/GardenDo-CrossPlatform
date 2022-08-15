using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTimersHandling : MonoBehaviour
{
    
   
    
    bool startCounting = false;
    private int taskTriesNum;

    Statistics stats;
    private void Start()
    {
        
        taskTriesNum = 0;
        stats = Statistics.instane;
      
    }

    public void StartNewFlowerTask()
    {
        if(taskTriesNum < (stats.numberOfFlowers - 1))
        {
            TovaDataGet.ReturnTovaData().SetResponseTimer(true);
            TovaDataGet.ReturnTovaData().SetNoOfTriesCounter(true);
        }
      


        startCounting = true;
        Debug.Log("response time started");
        //  ResponseTimeData.totalNumOfTries += 1;

    }

    public void StopResponsTimeCounter()
    {
        //ResponseTimeData.responseTimeChecker = false;
        TovaDataGet.ReturnTovaData().SetResponseTimer(false);
        startCounting = false;
        Debug.Log("response time stopped");
    }

    public void TasksFinsished()
    {
        TovaDataGet.ReturnTovaData().SetSessionEnd(true);

        startCounting = false;
    }

    
}
