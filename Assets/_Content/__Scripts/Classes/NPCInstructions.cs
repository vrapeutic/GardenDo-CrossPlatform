using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
public class NPCInstructions : MonoBehaviour
{

    [SerializeField]
    Animator npcAnimator;
    Statistics stats;
    int maxFlowerNumber;
    int flowerIndex;
    private void Start()
    {
        flowerIndex = 0;
        npcAnimator = this.GetComponent<Animator>();
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("TellThePlayerToHoldTheBucketRPC", invokationManager);
        NetworkManager.InvokeClientMethod("OnPlayerGrabbTheBucketRPC", invokationManager);
        NetworkManager.InvokeClientMethod("OnHandleDownRPC", invokationManager);
        NetworkManager.InvokeClientMethod("ReadyToWaterTheFlowerRPC", invokationManager);
        NetworkManager.InvokeClientMethod("PlayerPlantedFlowerRPC", invokationManager);
        NetworkManager.InvokeClientMethod("PlayerPlantedAllFlowersRPC", invokationManager);
        stats = Statistics.instane;
        maxFlowerNumber = stats.numberOfFlowers;
    }
    public void TellThePlayerToHoldTheBucket()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("TellThePlayerToHoldTheBucketRPC", this.gameObject.name);
            Debug.Log("tell the player to hold the bucket");
        }

        //tell the player to hold the bucket
    }

    public void OnPlayerGrabbTheBucket()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("OnPlayerGrabbTheBucketRPC", this.gameObject.name);
            Debug.Log("player grabs the bucket");
        }

    }

    public void OnHandleDown()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("OnHandleDownRPC", this.gameObject.name);
            Debug.Log("handle down");
        }


    }
    public void ReadyToWaterTheFlower()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("ReadyToWaterTheFlowerRPC", this.gameObject.name);
            Debug.Log("player ready to water the flower");
        }

    }

    public void PlayerPlanntedFlower()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("PlayerPlantedFlowerRPC", this.gameObject.name);
            Debug.Log("player planted flower");
        }
    }

    public void PlayerPlantedAllFlowers()
    {
        if (Statistics.android)
        {
            NetworkManager.InvokeServerMethod("PlayerPlantedAllFlowersRPC", this.gameObject.name);
            Debug.Log("player planted all flowers");
        }
    }

    private void SetAnimationClib(int clibInt)
    {
        npcAnimator.SetInteger("NPCAnimController", clibInt);
    }


    public void TellThePlayerToHoldTheBucketRPC()
    {
        Debug.Log("tell the player to hold the bucket rpc");
        SetAnimationClib(4);//tell the player to hold the bucket
    }

    public void OnPlayerGrabbTheBucketRPC()
    {
        SetAnimationClib(5); //tell the player to grab the handle
        Debug.Log("player grabs the bucket RPC");
    }

    public void OnHandleDownRPC()
    {
        SetAnimationClib(7); // tell the player to fill the bucket to the end;
        Debug.Log("on handle down RPC");
    }

    public void ReadyToWaterTheFlowerRPC()
    {
        SetAnimationClib(9);// let's water the flower
        Debug.Log("player ready to water the flower RPC");
        StartCoroutine(TellThePlayerToLookAtTheFlower());
    }

    public void PlayerPlantedFlowerRPC()
    {
        if (flowerIndex < (maxFlowerNumber - 1))
        {
            Debug.Log("player planted flower RPC");
            SetAnimationClib(11);// good job you planted a beautiful flower
            flowerIndex++;
        }

    }

    IEnumerator TellThePlayerToLookAtTheFlower()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("look at the flower RPC");
        SetAnimationClib(10);
        //look at the flower
    }

    public void PlayerPlantedAllFlowersRPC()
    {
        Debug.Log("player planted all the flower RPC");
        SetAnimationClib(14);//wow you've planted all these beautiful flowers;
    }

    public void StopAnimation()
    {
        SetAnimationClib(0);
    }
}
