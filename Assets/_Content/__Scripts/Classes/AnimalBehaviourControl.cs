using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;
public class AnimalBehaviourControl : MonoBehaviour
{
    [SerializeField]SetAnimalAnimatorInt parentAnimatorInt;
    [SerializeField] Animator waterLevelAnimator;
    [SerializeField] ParticleSystem waterParticleSystem;
    [SerializeField] AudioSource waterAudioSource;
    //[SerializeField] AnimatorTrigger animatorTrigger;
    private bool isFilled ;
    private bool isWaterSFXPlaying = false;
    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
        //try
        //{
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("StartFillingRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("StopFillingRPC", invokationManager);
        //}
        //catch
        //{
        //    Debug.Log("Animal control init problem");
        //}
      
        isFilled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " collided animal");
        if (other.CompareTag("animal") || other.CompareTag("Bucket"))
        {
            Debug.Log("animal trigger working");
            
            if (!isFilled && parentAnimatorInt.canFill)
            {
                if (Statistics.android) StartFilling();
            }
        }    
    }
    private void OnTriggerExit(Collider other)
    {
       
            if(other.CompareTag("animal") || other.CompareTag("Bucket"))
            {
                if (parentAnimatorInt.canFill) StopFilling();
                Debug.Log("Exit trigger animal");
            }
           
       
    }

    public void ActivateCollider()
    {
        this.GetComponent<Collider>().enabled = true;
        Debug.Log("Collider work");
    }
    
    private void StartFilling()
    {
        
        if (Statistics.android)
        {
            StartFillingRPC();
          //NetworkManager.InvokeServerMethod("StartFillingRPC", this.gameObject.name);
            Debug.Log("Start filling");
        }
    }
    public void StartFillingRPC()
    {
        Debug.Log("Start filling RPC");
        waterLevelAnimator.enabled = true;
        waterLevelAnimator.SetFloat("speed", 0.6f);
        //waterParticleSystem.Play();
        waterParticleSystem.enableEmission = true;
        if (!isWaterSFXPlaying)
        {
            waterAudioSource.Play();
            isWaterSFXPlaying = true;
        }
        //mainAnimator.SetFloat("animSpeed", animSpeedControl);
        
        //waterAudioSource.Play();
    }
    private void StopFilling()
    {
        if(Statistics.android)
        {
            StopFillingRPC();
            //NetworkManager.InvokeServerMethod("StopFillingRPC", this.gameObject.name);
            Debug.Log("Stop filling");
        }
    }
    public void StopFillingRPC()
    {
        Debug.Log("Stop filling rpc");
        waterLevelAnimator.SetFloat("speed", 0);
        //waterParticleSystem.Stop();
        waterParticleSystem.enableEmission = false;
        if (isWaterSFXPlaying)
        {
            waterAudioSource.Stop();
            isWaterSFXPlaying = false;
        }
        //animatorTrigger.WaterPlarticleSystemEmission(false);
        //waterAudioSource.Stop();

    }
    public void FinishFilling()
    {
        Debug.Log("Finish filling");
        isFilled = true;
        this.GetComponent<Collider>().enabled = false;
        this.gameObject.SetActive(false);
        StopFillingRPC();
        parentAnimatorInt.StopDistraction();
    }
}
