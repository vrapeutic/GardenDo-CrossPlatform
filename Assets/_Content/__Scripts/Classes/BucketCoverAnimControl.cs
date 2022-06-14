﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;
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
        if (Statistics.android) OpenTheCoverRPC();
        /*NetworkManager.InvokeServerMethod("OpenTheCoverRPC", this.gameObject.name);*/
    }

    public void OpenTheCoverRPC()
    {
        coverAnimator.SetBool("OpenTheCover", true);
    }

    public void CloseTheCover()
    {
        if (Statistics.android)
            CloseTheCoverRPC();
        /* NetworkManager.InvokeServerMethod("CloseTheCoverRPC", this.gameObject.name);*/
    }

    public void CloseTheCoverRPC()
    {
        coverAnimator.SetBool("ColseTheCover", true);
    }
}
