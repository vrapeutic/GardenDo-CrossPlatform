using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class PlayerIsNearTheWell : MonoBehaviour
{
    // [SerializeField] Animator HussienAnim;

    [SerializeField] GameEvent playerArrivedToTheWellEvent;


    bool playerIsGrabbingtheBucket = false;

    bool isNPC_AtWell = false;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;

        if (stats.isCompleteCourse)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER is near the well");
            if (isNPC_AtWell)
            {
                playerArrivedToTheWellEvent.Raise();
            }


        }
    }


    public void PlayerArrived()
    {
        playerArrivedToTheWellEvent.Raise();
        this.GetComponent<Collider>().enabled = false;

    }


    public void OnNPCArrivesToTheWell()
    {
        this.GetComponent<Collider>().enabled = true;
    }

    public void NPC_MovedToWell()
    {
        isNPC_AtWell = true;
    }
}
