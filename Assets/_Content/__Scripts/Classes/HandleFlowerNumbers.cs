using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFlowerNumbers : MonoBehaviour
{
    [SerializeField] GameObject[] flowerToEnable;
    Statistics stats;


    private void Start()
    {
        stats = Statistics.instane;
    }
    public void EnableFlower()
    {

        if (stats.numberOfFlowers > 9)
        {
            for (int i = 0; i < stats.numberOfFlowers; i++)
            {
                flowerToEnable[i].SetActive(true);
            }
        }

    }
}
