using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseTime : MonoBehaviour
{
     TovaDataSet dataSet;
    [SerializeField] private float responseTimeCounter;
    [SerializeField] private float distractorResponseTimeCounter;
    [SerializeField] private int noOfTriesCounter;
    [SerializeField] private int noOfDistractorHitsCounter;
    [SerializeField] private float currentResponseTime;
    [SerializeField] private float currentdistractorResponseTime;

    void Start()
    {
        dataSet = TovaDataGet.ReturnTovaData();
    }
   
    #region TestWithInvoker
    void InvokerResponseTimeTest(bool responseTimer, int tries, int hits, bool end, bool distractorTimer)
    {
        dataSet.SetResponseTimer(responseTimer);
        dataSet.SetDistractorResponseTimer(distractorTimer);
        dataSet.SetSessionEnd(end);
        dataSet.SetTotalNumOfTries(tries);
        dataSet.SetTotalNumOfDistractorHit(hits);
        Debug.Log(dataSet.GetSessionEnd() + "" + dataSet.GetResponseTimer() + dataSet.GetTotalResponseTime());
    }
    #endregion

    void Update()
    {

         if (dataSet.GetResponseTimer())
                 responseTimeCounter += Time.deltaTime;

        if (dataSet.GetDistractorResponseTimer())
                 distractorResponseTimeCounter += Time.deltaTime;

        if (dataSet.GetTotalNoOfDistractorHitsCounterState())
        {
            noOfDistractorHitsCounter++;
            dataSet.SetTotalNumOfDistractorHit(noOfDistractorHitsCounter);
            dataSet.SetNoOfDistractorHitsCounter(false);
        }
        if (dataSet.GetTotalNoOfTriesCounterState())
        {
            noOfTriesCounter++;
            dataSet.SetTotalNumOfTries(noOfTriesCounter);
            dataSet.SetNoOfTriesCounter(false);
        }
        if (dataSet.GetSessionEnd())
             {
               
                 dataSet.SetTotalResponseTime(TotalResponceTime());
                 
             }
 
    }

    float GetCurrentResponceTime()
    {
       
            if (dataSet.GetTotalNumOfTries() == 0) dataSet.SetTotalNumOfTries(1);
            currentResponseTime = (float)responseTimeCounter / (float)dataSet.GetTotalNumOfTries();
        
        return currentResponseTime;
    }

    float GetCurrentDistractorResponseTime()
    {
            if (dataSet.GetTotalNumOfDistractorHit() == 0) dataSet.SetTotalNumOfDistractorHit(1);
        currentdistractorResponseTime = (float)distractorResponseTimeCounter / (float)dataSet.GetTotalNumOfDistractorHit();
  
        return currentdistractorResponseTime;
    }

    float TotalResponceTime()
    {
        if (GetCurrentDistractorResponseTime() > 0)
         return currentResponseTime=GetCurrentResponceTime()*dataSet.GetResponseWight() + GetCurrentDistractorResponseTime()*dataSet.GetResponseDistractorWight();
        else return currentResponseTime=GetCurrentResponceTime();      
    }
  
}
