using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplusivityScore : MonoBehaviour
{
     TovaDataSet dataSet;
    [SerializeField] float currentAmingScore;
    [SerializeField] float currentImpulsivityScore;
    [SerializeField] float currentImpulsivityScoreWithAming;
    [SerializeField] float currentArrows;
    [SerializeField] float currentTargetsNO;
    [SerializeField] float currentHitsNO;
    [SerializeField] float targetRatios;
    [SerializeField] float timeRatios;

    void Start()
    {
        dataSet = TovaDataGet.ReturnTovaData();

    }

    #region TestWithInvoker
    void InvokerImpsScoreTest(bool isEnbaled, bool end, bool distractorEnbaled,bool isReleased)
    {
        dataSet.SetTargetsCounterEnabled(isEnbaled);
        dataSet.SetHitsCounterEnabled(distractorEnbaled);
        dataSet.SetIsReleasedEnabled(isReleased);
        dataSet.SetSessionEnd(end);
        Debug.Log(dataSet.GetSessionEnd() + "" + dataSet.GetTotalImpsScore() + dataSet.GetTimeRatios()+""+ dataSet.GetTargetRatios());

    }
    
    #endregion
    void Update()
    {
        if (dataSet.GetTargetsCounter()) {
            currentTargetsNO++;
            dataSet.SetTotalNumOfTargets(currentTargetsNO);
            dataSet.SetTargetsCounterEnabled(false);
        }
        if (dataSet.GetHitsCounter()) {
            currentHitsNO++;
            dataSet.SetNumOfHits(currentHitsNO);
            dataSet.SetHitsCounterEnabled(false);
        }
        if(dataSet.GetIsReleasedState())
        {
            currentArrows++;
            dataSet.SetReleasedArrows(currentArrows);
            dataSet.SetIsReleasedEnabled(false);
        }
        if (dataSet.GetSessionEnd())
        {
            dataSet.SetTargetsRatios(TAR());
            dataSet.SetTimeRatios(TIR());
            dataSet.SetTotalImpsScore(TotalImpulsivityScore());
            dataSet.SetTotalImpsScoreWithAming(TotalImpulsivityScoreWithAming());
        }
    }
    float TAR()
    {
        if (dataSet.GetTotalNumOfTargets() == 0) targetRatios = 0;
        else targetRatios = dataSet.GetNumOfHits() / dataSet.GetTotalNumOfTargets();
        return targetRatios;
    }
    float TIR()
    {
 
        timeRatios = (float)(Time.timeSinceLevelLoad / dataSet.GetTAS());
        return timeRatios;
    }
    float AmingScore()
    {
        if (dataSet.GetReleasedArrows() == 0) currentAmingScore = 0;
        else currentAmingScore= dataSet.GetNumOfHits() / dataSet.GetReleasedArrows();
        return currentAmingScore;
    }
    float TotalImpulsivityScore()
    {
        if (TAR() == 0) currentImpulsivityScore = 1;
        else currentImpulsivityScore = (float)(1 / ((-TAR()) * ((Mathf.Log10(TIR()) - 1 + Mathf.Epsilon))));

        return currentImpulsivityScore;
    }
    float TotalImpulsivityScoreWithAming()
    {
        if (AmingScore() == 0) currentImpulsivityScoreWithAming = 1;
        else currentImpulsivityScoreWithAming = (float)(1 / ((-AmingScore()) * ((Mathf.Log10(TIR()) - 1 + Mathf.Epsilon))));
        return currentImpulsivityScoreWithAming;
    }

}

