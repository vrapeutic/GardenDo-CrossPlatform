

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
    public void SetTargetListDataDirections_X(string list)
    {
        TargetDataLisDirections_X = list;
    }
    public string GetTargetDataListDirections_X()
    {
        return TargetDataLisDirections_X;
    }
    public void SetTargetListDataDirections_Y(string list)
    {
        TargetDataLisDirections_Y = list;
    }
    public string GetTargetDataListDirections_Y()
    {
        return TargetDataLisDirections_Y;
    }
    public void SetTargetListDataDirections_Z(string list)
    {
        TargetDataLisDirections_Z = list;
    }
    public string GetTargetDataListDirections_Z()
    {
        return TargetDataLisDirections_Z;
    }
    public void SetTargetListDataPostions(string list)
    {
        TargetDataListPositions = list;
    }
    public string GetTargetDataListPositions()
    {
        return TargetDataListPositions;
    }
    public void SetTargetListDataPostions_X(string _xList)
    {
        TargetDataListPositions_X = _xList;
    }
    public string GetTargetDataListPositions_X()
    {
        return TargetDataListPositions_X;
    }
    public void SetTargetListDataPostions_Y(string _yList)
    {
        TargetDataListPositions_Y = _yList;
    }
    public string GetTargetDataListPositions_Y()
    {
        return TargetDataListPositions_Y;
    }
    public void SetTargetListDataPostions_Z(string _zList)
    {
        TargetDataListPositions_Z = _zList;
    }
    public string GetTargetDataListPositions_Z()
    {
        return TargetDataListPositions_Z;
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

    public void SetMax_Height(float _max)
    {
        max_Height = _max;
    }
    public void SetMin_Height(float _min)
    {
        min_Height = _min;
    }
    public void SetAver_Height(float _aver)
    {
        aver_Height=_aver;
    }
    public void SetTargetCount(float _Count)
    {
        targetCount = _Count;
    }
    public float GetMax_Height()
    {
       return max_Height;
    }
    public float GetMin_Height()
    {
        return min_Height;
    }
    public float GetAver_Height()
    {
        return aver_Height;
    }
    public float GetTarget_Count()
    {
        return targetCount;
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