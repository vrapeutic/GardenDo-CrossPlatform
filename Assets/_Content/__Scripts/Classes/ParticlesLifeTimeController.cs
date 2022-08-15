using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class ParticlesLifeTimeController : MonoBehaviour
{
    ParticleSystem.MainModule particleComponent;
    float distance;
    WaitForSeconds updateTimeStep = new WaitForSeconds(0.5f);
   // public float coff;
    [SerializeField] GameObject wellWateringTip;
    [SerializeField] GameObject waterSurfaceInTheBucket;


    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("ParticlesLifeTimeRPC", invokationManager);
        particleComponent = this.GetComponent<ParticleSystem>().main;
        StartCoroutine(UpdateLifeTime());
    }

    private void ParticlesLifeTime()
    {
        if (Statistics.android) { NetworkManager.InvokeServerMethod("ParticlesLifeTimeRPC", this.gameObject.name); }
    }

    public void ParticlesLifeTimeRPC()
    {
        particleComponent.startLifetime = 0.2f + (0.5f * distance);
        //  Debug.Log("Life Time: " + particleComponent.startLifetime.ToString());
    }

    private void GetDistance()
    {
        distance = wellWateringTip.transform.position.y - waterSurfaceInTheBucket.transform.position.y;
      //  Debug.Log("Distance: " + distance);
        ParticlesLifeTime();
    }

    IEnumerator  UpdateLifeTime()
    {
        while (true)
        {
            yield return updateTimeStep;
            GetDistance();
        }
     
    }
}
