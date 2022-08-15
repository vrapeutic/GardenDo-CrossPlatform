using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CheckIntervals : MonoBehaviour
{
    WaitForSeconds seconds;
    public bool check;

    public void CheckIntervalsCall(WaitForSeconds _seconds, bool _check)
    {
        seconds = _seconds;
        check = _check;
        StartCoroutine(CheckIntervalsInum());
    }

    IEnumerator CheckIntervalsInum()
    {
        while (true)
        {
            yield return seconds;

            if (check)
            {
                GetComponent<TimedConditionChecked>().TimedConditionChecked();
                Debug.Log("BREAK");
                break;
            }

            
            GetComponent<TimedConditionChecked>().OnConditionNotChecked();
        }

    }


}
