using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPotController : MonoBehaviour
{
    public static bool isPotKnockedOver;
    [SerializeField] Animator myAnimator;

    Statistics stats;
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("ResetPot");
            myAnimator.SetTrigger("ResetPot");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            isPotKnockedOver = false;
            LevelsController.DidInteracttWithDistractor();
        }
    }

}
