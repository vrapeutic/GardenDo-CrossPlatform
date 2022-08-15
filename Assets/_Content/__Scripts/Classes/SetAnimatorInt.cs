using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorInt : MonoBehaviour
{
   // [SerializeField] Animator HussienAnim;
   
    public static SetAnimatorInt instance;

    private void Start()
    {
        instance = this;
    }

    public void AnimatorSetIntger(int setIntger)
    {
        instance.gameObject.GetComponent<Animator>().SetInteger("NPCAnimController", setIntger);
    }

}
