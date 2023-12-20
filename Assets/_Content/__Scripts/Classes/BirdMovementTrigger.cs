using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class BirdMovementTrigger : MonoBehaviour
{
    [SerializeField] Animator bird;
    [SerializeField] Animator birdParent;

    Statistics stats;
    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("FlyingBirdAnimRPC", invokationManager);
        stats = Statistics.instane;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Bird flying away from Flower!");
            if (BirdController.isBirdOnFlower)
            {
                stats.birdFlyingResponseTimes++;
                Debug.Log("Bird should fly");
                Debug.Log("Response Time : Bird Response Times : " + stats.birdFlyingResponseTimes);
                BirdController.isBirdOnFlower = false;
                bird.gameObject.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("FIXED distractor: " + this.gameObject.name + ", Time: " + LevelsController.blockingTimer);
                CSVWriter.Instance.SaveDistractorBlockingTime(this.gameObject.name, System.Math.Round((decimal)LevelsController.blockingTimer, 2).ToString());
                LevelsController.DidInteracttWithDistractor();
                FlyingBirdAnim();
            }
        }
    }

    private void FlyingBirdAnim()
    {
        if (Statistics.android)  FlyingBirdAnimRPC();// NetworkManager.InvokeServerMethod("FlyingBirdAnimRPC", this.gameObject.name); }
    }

    public void FlyingBirdAnimRPC()
    {
        Debug.Log("bird animation function called");
        birdParent.SetFloat("speed", 1.0f);
        bird.SetInteger("BirdAnimation", 0);
    }
}
