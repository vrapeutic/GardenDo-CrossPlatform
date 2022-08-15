using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOptmization : MonoBehaviour
{
    // Don't add more than 0.8f
    public float AdditiveImproveScale = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1 + AdditiveImproveScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
