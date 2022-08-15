using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class SetAnimalAnimatorInt : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
    [SerializeField] AnimalBehaviourControl myAnimalBehaviour;
    [SerializeField] public static bool isAnimalDistracting;

    public bool canFill;
    private void Start()
    {
        try
        {
            InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
            NetworkManager.InvokeClientMethod("StartDistractionRPC", invokationManager);
            NetworkManager.InvokeClientMethod("StopDistractionRPC", invokationManager);

        }
        catch
        {
            Debug.Log("set animal int init error");
        }
        //if( !myAnimalBehaviour ) myAnimalBehaviour = GetComponentInChildren<AnimalBehaviourControl>();

        isAnimalDistracting = false;
        canFill = false;
        if (!myAnimator) myAnimator = this.GetComponent<Animator>();
    }

    public void StartDistraction()
    {

        Debug.Log("Start distraction");
        if (Statistics.android)
        {
            Debug.Log("should enable collider");
            myAnimalBehaviour.GetComponent<Collider>().enabled = true;
            myAnimalBehaviour.ActivateCollider();
            canFill = true;
            isAnimalDistracting = true;
            NetworkManager.InvokeServerMethod("StartDistractionRPC", this.gameObject.name);
        }


    }

    public void StartDistractionRPC()
    {
        Debug.Log("Start distraction RPC");
        myAnimator.SetInteger("State", 0);
    }
    public void StopDistraction()
    {
        Debug.Log("Stop distraction");
        isAnimalDistracting = false;
        canFill = false;
        NetworkManager.InvokeServerMethod("StopDistractionRPC", this.gameObject.name);
    }
    public void StopDistractionRPC()
    {
        myAnimator.SetInteger("State", 1);
        Debug.Log("Stop distraction RPC");
    }
    //IEnumerator Distract()
    //{
    //    yield return new WaitForSeconds(3);
    //    myAnimalBehaviour.gameObject.SetActive(true);
    //    isAnimalDistracting = true;
    //    canFill = true;
    //    Debug.Log("distract coroutine");
    //    NetworkManager.InvokeServerMethod("DistractRPC", this.gameObject.name);
    //}
}
