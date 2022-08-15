using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class ControlBucketCover : MonoBehaviour
{
    WaitForSeconds seconds = new WaitForSeconds(0.2f);
  

    [SerializeField]
    private Animator bucketCover;
    [SerializeField]
    private Animator bucketButton;
    public static bool isCoverOpened; //to play the correct cover animation

    public static bool isOpen; // to lock opening 
    public static bool isClose = true; // to lock closing
    public static bool shallNPCTalk;

    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("OpenBucketCoverRPC", invokationManager);
        NetworkManager.InvokeClientMethod("CloseBucketCoverRPC", invokationManager);
        isCoverOpened = false;
        shallNPCTalk = true;
    }

    private void OnEnable()
    {
        isOpen = false;
    }


  

    public void OpenBucketCover()
    {
        OpenBucketCoverRPC();
       // if (Statistics.android) NetworkManager.InvokeServerMethod("OpenBucketCoverRPC", this.gameObject.name);
    }

    public void OpenBucketCoverRPC()
    {
        //SetAnimatorInt.instance.AnimatorSetIntger(6);
        bucketCover.SetTrigger("OpenTheCover");
        bucketButton.SetTrigger("OpenTheButton");
        isCoverOpened = true;
        isOpen = true;
        shallNPCTalk = false;
    }

    public void CloseBucketCover()
    {
        CloseBucketCoverRPC();
        //if (Statistics.android) NetworkManager.InvokeServerMethod("CloseBucketCoverRPC", this.gameObject.name);
    }

    public void CloseBucketCoverRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(0);
        SetAnimatorParentInt.instance.AnimatorSetIntger(1);
        bucketCover.SetTrigger("ColseTheCover");
        bucketButton.SetTrigger("CloseTheButton");
        isCoverOpened = false;
        isClose = true;
    }

    public void ControlBucketClosing(bool _isClose)
    {
        isClose = _isClose;
    }
    public void ControlBucketOpenning(bool _isOpen)
    {
        isOpen = _isOpen;
    }
}
