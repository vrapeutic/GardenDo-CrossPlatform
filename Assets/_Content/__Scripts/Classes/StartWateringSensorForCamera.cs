using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWateringSensorForCamera : MonoBehaviour
{
    [SerializeField] Flower myFlower;

    public bool isPlayerLooking;
    public static int interruptionThreshold = 0;


    private float interruptionCounter;
    private bool isInterrupted;

    //public static event Action<int> OnEyeEnter = delegate { };
    // public static event Action<int> OnEyeExit = delegate { };
    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        if (!myFlower) myFlower = this.GetComponentInParent<Flower>();
    }
    private void Update()
    {
        if (isInterrupted)
        {
            interruptionCounter += Time.deltaTime;
            if (interruptionCounter >= 3)
            {
                interruptionThreshold++;
                //  Debug.Log("TaR : Interruption Threshold : " + interruptionThreshold);
                OnExceedInerruptionThreshold();
                isInterrupted = false;
            }
            // if (interruptionCounter % 1 < 0.02) Debug.Log("Interruption Counter: " + interruptionCounter);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player camera has Entered flower1");
            isPlayerLooking = true;
            interruptionCounter = 0;
            isInterrupted = false;
            myFlower.UpdateLookingState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player camera exit flower");
            isInterrupted = true;
            isPlayerLooking = false;
            myFlower.UpdateLookingState(false);
            // OnEyeExit(1);                                                   
        }
    }

    public void ResetValues()
    {
        isPlayerLooking = false;
        isInterrupted = false;
        interruptionThreshold = 0;
        interruptionCounter = 0;
        // Debug.Log("Reset interruption count = " + interruptionThreshold);
    }

    public void OnExceedInerruptionThreshold()
    {
        if (interruptionThreshold == 3)
        {
            stats.tasksWithLimitiedInterruptions++;

        }
        Debug.Log("TaR : Task with limited interruption : " + stats.tasksWithLimitiedInterruptions);
    }


}
