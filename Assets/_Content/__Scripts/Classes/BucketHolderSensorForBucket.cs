using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHolderSensorForBucket : MonoBehaviour
{
    
    
    [SerializeField] FillTheBucketAnimation fillTheBucketAnimation;
    [SerializeField] GameObject cube;
    private void Start()
    {
        if (!fillTheBucketAnimation) fillTheBucketAnimation = FindObjectOfType<FillTheBucketAnimation>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BucketBody"))
        {
            //cube.SetActive(false);
            fillTheBucketAnimation.ChangeBucketOnPlaceState(true);
            Debug.Log("bucket in place for filling");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BucketBody"))
        {
            // isBucketInPlace = false;
          //  cube.SetActive(true);
            Debug.Log("bucket out of place for filling");
            fillTheBucketAnimation.ChangeBucketOnPlaceState(false);
        }
    }

    
}
