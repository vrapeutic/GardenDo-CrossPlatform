using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorParentInt : MonoBehaviour
{
    //[SerializeField] Animator HussienAnim;

    public static SetAnimatorParentInt instance;

    Statistics stats;
    private void Start()
    {
        instance = this;
        stats = Statistics.instane;
    }

    public void AnimatorSetIntger(int setIntger)
    {
        if (stats.isCompleteCourse)
        {
            instance.gameObject.GetComponent<Animator>().SetInteger("NPCAnimController", setIntger);
        }
    }
}
