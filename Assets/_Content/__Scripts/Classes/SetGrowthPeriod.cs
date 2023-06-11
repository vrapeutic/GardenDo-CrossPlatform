using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class SetGrowthPeriod : MonoBehaviour
{

    private float eachFlowerGrowthPeriod;
    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("SetFlowerGrowthPeriodRPC", invokationManager);
    }


    public void SetFlowerGrowthPeriod(int _totalSceneSeconds)
    {
        SetFlowerGrowthPeriodRPC(_totalSceneSeconds);
       // NetworkManager.InvokeServerMethod("SetFlowerGrowthPeriodRPC", this.gameObject.name, _totalSceneSeconds);
    }

    public void SetFlowerGrowthPeriodRPC(int _totalSceneSeconds)
    {
        stats.totalFlowerGrowth = _totalSceneSeconds;
        eachFlowerGrowthPeriod = (float)stats.totalFlowerGrowth / 4f;
        stats.growthSpeed = 0.5f; //(float)eachFlowerGrowthPeriod / 10f;
        Debug.Log("totalSceneSeconds:  " + stats.totalFlowerGrowth);
        Debug.Log("Growth Speed: " + stats.growthSpeed);
    }
}
