using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Tachyon;
public class NPCGoesToWell : MonoBehaviour
{
    [SerializeField]
    Animator npcAnimator;
    [SerializeField]
    Animator npcChildAnimator;
    [SerializeField]
    GameEvent npcArrivedToTheWellEvent;
    [SerializeField]
    GameEvent readyToWaterEvent;
    private void Start()
    {
        if (!npcAnimator) npcAnimator = this.GetComponent<Animator>();
        if (!npcChildAnimator) npcChildAnimator = this.GetComponentInChildren<Animator>();
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("NPCMovesToTheWellRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("NPCArrivedToTheWellRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("GetNPCBackToHisPositionRPC", invokationManager);
        //NetworkManager.InvokeClientMethod("NPC_ArrivedToOriginalPositionRPC", invokationManager);
    }
    public void NPCMovesToTheWell()
    {
        if(Statistics.android)
        {
            Debug.Log("npc moves to the well ");
            NPCMovesToTheWellRPC();
            //NetworkManager.InvokeServerMethod("NPCMovesToTheWellRPC", this.gameObject.name);
        }
       
    }

    public void NPCArrivedToTheWell()
    {
        if(Statistics.android)
        {
            Debug.Log("npc arrived to the well");
            NPCArrivedToTheWellRPC();
            //NetworkManager.InvokeServerMethod("NPCArrivedToTheWellRPC", this.gameObject.name);
        }
        
    }

    public void GetNPCBackToHisPosition()
    {
        if(Statistics.android)
        {
            Debug.Log("get npc back to his position");
            GetNPCBackToHisPositionRPC();
            //NetworkManager.InvokeServerMethod("GetNPCBackToHisPositionRPC", this.gameObject.name);
        }
       
    }
    public void NPC_ArrivedToOriginalPosition()
    {
        if(Statistics.android)
        {
            Debug.Log("npc arrived to original position");
            NPC_ArrivedToOriginalPositionRPC();
            //NetworkManager.InvokeServerMethod("NPC_ArrivedToOriginalPositionRPC", this.gameObject.name);
        }
       
    }

    IEnumerator GetReadyWaterFlowers()
    {
        yield return new WaitForSeconds(2);
        readyToWaterEvent.Raise();
    }

    public void NPCArrivedToTheWellRPC()
    {
        Debug.Log("npc arrived to the well RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 0); //stop walking animation and back to idle
        
        npcArrivedToTheWellEvent.Raise();
    }
    public void GetNPCBackToHisPositionRPC()
    {
        Debug.Log("get npc back to his position RPC");
        npcAnimator.SetInteger("NPCAnimController", 1);
        npcChildAnimator.SetInteger("NPCAnimController", 16);
    }
    public void NPC_ArrivedToOriginalPositionRPC()
    {
        Debug.Log("npc arrived to original position RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 0); //stop walking animation and back to idle
        npcAnimator.SetInteger("NPCAnimController", 0);
        // readyToWaterEvent.Raise();
        StartCoroutine(GetReadyWaterFlowers());
    }

    public void NPCMovesToTheWellRPC()
    {
        Debug.Log("NPC moves to the well RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 16); // npc waving 
        npcAnimator.SetInteger("CenterToWell",1);  //npc move to the well animation

        Debug.Log("player called to the well");
    }

    public void StopMovement()
    {
        npcAnimator.SetInteger("CenterToWell", 0);  //npc move to the well animation
    }
}
