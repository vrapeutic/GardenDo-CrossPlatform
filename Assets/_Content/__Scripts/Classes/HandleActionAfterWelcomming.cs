using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class HandleActionAfterWelcomming : MonoBehaviour
{

    [SerializeField]
    GameEvent goToTheWellEvent;
    [SerializeField]
    GameEvent getReadyForWateringEvent;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("OnWelcommingFinishRPC", invokationManager);   
    }
    public void OnWelcommingFinish()
    {
        Debug.Log("welcoming finished event listened");
        OnWelcommingFinishRPC();
       // if (Statistics.android) NetworkManager.InvokeServerMethod("OnWelcommingFinishRPC", this.gameObject.name);
    }

    public void OnWelcommingFinishRPC()
    {
        Debug.Log("welcoming finished RPC called");
        if (stats.isCompleteCourse)
        {
            goToTheWellEvent.Raise();
            Debug.Log("go to the well event raised");
        }
        else
        {
            getReadyForWateringEvent.Raise();
            Debug.Log("let's water the flower event raised");
        }
    }
}
