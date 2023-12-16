using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;
using System;

public class AnimatorTrigger : MonoBehaviour
{

    [SerializeField] Flower[] flowers;
    [SerializeField]
    private Flower currentFlower;
    [SerializeField]
    private int flowerIndex;
    [SerializeField]
    GameEvent newFlowerStarted;
    [SerializeField]
    GameEvent taskStarted;
    [SerializeField]
    GameEvent taskStopped;
    Animator flowerAnimator;

    private float finalGrowthSpeed;
    private float currentClipTime;
    bool isNewFlower = false;
    private bool emssion;
    private bool sfxIsPlayed = false;
    private bool startPlayingSFX = true;
    private bool stopReverseAnim = false;
    private bool isWatering = false;
    public Coroutine currentCoroutine;

    AnimatorStateInfo animationState;
    AnimatorClipInfo[] myAnimatorClip;

    WaitForSeconds waitingSeconds = new WaitForSeconds(0.2f);
    // [SerializeField] Animator HussienAnim;
    [SerializeField] ParticleSystem waterParticles;
    //[SerializeField] GameObject callPlayerToWaterTheFlower;
    // [SerializeField] GameObject setGrowthPeriod;
    [SerializeField] AudioSource wateringFlowersSFX;


    private float flowerInteruptionTime = 0;
    private bool startInterruptionTimer = false;
    private bool didTryToWaterAtleastOnce = false;

    private bool isFlower = false;
    private bool startFlowerTimer = false;

    Statistics stats;

