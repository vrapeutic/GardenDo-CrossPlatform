using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    bool checkEnabled = true;
    bool checkDisabled = true;
    private void Update()
    {
        if (Statistics.android)
        {
            
             if (this.GetComponent<Collider>().enabled)
             {
                if (checkEnabled)
                {
                    Debug.Log("Watering sensor is enabled");
                    checkEnabled = false;
                    checkDisabled = true;
                }

             }
            else
            {
                if (checkDisabled)
                {
                    Debug.Log("Watering sensor is disable");
                    checkEnabled = true;
                    checkDisabled = false;
                }
            }
         
          
        }
    }
}
