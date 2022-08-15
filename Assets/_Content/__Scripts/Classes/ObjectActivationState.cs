using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class ObjectActivationState : MonoBehaviour
{
    private void Start()
    {
        //InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        //NetworkManager.InvokeClientMethod("ActivationStateRPC", invokationManager);
    }

    public void ActivationState(int _state)
    {
        ActivationStateRPC(_state);
        //if (Statistics.android) NetworkManager.InvokeServerMethod("ActivationStateRPC", this.gameObject.name, _state);
    }

    public void ActivationStateRPC(int _state)
    {
             if(_state == 1) gameObject.SetActive(true);
        else if(_state == 0) gameObject.SetActive(false);
    }
}
