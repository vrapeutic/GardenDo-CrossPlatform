using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;

public class CallPlayerToWateraFlower : MonoBehaviour
{
    // [SerializeField] Animator HussienAnim;


    WaitForSeconds waitingSeconds = new WaitForSeconds(20);
    bool wateringState = false;
    public static bool isPlayerWateringTheFlower = false;

    private void Start()
    {
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("LetsWaterTheFlowerRPC", invokationManager);
        Debug.Log("Call player to water a flower is started");
    }

    public void OnConditionNotChecked()
    {
        LetsWaterTheFlowerRPC();
      //  if (Statistics.android) NetworkManager.InvokeServerMethod("LetsWaterTheFlowerRPC", this.gameObject.name);
    }

    public void LetsWaterTheFlowerRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(9);
    }



    public void OnPlayerIsNotWatering()
    {
        // HussienAnim.GetComponent<SetAnimatorInt>().AnimatorSetIntger(9);
        // if(Statistics.android) GetComponent<CheckIntervals>().CheckIntervalsCall(waitingSeconds, wateringState);
    }

    public void PlayerWateringTheFlowerState(bool _isPlayerWateringTheFlower)
    {
        // StartCoroutine(PlayerWateringTheFlowerStateIEnum(_isPlayerWateringTheFlower));
        isPlayerWateringTheFlower = _isPlayerWateringTheFlower;
    }
    IEnumerator PlayerWateringTheFlowerStateIEnum(bool _isPlayerWateringTheFlower)
    {
        yield return new WaitForSeconds(.2f);
        isPlayerWateringTheFlower = _isPlayerWateringTheFlower;
    }



}
