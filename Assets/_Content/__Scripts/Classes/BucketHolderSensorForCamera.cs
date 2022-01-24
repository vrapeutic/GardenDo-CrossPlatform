using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHolderSensorForCamera : MonoBehaviour
{
    // public static bool isPlayerLooking;
    [SerializeField] FillTheBucketAnimation fillTheBucketAnimation;
    [SerializeField] GameObject cube;
    
    private void Start()
    {
        if (!fillTheBucketAnimation) fillTheBucketAnimation = FindObjectOfType<FillTheBucketAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ///  isPlayerLooking = true;
            fillTheBucketAnimation.ChangePlayerISLookingState(true);
            Debug.Log("PLAYER FILLING");
          //  cube.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fillTheBucketAnimation.ChangePlayerISLookingState(false);
           // cube.SetActive(true);
        }
    }

    private void OnDisable()
    {
      //  fillTheBucketAnimation.ChangePlayerISLookingState(false);
    }
}
