using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
public class BucketCoverAnimControl : MonoBehaviour
{
    [SerializeField]
    Animator coverAnimator;

    private void Start()
    {
        if (!coverAnimator) coverAnimator = this.GetComponent<Animator>();
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("OpenTheCoverRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("CloseTheCoverRPC", invokationManager);
    }
    public void OpenTheCover()
    {
        OpenTheCoverRPC();
       // if (Statistics.android) NetworkManager.InvokeServerMethod("OpenTheCoverRPC", this.gameObject.name);
    }

    public void OpenTheCoverRPC()
    {
        coverAnimator.SetBool("OpenTheCover", true);
    }

    public void CloseTheCover()
    {
        CloseTheCoverRPC();
       // if (Statistics.android) NetworkManager.InvokeServerMethod("CloseTheCoverRPC", this.gameObject.name);
    }

    public void CloseTheCoverRPC()
    {
        coverAnimator.SetBool("ColseTheCover", true);
    }
}
