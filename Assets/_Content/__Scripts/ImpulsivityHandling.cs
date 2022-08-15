using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsivityHandling : MonoBehaviour
{
    
   public void FinishOneMoreTask()
    {
        TovaDataGet.ReturnTovaData().SetTargetsCounterEnabled(true);
   }   
  
}
