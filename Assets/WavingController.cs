using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavingController : MonoBehaviour
{
    [SerializeField] Animator childrensAnimator;

    private void Awake()
    {
        if (!childrensAnimator) childrensAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Wave Detected");
            if (WavingSensorController.areChildrenWaving)
            {
                WavingSensorController.areChildrenWaving = false;
                childrensAnimator.SetTrigger("Wave");
                Debug.Log("FIXED distractor: " + "Children" + ", Time: " + LevelsController.blockingTimer);
                CSVWriter.Instance.SaveDistractorBlockingTime("Children", System.Math.Round((decimal)LevelsController.blockingTimer, 2).ToString());
                LevelsController.DidInteracttWithDistractor();
                this.gameObject.SetActive(false);
            }
        }
    }
}
