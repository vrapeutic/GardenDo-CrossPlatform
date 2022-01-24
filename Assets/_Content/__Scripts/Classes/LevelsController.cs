using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField] GameObject butterfly;
    [SerializeField] GameObject bird;

    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
       
        if (stats.level == 1)
        {
            DisableLevel_2Distractor();
        }
        else if (stats.level == 3)
        {
            EnableLevel_3Distractor();
        }
    }

    public void DisableLevel_2Distractor()
    {
        butterfly.SetActive(false);
    }
    public void EnableLevel_3Distractor()
    {
        // butterfly.SetActive(true);
        bird.SetActive(true);
    }



}
