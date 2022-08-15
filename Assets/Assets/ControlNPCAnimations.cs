using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class ControlNPCAnimations : MonoBehaviour
{
   // [SerializeField] Animator HussienAnim;
   /*
    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("PlayerKeepsLookingAnimRPC", invokationManager);
        NetworkManager.InvokeClientMethod("BravoYouhavePlantedAFlowerRPC", invokationManager);
        NetworkManager.InvokeClientMethod("YouHavePlantedAllFlowersRPC", invokationManager);
        NetworkManager.InvokeClientMethod("CallPlayerToWaterTheFlowerRPC", invokationManager);
        NetworkManager.InvokeClientMethod("ComeToTheWellRPC", invokationManager);
        NetworkManager.InvokeClientMethod("OpenTheBucketRPC", invokationManager);
        NetworkManager.InvokeClientMethod("CloseTheBucketRPC", invokationManager);
    }
    public void OpenTheBucket()
    {
        if (Statistics.android) NetworkManager.InvokeServerMethod("OpenTheBucketRPC", this.gameObject.name);
    }

    public void OpenTheBucketRPC()
    {
       if(ControlBucketCover.shallNPCTalk) SetAnimatorInt.instance.AnimatorSetIntger(18);
    }
    public void CloseTheBucket()
    {
        Debug.Log("CloseTheBucket");
        if (Statistics.android) NetworkManager.InvokeServerMethod("CloseTheBucketRPC", this.gameObject.name);
    }

    public void CloseTheBucketRPC()
    {
        Debug.Log("CloseTheBucketRPC");
        SetAnimatorInt.instance.AnimatorSetIntger(17);
    }
    public void ComeToTheWell()
    {
        if (Statistics.android) NetworkManager.InvokeServerMethod("ComeToTheWellRPC", this.gameObject.name);
    }

    public void ComeToTheWellRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(3);
    }

    public void PlayerKeepsLookingAnim()
    {
       if(Statistics.android) NetworkManager.InvokeServerMethod("PlayerKeepsLookingAnimRPC", this.gameObject.name);
    }

    public void PlayerKeepsLookingAnimRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(6);
    }

    public void BravoYouhavePlantedAFlower()
    {
        if (Statistics.android) NetworkManager.InvokeServerMethod("BravoYouhavePlantedAFlowerRPC", this.gameObject.name);
    }

    public void BravoYouhavePlantedAFlowerRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(11);
    }

    public void YouHavePlantedAllFlowers()
    {
        if (Statistics.android) NetworkManager.InvokeServerMethod("YouHavePlantedAllFlowersRPC", this.gameObject.name);
    }

    public void YouHavePlantedAllFlowersRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(14);
    }


    public void CallPlayerToWaterTheFlower()
    {
        if (Statistics.android) NetworkManager.InvokeServerMethod("CallPlayerToWaterTheFlowerRPC", this.gameObject.name);
    }

    public void CallPlayerToWaterTheFlowerRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(9);
    }*/
}
