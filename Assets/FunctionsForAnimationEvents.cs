using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsForAnimationEvents : MonoBehaviour
{
    [SerializeField] GameObject wavingArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableSelf()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    public void ChildrenStartedWaving()
    {
        WavingSensorController.areChildrenWaving = true;
        wavingArea.SetActive(true);
    }

    public void WigglePot()
    {
        ResetPotController.isPotKnockedOver = true;
    }

    public void ResetPot()
    {
        ResetPotController.isPotKnockedOver = false;
    }
}
