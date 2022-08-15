using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsSync : MonoBehaviour
{
    [SerializeField] Transform targetObjetc;
    Vector3 newPos = new Vector3();

    private void Start()
    {
#if UNITY_ANDROID
        GetComponent<MeshRenderer>().enabled = false;

#endif
    }
    private void Update()
    {
#if UNITY_ANDROID

        newPos.x = targetObjetc.position.x;
        newPos.y = targetObjetc.position.y;
        newPos.z = targetObjetc.position.z;
        transform.position = newPos;
        transform.rotation = targetObjetc.rotation;
#endif
    }
}
