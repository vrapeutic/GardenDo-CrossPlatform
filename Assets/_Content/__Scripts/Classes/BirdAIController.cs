using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAIController : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    int pointsIndex = 0;
    int flowerIndex = 1;

    void MoveToNextPoint() { }
    void BirdReachesFlower() { 
    }

    bool CanBidDistract() { return false; }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wayPoint")) {
            pointsIndex++;
            MoveToNextPoint();
        }
        else
        {
            BirdReachesFlower();
        }
    }

    public void OnFLowerFinished()
    {
        flowerIndex++;
    }
}
