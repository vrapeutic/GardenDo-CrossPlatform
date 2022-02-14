using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tachyon;

public class FillTheBucketAnimation : MonoBehaviour
{
    [SerializeField]
    GameEvent taskStarted;
    [SerializeField]
    GameEvent taskStopped;
    WaitForSeconds seconds = new WaitForSeconds(0.2f);
    public Coroutine FillingTheBucketRoutine;

    private bool sfxIsPlayed = false;
    private bool startPlayingSFX = true;
    private bool startFillingTimer = false;
    private bool isBucketInPlace = false;
    private bool isPlayerLooking = false;
    [SerializeField] Animator waterAnim;
    // [SerializeField] ParticleSystem waterParticles;
    [SerializeField] AudioSource fillingTheBucketSFX;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("PlayingWaterProcessRPC", invokationManager);
        NetworkManager.InvokeClientMethod("StoppingWaterProcess", invokationManager);
        waterAnim.enabled = false;
        if (Statistics.android) FillingTheBucketRoutine = StartCoroutine(FillingTheBucket());
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
                if (Statistics.android) NetworkManager.InvokeServerMethod("PlayingWaterProcessRPC", this.gameObject.name);
            }
            else
            {
                if (Statistics.android) NetworkManager.InvokeServerMethod("StoppingWaterProcess", this.gameObject.name);
            }
        }
    }


    public void StoppingWaterProcess()
    {
        if (!startPlayingSFX)
        {
            sfxIsPlayed = true;
            fillingTheBucketSFX.Pause();
        }
        startFillingTimer = false;
        waterAnim.SetFloat("speed", 0.0f);
        taskStopped.Raise();    
    }


    public void PlayingWaterProcessRPC()
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
        taskStarted.Raise();
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
            StopCoroutine(FillingTheBucketRoutine);
            startFillingTimer = false;
        }
    }
}
