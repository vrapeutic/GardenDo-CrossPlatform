using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class BucketFillingState : MonoBehaviour
{
  
    bool bucketIsFull = false;
    [SerializeField] GameEvent bucketIsFullEvent;
  
    // [SerializeField] Animator HussienAnim;
    
   
   // [SerializeField] ParticleSystem waterParticles;
    [SerializeField] Animator waterLevelAnim;
    [SerializeField] AudioSource waterSFX;

    private void Start()
    {
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("OnBucketIsFullRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("StartFillingRPC", invokationManager);
    }

   
  

    public void OnBucketIsFull()
    {
        OnBucketIsFullRPC();
       //if (Statistics.android) NetworkManager.InvokeServerMethod("OnBucketIsFullRPC", this.gameObject.name);
    }

    public void OnBucketIsFullRPC()
    {

        bucketIsFullEvent.Raise();
        waterLevelAnim.speed = 0f;
        waterSFX.Stop();
       
       // SetAnimatorInt.instance.AnimatorSetIntger(8);
    }

    public void StartFilling()
    {
        StartFillingRPC();
       // if (Statistics.android) NetworkManager.InvokeServerMethod("StartFillingRPC", this.gameObject.name);
        
    }

    public void StartFillingRPC()
    {
        //SetAnimatorInt.instance.AnimatorSetIntger(7);
    }
}
