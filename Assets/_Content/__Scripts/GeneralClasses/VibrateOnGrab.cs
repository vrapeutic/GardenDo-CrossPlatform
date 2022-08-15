using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateOnGrab : MonoBehaviour
{
    WaitForSeconds seconds = new WaitForSeconds(0.2f);
  
    public AudioClip audioS;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE
        GetComponent<Rigidbody>().useGravity = false;   
#endif
    }

    private void Update()
    {
     //   bool isPressBackKeyRight = OVRInput.GetDown(grabButton, OVRInput.Controller.RTouch);
     //   bool isPressBackKeyLeft = OVRInput.GetDown(grabButton, OVRInput.Controller.LTouch);

      
    }
}

