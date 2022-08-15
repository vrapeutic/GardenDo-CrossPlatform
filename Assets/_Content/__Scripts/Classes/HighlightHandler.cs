using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightHandler : MonoBehaviour
{
    [SerializeField] GameObject outline;

    private bool isFirstHand = false;

    private void Start()
    {
      // if (!Statistics.android) outline.GetComponent<Outline>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.CompareTag("Hand"))
        {
            if (!isFirstHand)
            {
               DisableOutLine();
            }
        }
    }

    private void DisableOutLine()
    {
        outline.gameObject.GetComponent<Outline>().enabled = false;

        isFirstHand = true;
    }
}
