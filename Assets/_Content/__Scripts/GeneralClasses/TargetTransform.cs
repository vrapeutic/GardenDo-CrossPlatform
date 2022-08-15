using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class: TargetTransform
public class TargetTransform : MonoBehaviour
{
    Transform targetObjectTransform;


    public void CaptureTransform(Transform _targetObjectTransform)
    {
        targetObjectTransform = _targetObjectTransform;
    }


    public void SetTransform()
    {
        transform.position = targetObjectTransform.position;
        transform.rotation = targetObjectTransform.rotation;
    }
}
