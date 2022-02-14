using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class LevelsController : MonoBehaviour
{
    [SerializeField] GameObject butterfly;
    [SerializeField] GameObject bird;

    Statistics stats;
    void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("EnableLevel_3DistractorRPC", invokationManager);
        stats = Statistics.instane;

        if (stats.level == 1)
        {
            DisableLevel_2Distractor();
        }
        else if (stats.level == 3)
        {
            if (Statistics.android)
                EnableLevel_3Distractor();
        }
    }

    public void DisableLevel_2Distractor()
    {
        butterfly.SetActive(false);
    }
    public void EnableLevel_3Distractor()
    {
        // bird.SetActive(true);
        NetworkManager.InvokeServerMethod("EnableLevel_3DistractorRPC", this.gameObject.name);
    }
    public void EnableLevel_3DistractorRPC()
    {
        bird.SetActive(true);
    }



}
