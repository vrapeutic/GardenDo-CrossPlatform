using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class ControlAudioSources : MonoBehaviour
{
    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("PuaseCurrentAudioClipRPC", invokationManager);
    }

    public void PuaseCurrentAudioClip()
    {
        PuaseCurrentAudioClipRPC();
        //if (Statistics.android) NetworkManager.InvokeServerMethod("PuaseCurrentAudioClipRPC", this.gameObject.name);
    }

    public void PuaseCurrentAudioClipRPC()
    {
        gameObject.GetComponent<AudioSource>().Pause();
    }
}
