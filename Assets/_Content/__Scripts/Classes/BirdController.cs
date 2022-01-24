using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class BirdController : MonoBehaviour
{

    public static bool isBirdOnFlower;
    [SerializeField] Animator bird;
    [SerializeField] Animator birdParent;

    Statistics stats;
    private void Start()
    {
        isBirdOnFlower = false;
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("IdleBirdAnimRPC", invokationManager);
        stats = Statistics.instane;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            Debug.Log("Bird On Flower!");
            stats.birdFlyingResponseTimeCounterBegin = true;
            isBirdOnFlower = true;
            IdleBirdAnim();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            stats.birdFlyingResponseTimeCounterBegin = false;
        }
    }

    private void IdleBirdAnim()
    {
        if (Statistics.android) { NetworkManager.InvokeServerMethod("IdleBirdAnimRPC", this.gameObject.name); }
    }

    public void IdleBirdAnimRPC()
    {
        birdParent.SetFloat("speed", 0.0f);
        bird.SetInteger("BirdAnimation", 1);
    }

}
