using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
using UnityEngine.UI;

public class FinalizeFlowersStates : MonoBehaviour
{

    public static bool tasksAreDone = false;

    [SerializeField] int flowerMaxNumber;
    [SerializeField] int currentIndix;
    AnimatorTrigger animatorTrigger;


    [SerializeField] GameEvent flowerFinishedEvent;
    [SerializeField] GameEvent gameFinishedEvent;
    private int numberOfWateringCycle;

    Statistics stats;

    public static bool stopWateringCoroutine = false;



    void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("FinalizeCurrentStateRPC", invokationManager);
        NetworkManager.InvokeClientMethod("GameOverRPC", invokationManager);
        animatorTrigger = FindObjectOfType<AnimatorTrigger>();
        tasksAreDone = false;
        currentIndix = 0;
        stats = Statistics.instane;
        flowerMaxNumber = stats.numberOfFlowers;

    }

    public void FinalizeCurrentState()
    {
        Debug.Log("Finalize Current State");
        if (Statistics.android) NetworkManager.InvokeServerMethod("FinalizeCurrentStateRPC", this.gameObject.name);
    }

    public void FinalizeCurrentStateRPC()
    {
        Debug.Log("Finalize Current State RPC");
        if (Statistics.android)
        {
            if (currentIndix == (flowerMaxNumber - 1))
            {

                tasksAreDone = true;

                gameFinishedEvent.Raise();


                EndSession.instance.GameOver();
                Debug.Log("FinalFlower");

            }
           
        }
    }


    public void StopLastFlowerCoroutine(bool _stopFlowerCoroutine)
    {
        stopWateringCoroutine = _stopFlowerCoroutine;
    }

   

    

}
