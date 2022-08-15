using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // [SerializeField] Animator HussienAnimParent;
    // [SerializeField] GameObject NPC;
    //[SerializeField] Animator HussienAnim;

    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
        if (stats.isCompleteCourse)
        {
            StartCoroutine(MoveFromCenterToTheWellIEnum());
        }
    }

    IEnumerator MoveFromCenterToTheWellIEnum()
    {
        // HussienAnim.SetTrigger("StartWalking");
        SetAnimatorInt.instance.AnimatorSetIntger(16);
        yield return new WaitForSeconds(0.1f);
      //  NPC.transform.GetChild(0).GetComponent<Animator>().SetTrigger("CenterToWell");
        SetAnimatorParentInt.instance.gameObject.GetComponent<Animator>().SetTrigger("CenterToWell");
        //  HussienAnimParent.SetTrigger("CenterToWell");
        Debug.Log("Walking");
    }



}
