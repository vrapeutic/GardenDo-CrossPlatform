using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;

public class BirdController : MonoBehaviour
{
    TovaDataSet dataSet;
    public static bool isBirdOnFlower;
    //public static bool isEnabledDistractor = false;
    [SerializeField] Animator bird;
    [SerializeField] Animator birdParent;

    Statistics stats;
    private void Start()
    {
        dataSet = TovaDataGet.ReturnTovaData();
        isBirdOnFlower = false;
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("IdleBirdAnimRPC", invokationManager);
        stats = Statistics.instane;
    }

    //private void Update()
    //{
    //    if (isEnabledDistractor)
    //    {
    //        bird.GetComponent<BoxCollider>().enabled = false;
    //    } else
    //    {
    //        bird.GetComponent<BoxCollider>().enabled = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            Debug.Log("Bird On Flower!");
            stats.birdFlyingResponseTimeCounterBegin = true;
            isBirdOnFlower = true;
            IdleBirdAnim();
            LevelsController.isBlockingInteraction = true;
            //dataSet.SetDistractorResponseTimer(true);
            //dataSet.SetNoOfDistractorHitsCounter(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            stats.birdFlyingResponseTimeCounterBegin = false;
            //dataSet.SetDistractorResponseTimer(false);
        }
    }

    private void IdleBirdAnim()
    {
        if (Statistics.android) {
            IdleBirdAnimRPC();
            //NetworkManager.InvokeServerMethod("IdleBirdAnimRPC", this.gameObject.name); 
        }
    }

    public void IdleBirdAnimRPC()
    {
        birdParent.SetFloat("speed", 0.0f);
        bird.SetInteger("BirdAnimation", 1);
    }

}
