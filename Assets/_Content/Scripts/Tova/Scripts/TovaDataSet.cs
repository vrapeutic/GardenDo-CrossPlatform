

using System.Collections.Generic;

public class TovaDataSet : TovaData
{

    #region ResponseTime Data Set&Get

    public void SetResponseTimer(bool _isEnabled)
    {
        isResponseTimer = _isEnabled;
    }
    public bool GetResponseTimer()
    {
        return isResponseTimer;
    }
    public void SetDistractorResponseTimer(bool _isEnabled)
    {
        isDistractorResponseTimer = _isEnabled;
    }
    public bool GetDistractorResponseTimer()
    {
        return isDistractorResponseTimer;
    }
    public void SetNoOfTriesCounter(bool _isEnabled)
    {
        totalNumOfTriesCountrEnabld = _isEnabled;
    }
    public bool GetTotalNoOfTriesCounterState()
    {
        return totalNumOfTriesCountrEnabld;
    }
    public void SetNoOfDistractorHitsCounter(bool _isEnabled)
    {
        totalNumOfDistractorHitCounterEnabled = _isEnabled;
    }
    public bool GetTotalNoOfDistractorHitsCounterState()
    {
        return totalNumOfDistractorHitCounterEnabled;
    }
    public void SetTotalNumOfTries(int _tries)
    {
        totalNumOfTries = _tries;
    }
    public float GetTotalNumOfTries()
    {
        return totalNumOfTries;
    }
    public void SetTotalNumOfDistractorHit(int _hits)
    {
        totalNumOfDistractorHit = _hits;
    }
    public void SetResponseWight(float _wight)
    {
        responseWight = _wight;
    }
    public float GetResponseWight()
    {
        return responseWight;
    }
    public void SetResponseDistractorWight(float _dsWight)
    {
        responseDistractorWight = _dsWight;
    }
    public float GetResponseDistractorWight()
    {
        return responseDistractorWight;
    }
    public float GetTotalNumOfDistractorHit()
    {
        return totalNumOfDistractorHit;
    }
    public void SetTotalResponseTime(float _responsetime)
    {
        totalResponseTime = _responsetime;
    }
    public float GetTotalResponseTime()
    {
        return totalResponseTime;
    }
    #endregion

    #region Impulsivity_Score  Data Set&Get

    public void SetTargetsCounterEnabled(bool _isEnabled)
    {
        numOfTargetsCounterEnabled = _isEnabled;
    }
    public bool GetTargetsCounter()
    {
        return numOfTargetsCounterEnabled;
    }
    public void SetHitsCounterEnabled(bool _isEnabled)
    {
        numofHitsCounterEnabled = _isEnabled;
    }
    public bool GetHitsCounter()
    {
        return numofHitsCounterEnabled;
    }
    public void SetIsReleasedEnabled(bool _isEnabled)
    {
        isReleased = _isEnabled;
    }
    public bool GetIsReleasedState()
    {
        return isReleased;
    }
    public void SetTotalNumOfTargets(float _totalNumOfTargets)
    {
        totalNumOfTargets = _totalNumOfTargets;
    }
    public float GetTotalNumOfTargets()
    {
        return totalNumOfTargets;
    }
    public void SetNumOfHits(float _numOfHits)
    {
        numOfHits = _numOfHits;
    }
    public float GetNumOfHits()
    {
        return numOfHits;
    }
    public void SetTargetsRatios(float _Tar)
    {
        targetRatios = _Tar;
    }
    public float GetTargetRatios()
    {
        return targetRatios;
    }
    public void SetTimeRatios(float _Tir)
    {
        timeRatios = _Tir;
    }
    public void SetLives(float _live)
    {
        lostLives = _live;
    }
    public float GetLives()
    {
        return lostLives;
    }
    public void SetReleasedArrows(float _arrows)
    {
        releasedArrows = _arrows;
    }
    public float GetReleasedArrows()
    {
        return releasedArrows;
    }
    public float GetTimeRatios()
    {
        return timeRatios;
    }
    public void SetTotalImpsScore(float _impsScore)
    {
        totalImpsScore = _impsScore;
    }
    public float GetTotalImpsScore()
    {
        return totalImpsScore;
    }
    public void SetTotalImpsScoreWithAming(float _impsScore)
    {
        totalImpsScoreWithAming = _impsScore;
    }
    public float GetTotalImpsScoreWithAming()
    {
        return totalImpsScoreWithAming;
    }
    #endregion

    #region Omission_score  Data Set&Get
    public void SetActualTimeCounter(bool _isEnabled)
    {
        actualAttentionSpanCounterEnabled = _isEnabled;
    }
    public bool GetActualTimeSpanState()
    {
        return actualAttentionSpanCounterEnabled;
    }
    public void SetActualTime(float _AAS)
    {
        actualTimeSpan = _AAS;
    }
    public float GetActualTimeSpan()
    {
        return actualTimeSpan;
    }
    public void SetDistractingTime(float _TFD)
    {
        distractingTime = _TFD;
    }
    public float GetDistractingTime()
    {
        return distractingTime;
    }
    public void SetDistractorEnabled(bool _isEnabled)
    {
        isDistractorEnabled = _isEnabled;
    }
    public bool GetDistractorState()
    {
        return isDistractorEnabled;
    }
    public void SetTotalOmissionScore(float _omissionScore)
    {
        totalOmissionScore = _omissionScore;
    }
    public float GetTotalOmissionScore()
    {
        return totalOmissionScore;
    }
    public void SetDistractingScore(float _DES)
    {
        distractionEnduranceScore = _DES;
    }
    public float GetTotalDES()
    {
        return distractionEnduranceScore;
    }
    #endregion

    #region NewPerformanceData Set&Get
    public void SetTargetListDataHights(string list)
    {
        TargetDataListHights = list;
    }
    public string GetTargetDataListHights()
    {
        return TargetDataListHights;
    }
    public void SetTargetListDataDirections(string list)
    {
        TargetDataLisDirections = list;
    }
    public string GetTargetDataListDirections()
    {
        return TargetDataLisDirections;
    }
    public void SetTargetListDataPostions(string list)
    {
        TargetDataListPositions = list;
    }
    public string GetTargetDataListPositions()
    {
        return TargetDataListPositions;
    }
    public void SetIsActionStarted(bool _isActionStarted)
    {
        isActionStarted = _isActionStarted;
    }
    public bool GetIsActionStarted()
    {
        return isActionStarted;
    }

    public void SetHandToolsListDataAngles(string list)
    {
        HandToolsDataListAngles = list;
    }
    public string GetHandToolsDataList()
    {
        return HandToolsDataListAngles;
    }
#endregion

    public void SetTypicalTime(float _fixedTime)
    {
        typicalTime = _fixedTime;
    }
    public float GetTAS()
    {
        return typicalTime;
    }

    public void SetInstructionTime(float _insTime)
    {
        instructionsTime = _insTime;
    }
    public float GetInstructionTime()
    {
        return instructionsTime;
    }

    public void SetSessionEnd(bool _isEnded)
    {
        isSessionEnd = _isEnded;
    }
    public bool GetSessionEnd()
    {
        return isSessionEnd;
    }

}