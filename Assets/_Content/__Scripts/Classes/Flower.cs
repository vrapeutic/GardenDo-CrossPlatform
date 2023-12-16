using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject cameraLookingSensor;
    [SerializeField] GameObject bucketWateringSensor;
    [SerializeField] Animator myAnimator;
    [SerializeField] GameObject myFootStep;
    [SerializeField] GameObject myBird;
    [SerializeField] GameEvent flowerFinishedEvent;
    private bool isPlayerLooking;
    private bool isBucketWatering;
    private float flowerWateringTime;
    private System.DateTime flowerStartTime;
    private System.DateTime flowerEndTime;

    private void Awake()
    {
        if (!cameraLookingSensor) cameraLookingSensor = GetComponentInChildren<StartWateringSensorForCamera>().gameObject;
        if (!bucketWateringSensor) bucketWateringSensor = GetComponentInChildren<StartWateringSensorForBucket>().gameObject;
        if (!myAnimator) myAnimator = GetComponent<Animator>();
        if (!myFootStep) myFootStep = GetComponentInChildren<Step>().gameObject;
        if (!myBird) myBird = GetComponentInChildren<BirdController>().gameObject;
    }

    private void Update()
    {
        flowerWateringTime += Time.deltaTime;
    }

    public void GetReadyForWatering()
    {
        Debug.Log("Flower enable its colliders ");
        cameraLookingSensor.SetActive(true);
        cameraLookingSensor.GetComponent<Collider>().enabled = true;
        bucketWateringSensor.SetActive(true);
        bucketWateringSensor.GetComponent<Collider>().enabled = true;
        myFootStep.SetActive(true);
        myAnimator.enabled = true;
        myAnimator.speed = 1;
        myBird.GetComponent<Collider>().enabled = true;
        flowerWateringTime = 0;
        flowerStartTime = System.DateTime.Now;
    }
    public void FinishWatering()
    {
        Debug.Log("Close sensor colliders ");
        myBird.GetComponent<Collider>().enabled = false;
        myFootStep.SetActive(false);
        myAnimator.speed = 0;
        bucketWateringSensor.GetComponent<Collider>().enabled = false;
        cameraLookingSensor.GetComponent<Collider>().enabled = false;
        bucketWateringSensor.SetActive(false);
        cameraLookingSensor.SetActive(false);
        myAnimator.enabled = false;
        cameraLookingSensor.GetComponent<StartWateringSensorForCamera>().ResetValues();
        bucketWateringSensor.GetComponent<StartWateringSensorForBucket>().ResetValues();

        //CSVWriter.Instance.WriteFlowerWateringTime(flowerWateringTime.ToString());
        flowerEndTime = System.DateTime.Now;
        CSVWriter.Instance.SaveFlowerStartAndEndTimes(flowerStartTime, flowerEndTime);

    }

    public void UpdateLookingState(bool _isPlayerLooking)
    {
        Debug.Log("is player looking updated");
        isPlayerLooking = _isPlayerLooking;
    }
    public void UpdateBucketWateringState(bool _isBucketWatering)
    {
        Debug.Log("is bucket watering updated");
        isBucketWatering = _isBucketWatering;
    }
    public bool GetCameraLookingState()
    {
        return isPlayerLooking;
    }
    public bool GetBucketWateringState()
    {
        return isBucketWatering;
    }

    public void FlowerFinished()
    {
        myAnimator.enabled = false;
        FinishWatering();
        flowerFinishedEvent.Raise();
    }
}
