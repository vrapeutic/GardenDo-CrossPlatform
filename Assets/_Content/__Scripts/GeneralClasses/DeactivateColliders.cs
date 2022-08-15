using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeactivateColliders : MonoBehaviour
{
    void Start()
    {
#if UNITY_STANDALONE
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DisableCurrentComponent());
#endif
    }


    IEnumerator DisableCurrentComponent()
    {
        yield return new WaitForSeconds(.2f);
        enabled = false;
    }


    private void OnEnable()
    {
#if UNITY_STANDALONE
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DisableColliders());
#endif
    }


    IEnumerator DisableColliders()
    {
        yield return new WaitForSeconds(.2f);
#if UNITY_STANDALONE
        GetComponent<Collider>().enabled = false;
#endif
    }
}
