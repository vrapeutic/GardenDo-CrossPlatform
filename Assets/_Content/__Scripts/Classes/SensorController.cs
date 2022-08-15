using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour
{
    [SerializeField]
    GameObject[] filllingTheBucketSensors;
    [SerializeField]
    GameObject playerNearTheWellSensor;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        if (stats.isCompleteCourse)
        {
            playerNearTheWellSensor.SetActive(true);
        }
    }
    public void GetReadyToFillTheBucket()
    {
        for (int i = 0; i < filllingTheBucketSensors.Length; i++)
        {
            filllingTheBucketSensors[i].SetActive(true);
        }
    }



    public void CloseTheFillingSensors()
    {
        for (int i = 0; i < filllingTheBucketSensors.Length; i++)
        {
            filllingTheBucketSensors[i].SetActive(false);
        }
    }


}