    void Start()
    {
        stats = Statistics.instane;
        Debug.Log("Animator trigger is started");
        flowerIndex = 0;
        UpdateCurrentFlower();
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("FlowerGrowingUpRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("FlowerReverseRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("WaterPlarticleSystemEmissionRPC", invokationManager);
        if (Statistics.android) currentCoroutine = StartCoroutine(WaterTheFlowers());
    }

    private void Update()
    {
        if (startFlowerTimer)
        {
            stats.flowerSustained += Time.deltaTime;
        }

        if (!stopReverseAnim)
        {
            flowerAnimator = flowers[flowerIndex].GetComponent<Animator>();
            animationState = flowerAnimator.GetCurrentAnimatorStateInfo(0);
            myAnimatorClip = flowerAnimator.GetCurrentAnimatorClipInfo(0);
            currentClipTime = myAnimatorClip[0].clip.length * (animationState.normalizedTime % 1);
            if (currentClipTime <= 0)
            {
                flowerAnimator.SetFloat("speed", 0f);
                currentClipTime = 0f;
                stopReverseAnim = true;
            }
        }

        if (startInterruptionTimer && didTryToWaterAtleastOnce)
        {
            flowerInteruptionTime += Time.deltaTime;
        }
    }


    IEnumerator WaterTheFlowers()
    {
        Debug.Log("Start Coroutine Watering");
        if (!currentFlower) GetReadyForFirstWatering();

        while (true)
        {
            yield return waitingSeconds;

            if (currentFlower.GetBucketWateringState() && currentFlower.GetCameraLookingState() && !ResetPotController.isPotKnockedOver
                && !WavingSensorController.areChildrenWaving && !BirdController.isBirdOnFlower && !SetAnimalAnimatorInt.isAnimalDistracting)
            {
                Debug.Log("enter condition to water  flower");
                startFlowerTimer = true;
                isFlower = true;
                if (!isWatering)
                {
                    FlowerGrowingUp(flowerIndex);
                    startInterruptionTimer = false;
                    didTryToWaterAtleastOnce = true;
                    if (flowerInteruptionTime >= 0.1)
                    {
                        //CSVWriter.Instance.WriteFlowerInteruptionTime(flowerInteruptionTime.ToString());
                        Debug.Log("INTINT = " + flowerInteruptionTime);
                        CSVWriter.Instance.WriteFlowerInteruptionTimes((Math.Round((decimal)flowerInteruptionTime, 2)).ToString());
                    }
                }
                isWatering = true;
            }
            else if (isFlower)
            {
                startFlowerTimer = false;
                if (isWatering)
                {
                    FlowerReverse(flowerIndex);
                    if (didTryToWaterAtleastOnce)
                    {
                        flowerInteruptionTime = 0;
                        Debug.Log("STARTED INTINT");
                        startInterruptionTimer = true;
                    }
                }
                isWatering = false;
            }
        }
    }

    private void FlowerGrowingUp(int _currrentFlowerIndix)
    {
        if (Statistics.android)
        {
            FlowerGrowingUpRPC(_currrentFlowerIndix);
            //NetworkManager.InvokeServerMethod("FlowerGrowingUpRPC", this.gameObject.name, _currrentFlowerIndix);
            //FlowerGrowingUpAndroid(_currrentFlowerIndix);
        }
    }

    private void FlowerGrowingUpAndroid(int _currrentFlowerIndix)
    {
        flowerAnimator = flowers[_currrentFlowerIndix].GetComponent<Animator>();
        stopReverseAnim = false;
        if (isNewFlower == true)
        {
            isNewFlower = false;
            newFlowerStarted.Raise();
        }

        if (sfxIsPlayed == false)
        {
            Debug.Log("SFX Is Played");
            wateringFlowersSFX.Play();
            startPlayingSFX = false;
            sfxIsPlayed = true;
        }
        else
        {
            wateringFlowersSFX.UnPause();
        }

        finalGrowthSpeed = stats.growthSpeed;

        if (CallPlayerToWateraFlower.isPlayerWateringTheFlower == false)
        {
            stats.wateringResponseTimeCounterBegin = false;
            stats.wateringResponseTimes++;
            Debug.Log("Response Time : Watering Response Times : " + stats.wateringResponseTimes);
            SetAnimatorInt.instance.AnimatorSetIntger(10);
            //  callPlayerToWaterTheFlower.GetComponent<CheckIntervals>().check = true;
            CallPlayerToWateraFlower.isPlayerWateringTheFlower = true;
        }

        WaterPlarticleSystemEmission(true);
        flowerAnimator.enabled = true;
        flowerAnimator.SetFloat("speed", 1.0f / finalGrowthSpeed);
    }

    public void FlowerGrowingUpRPC(int _currrentFlowerIndix)
    {
        //if (!Statistics.android)
        //{
            flowerAnimator = flowers[_currrentFlowerIndix].GetComponent<Animator>();
            stopReverseAnim = true;
        //if (flowerInteruptionTime >= 0.1)
        //{
        //    CSVWriter.Instance.WriteFlowerInteruptionTime(flowerInteruptionTime.ToString());
        //    Debug.Log("INTINT = " + flowerInteruptionTime);
        //}
        //flowerInteruptionTime = 0;
        //shouldCountInteruptionTime = false;

        if (isNewFlower == true)
            {
                isNewFlower = false;
                newFlowerStarted.Raise();
            }

            if (sfxIsPlayed == false)
            {
                Debug.Log("SFX Is Played");
                wateringFlowersSFX.Play();
                startPlayingSFX = false;
                sfxIsPlayed = true;
            }
            else
            {
                wateringFlowersSFX.UnPause();
            }

            finalGrowthSpeed = stats.growthSpeed;

            if (CallPlayerToWateraFlower.isPlayerWateringTheFlower == false)
            {
                stats.wateringResponseTimeCounterBegin = false;
                stats.wateringResponseTimes++;
                Debug.Log("Response Time : Watering Response Times : " + stats.wateringResponseTimes);
                SetAnimatorInt.instance.AnimatorSetIntger(10);
                //  callPlayerToWaterTheFlower.GetComponent<CheckIntervals>().check = true;
                CallPlayerToWateraFlower.isPlayerWateringTheFlower = true;
            }

            WaterPlarticleSystemEmission(true);
            flowerAnimator.enabled = true;
            flowerAnimator.SetFloat("speed", 1.0f / finalGrowthSpeed);
        taskStarted.Raise();
        //}

    }



    public void FlowerReverse(int _currentFlowerIndex)
    {
        if (Statistics.android)
        {
            FlowerReverseRPC(_currentFlowerIndex);
            //NetworkManager.InvokeServerMethod("FlowerReverseRPC", this.gameObject.name, _currentFlowerIndex);
            //FlowerReverseAndroid(_currentFlowerIndex);
        }
    }

    private void FlowerReverseAndroid(int currentFlowerIndex)
    {
        flowerAnimator = flowers[currentFlowerIndex].GetComponent<Animator>();

        if (!startPlayingSFX)
        {
            wateringFlowersSFX.Pause();
        }

        WaterPlarticleSystemEmission(false);
        flowerAnimator.SetFloat("speed", -1.0f / finalGrowthSpeed);

        animationState = flowerAnimator.GetCurrentAnimatorStateInfo(0);
        myAnimatorClip = flowerAnimator.GetCurrentAnimatorClipInfo(0);
        currentClipTime = myAnimatorClip[0].clip.length * animationState.normalizedTime;

        if (currentClipTime <= 0.5f)
        {
            flowerAnimator.SetFloat("speed", 0f);
            currentClipTime = 0f;
            stopReverseAnim = true;
        }
    }

    public void FlowerReverseRPC(int _currentFlowerIndex)
    {
        //  if (!Statistics.android)
        // {
        taskStopped.Raise();
        stopReverseAnim = false;
        //if (flowerInteruptionTime >= 0.1)
        //{
        //    CSVWriter.Instance.WriteFlowerInteruptionTime(flowerInteruptionTime.ToString());
        //}
        //flowerInteruptionTime = 0;
        //startInterruptionTimer = true;
        flowerAnimator = flowers[_currentFlowerIndex].GetComponent<Animator>();

            if (!startPlayingSFX)
            {
                wateringFlowersSFX.Pause();
            }

            WaterPlarticleSystemEmission(false);
        flowerAnimator.SetFloat("speed", -1.0f / finalGrowthSpeed);
        ////flowerAnimator.StartPlayback();

        //animationState = flowerAnimator.GetCurrentAnimatorStateInfo(0);
        //    myAnimatorClip = flowerAnimator.GetCurrentAnimatorClipInfo(0);
        //    currentClipTime = myAnimatorClip[0].clip.length * (animationState.normalizedTime % 1);

        //    if (currentClipTime < 0)
        //    {
        //        flowerAnimator.SetFloat("speed", 0f);
        //        currentClipTime = 0f;
        //        stopReverseAnim = true;
        //    }
    //    }
        //Debug.Log("Flower reverse");

    }

    public void WaterPlarticleSystemEmission(bool _emssion)
    {
        if (Statistics.android)
        {
            WaterPlarticleSystemEmissionRPC(_emssion);
            //NetworkManager.InvokeServerMethod("WaterPlarticleSystemEmissionRPC", this.gameObject.name, _emssion);
            WaterPlarticleSystemEmissionAndroid(_emssion);
        }

    }

    private void WaterPlarticleSystemEmissionAndroid(bool _emssion)
    {
        emssion = _emssion;
        waterParticles.enableEmission = emssion;
        startFlowerTimer = _emssion;
    }

    public void WaterPlarticleSystemEmissionRPC(bool _emssion)
    {
       // if (!Statistics.android)
        //{
            emssion = _emssion;
            waterParticles.enableEmission = emssion;
            startFlowerTimer = _emssion;
     //   }

    }
    public void StopWaterSFX()
    {
        wateringFlowersSFX.Stop();
        WaterPlarticleSystemEmission(false);
    }

    public void StopFlowerAnimCoroutine()
    {
        Debug.Log("StopFlowerAnimCoroutine");
        StopCoroutine(currentCoroutine);
    }

    public void GetReadyForFirstWatering()
    {
        Debug.Log("get ready for watering task");
        flowerIndex = 0;
        UpdateCurrentFlower();
    }

    public void FLowerFinishedWatering()
    {
        //currentFlower.FinishWatering();
        //if (flowerInteruptionTime >= 0.1)
        //{
        //    CSVWriter.Instance.WriteFlowerInteruptionTime(flowerInteruptionTime.ToString());
        //}
        //flowerInteruptionTime = 0;
        //Debug.Log("FINISH INTINT");
        //startInterruptionTimer = false;
        didTryToWaterAtleastOnce = false;
        flowerInteruptionTime = 0;

        isNewFlower = true;
        StopWaterSFX();
        WaterPlarticleSystemEmission(false);
        if ((stats.numberOfFlowers ) >= flowerIndex)
        {
            flowerIndex++;
            UpdateCurrentFlower();
            Debug.Log("animator trigger flower numbers" + flowerIndex);
        }

    }
    public void GetReadyForNextFlower(int _newFlowerIndex)
    {
        if (_newFlowerIndex < flowers.Length) UpdateCurrentFlower();
        flowerIndex = _newFlowerIndex;
    }
    public void UpdateCurrentFlower()
    {
        Debug.Log("Current flower updated in animator trigger index ");
        currentFlower = flowers[flowerIndex];
        Debug.Log("animator trigger update flower");
        // currentFlower.GetComponent<Flower>().GetReadyForWatering();
    }

}