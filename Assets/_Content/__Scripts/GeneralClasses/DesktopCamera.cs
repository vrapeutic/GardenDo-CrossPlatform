using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopCamera : MonoBehaviour
{
    [SerializeField] Transform targetObjetc;
    Vector3 newPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        //if (!Statistics.android)
#if UNITY_STANDALONE
        IntializeDesktopCamera();
#endif

    }
    void IntializeDesktopCamera()
    {
        Debug.Log("Entered IntializeDesktopCamera");
        gameObject.AddComponent<Camera>();
        gameObject.GetComponent<Camera>().depth = 1;


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