using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class CallPlayerToTheWell : MonoBehaviour
{
   // [SerializeField] Animator HussienAnim;
    [SerializeField]  bool playerMovedTowardsTheWell;

    WaitForSeconds waitingSeconds = new WaitForSeconds(20);


    void Start()
    {
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("WaitForPlayerToComeOverRPC", invokationManager);
        playerMovedTowardsTheWell = false;
   //GetComponent<CheckIntervals>().CheckIntervalsCall(waitingSeconds, playerMovedTowardsTheWell);
    }

    public void TimedConditionChecked()
    {
        Debug.Log("Moved");
    }

   

    
}
