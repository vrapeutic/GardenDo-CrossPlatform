using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;

public class PlayerHoldsTheBucket : MonoBehaviour
{
    // [SerializeField] Animator HussienAnim;



    [SerializeField] GameEvent bucketFirstGrabbedEvent;

    WaitForSeconds waitingSeconds = new WaitForSeconds(20);
    private bool playerIsGrabbingtheHandle = false;
    private bool firstHandEnter = false;
    private bool canDisableOutline = true;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("GrabTheHandleRPC", invokationManager);

        if (!stats.isCompleteCourse)
        {
            firstHandEnter = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Player is holding The Bucket");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;


            if (Statistics.android && !firstHandEnter)
            {
                Debug.Log("First Enter Grabbing Bucket");
                GrabTheHandleRPC();
                //NetworkManager.InvokeServerMethod("GrabTheHandleRPC", this.gameObject.name);
                firstHandEnter = true;
            }

            if (Statistics.android) GetComponent<CheckIntervals>().CheckIntervalsCall(waitingSeconds, playerIsGrabbingtheHandle);
        }
    }

    public void GrabTheHandleRPC()
    {
        bucketFirstGrabbedEvent.Raise();
        Debug.Log(" Handle Call");
    }

    public void OnConditionNotChecked()
    {
        if (Statistics.android) GrabTheHandleRPC();
        /*NetworkManager.InvokeServerMethod("GrabTheHandleRPC", this.gameObject.name);*/
    }



}
