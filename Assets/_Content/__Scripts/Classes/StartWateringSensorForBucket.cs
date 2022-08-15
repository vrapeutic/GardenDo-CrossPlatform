using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWateringSensorForBucket : MonoBehaviour
{
    [SerializeField] Flower myFlower;
     bool isBucketWatering;

    private void Awake()
    {
        if (!myFlower) myFlower = GetComponentInParent<Flower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bucket"))
        {          
            Debug.Log("Bucket has Entered the flower");
            isBucketWatering = true;
            myFlower.UpdateBucketWateringState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bucket"))
        {          
            Debug.Log("Bucket has Entered the flower");
            isBucketWatering = false;
            myFlower.UpdateBucketWateringState(false);
            // OnBucketExit(1);                                     
        }
    }

   
    public void ResetValues()
    {
        isBucketWatering = false;       
    }
   
}

