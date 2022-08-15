using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmissionScoreHandling : MonoBehaviour
{
    TovaDataSet dataSet;
    [SerializeField]
    float instructionTimeFullCourse;
    [SerializeField]
    float instructionTimeWatering;

    float TAS;
    private void Start()
    {
        dataSet = TovaDataGet.ReturnTovaData();
        if (Statistics.instane.isCompleteCourse)
        {
            TovaDataGet.ReturnTovaData().SetInstructionTime(instructionTimeFullCourse);
            TAS = Statistics.instane.totalFlowerGrowth + TovaDataGet.ReturnTovaData().GetInstructionTime();
        }
            
        else
        {
            TovaDataGet.ReturnTovaData().SetInstructionTime(instructionTimeWatering);
            TAS = Statistics.instane.totalFlowerGrowth + TovaDataGet.ReturnTovaData().GetInstructionTime();
        }
           

        Debug.Log("TAS ="+TAS);
        dataSet.SetTypicalTime(TAS);
        if (Statistics.instane.level != 1)
            dataSet.SetDistractorEnabled(true);
    }
    private void TestInit()
    {
        Statistics.instane.totalFlowerGrowth = 40;
    }
    public void TaskStarted()
    {
        dataSet.SetActualTimeCounter(true);
    }
    public void TaskStopped()
    {
        //stop time calculation
        dataSet.SetActualTimeCounter(false);
    }

    
    public void AllTaskFinished()
    {
        //calculate omission score
        dataSet.SetSessionEnd(true);
    }
}
