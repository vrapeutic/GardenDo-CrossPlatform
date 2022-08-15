using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmissionScore : MonoBehaviour
{

    TovaDataSet dataSet;
    [SerializeField] private float actualTimeSpanCounter;
    [SerializeField] private float distractingTime;
    [SerializeField] private float omissionScore;
    [SerializeField] private float distractingScore;
    [SerializeField] bool levelTimeCounter;

    void Start()
    {
        dataSet = TovaDataGet.ReturnTovaData();

    }

    #region TestWithInvoker
    void InvokerOmissionScoreTest(bool isEnbaled, int time, bool end, bool distractorEnbaled)
    {
        dataSet.SetActualTimeCounter(isEnbaled);
        dataSet.SetDistractorEnabled(distractorEnbaled);
        dataSet.SetDistractingTime(time);
        dataSet.SetSessionEnd(end);
        Debug.Log(dataSet.GetSessionEnd() + "" + dataSet.GetTotalDES() + dataSet.GetTotalOmissionScore());
    }
    #endregion

    void Update()
    {
        if (dataSet.GetActualTimeSpanState()) { 
            actualTimeSpanCounter += Time.deltaTime;
            dataSet.SetActualTime(actualTimeSpanCounter);
            dataSet.SetDistractingTime(GetCurrentTFD());
        }
        if (dataSet.GetSessionEnd())
        {
            
            dataSet.SetTotalOmissionScore(CurrentTotalOmissionScore());

            if(dataSet.GetDistractorState())
                dataSet.SetDistractingScore(GetCurrentDES());
            
            levelTimeCounter = true;
        }


    }

    float GetCurrentAAS()
    {
        return actualTimeSpanCounter;
    }

    float GetCurrentTFD()
    {
        if (!levelTimeCounter)
            distractingTime = Time.timeSinceLevelLoad - (GetCurrentAAS()+dataSet.GetInstructionTime());
        return distractingTime;
    }
    float GetCurrentDES()
    {
        distractingScore = (1 - ((float)GetCurrentTFD() / (float)dataSet.GetTAS()));
        return distractingScore;
    }
    float CurrentTotalOmissionScore()
    {
        if (GetCurrentAAS() == 0) omissionScore = 0;
        else omissionScore = (float)((float)dataSet.GetTAS() / (GetCurrentAAS() + Mathf.Epsilon));
        return omissionScore;

    }
}
