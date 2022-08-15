using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class WelcomingNPCs : MonoBehaviour
{
     [SerializeField] Animator myAnim; //child object animator
    [SerializeField]
    GameEvent finishWelcommingEvent;
    // Start is called before the first frame update
    
    void Start()
    {
       
       
        if (!myAnim) myAnim = this.GetComponentInChildren<Animator>();
       StartCoroutine(WelcomeThePlayerIEnum());
    }


  IEnumerator WelcomeThePlayerIEnum()
    {
        yield return new WaitForSeconds(5);

        NPCWavingRPC();
        //  NPCWavingRPC();
                yield return new WaitForSeconds(9);

        finishWelcommingEvent.Raise();
      

    }

    

    public void NPCWavingRPC()
    {     
        myAnim.SetInteger("NPCAnimController", 1);
        Debug.Log("npc waving called");
    }
}
