using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TovaData : ScriptableObject
{
    #region ResponseTime Variables
    public bool isResponseTimer;
    public bool isDistractorResponseTimer;
    public bool totalNumOfTriesCountrEnabld;
    public bool totalNumOfDistractorHitCounterEnabled;
    public float totalNumOfTries;
    public float totalNumOfDistractorHit;
    public float totalResponseTime;
    public float responseWight = 0.5f;
    public float responseDistractorWight = 0.5f;
    #endregion

    #region ImpulsivityScore Variables
    public bool numOfTargetsCounterEnabled;
    public bool numofHitsCounterEnabled;
    public float totalNumOfTargets;
    public float numOfHits;
    public float totalImpsScore;
    public float totalImpsScoreWithAming;
    public float targetRatios;
    public float timeRatios;
    public float releasedArrows;
    public float lostLives;
    public bool isReleased;
    #endregion

    #region OmissionScore Variables
    public bool actualAttentionSpanCounterEnabled;
    public bool isDistractorEnabled;
    public float tpyicalTime;
    public float actualTimeSpan;
    public float totalOmissionScore;
    public float distractingTime;
    public float distractionEnduranceScore;
    #endregion

    #region PerformanceData Variables
    public string TargetDataListHights;
    public string TargetDataListPositions;
    public string TargetDataLisDirections;
    public string HandToolsDataListAngles;
    #endregion
    public float typicalTime; //closed or tipical time
    public float instructionsTime;
    public bool isSessionEnd;
    public bool isActionStarted = false;


}