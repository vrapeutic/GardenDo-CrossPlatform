using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tachyon;

public class FillTheBucketAnimation : MonoBehaviour
{
    WaitForSeconds seconds = new WaitForSeconds(0.2f);
    public Coroutine FillingTheBucketRoutine;
    [SerializeField]
    GameEvent taskStarted;
    [SerializeField]
    GameEvent taskStopped;
    private bool sfxIsPlayed = false;
    private bool startPlayingSFX = true;
    private bool startFillingTimer = false;
    private bool isBucketInPlace = false;
    private bool isPlayerLooking = false;
    private bool isFilling = false;
    [SerializeField] Animator waterAnim;
    // [SerializeField] ParticleSystem waterParticles;
    [SerializeField] AudioSource fillingTheBucketSFX;

    Statistics stats;
    private void Start()
    {

        stats = Statistics.instane;
        if (stats.isCompleteCourse)
        {
            //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
            //NetworkManager.InvokeClientMethod("PlayingWaterProcessRPC", invokationManager);
            //NetworkManager.InvokeClientMethod("StoppingWaterProcessRPC", invokationManager);
            waterAnim.enabled = false;
            FillingTheBucketRoutine = StartCoroutine(FillingTheBucket());
        }

    }

    private void Update()
    {
        if (startFillingTimer)
        {
            stats.wellSustained += Time.deltaTime;
            Debug.Log("Well Timer: " + stats.wellSustained);
        }
    }

    IEnumerator FillingTheBucket()
    {
        while (true)
        {
            yield return seconds;

            if (isBucketInPlace && isPlayerLooking)
            {
                Debug.Log("ready to fill the bucket");
                if (Statistics.android && !isFilling)
                {
                    PlayingWaterProcessRPC();
                    //NetworkManager.InvokeServerMethod("PlayingWaterProcessRPC", this.gameObject.name);
                    PlayingWaterProcessAndoid();
                    isFilling = true;
                }
            }
            else
            {
                if (Statistics.android && isFilling)
                {
                    StoppingWaterProcessRPC();
                  //  NetworkManager.InvokeServerMethod("StoppingWaterProcessRPC", this.gameObject.name);
                    StoppingWaterProcessAndroid();
                    isFilling = false;
                }
            }
        }
    }


    public void StoppingWaterProcessRPC()
    {
        //if (!Statistics.android)
        //{
            if (!startPlayingSFX)
            {
                sfxIsPlayed = true;
                fillingTheBucketSFX.Pause();
            }

            // waterParticles.enableEmission = false;
            startFillingTimer = false;
            waterAnim.SetFloat("speed", 0.0f);
        taskStopped.Raise();
        //}

    }

    public void StoppingWaterProcessAndroid()
    {
        if (!startPlayingSFX)
        {
            sfxIsPlayed = true;
            fillingTheBucketSFX.Pause();
        }

        // waterParticles.enableEmission = false;
        startFillingTimer = false;
        waterAnim.SetFloat("speed", 0.0f);
    }

    public void PlayingWaterProcessRPC()
    {
       // if (!Statistics.android)
        //{
            if (sfxIsPlayed == false)
            {
                fillingTheBucketSFX.Play();
                startPlayingSFX = false;
                sfxIsPlayed = true;
            }
            else
            {
                fillingTheBucketSFX.UnPause();
            }

            startFillingTimer = true;
            waterAnim.enabled = true;
            waterAnim.SetFloat("speed", 1.0f);
        taskStarted.Raise();
      //  }

    }

    public void PlayingWaterProcessAndoid()
    {

        if (sfxIsPlayed == false)
        {
            fillingTheBucketSFX.Play();
            startPlayingSFX = false;
            sfxIsPlayed = true;
        }
        else
        {
            fillingTheBucketSFX.UnPause();
        }

        startFillingTimer = true;
        waterAnim.enabled = true;
        waterAnim.SetFloat("speed", 1.0f);
    }

    public void ChangeBucketOnPlaceState(bool state)
    {
        isBucketInPlace = state;
    }
    public void ChangePlayerISLookingState(bool state)
    {
        isPlayerLooking = state;
    }


    private void OnDisable()
    {
        if (Statistics.android)
        {
            if (stats.isCompleteCourse) StopCoroutine(FillingTheBucketRoutine);
            startFillingTimer = false;
        }
    }
}