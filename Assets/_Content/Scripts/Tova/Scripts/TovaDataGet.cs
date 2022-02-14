using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TovaDataGet : MonoBehaviour
{

   public static TovaDataSet dataSet;
    [SerializeField] float TAS;
    [SerializeField] float instractionTime = 5;
    [SerializeField] float responseDistractorWight = 0.5f;
    [SerializeField] float responseWight = 0.5f;
    private void Awake()
    {
        dataSet = new TovaDataSet();
    }
  
    public static TovaDataSet ReturnTovaData()
    {
        return dataSet;
    }
   private void Start()
    {
        dataSet.SetTypicalTime(TAS);
        dataSet.SetInstructionTime(instractionTime);
        dataSet.SetResponseWight(responseWight);
        dataSet.SetResponseDistractorWight(responseDistractorWight);
        StartCoroutine(EndSession());
    }
    IEnumerator EndSession()
    {
        while (true)
        {
           if (ReturnTovaData().GetSessionEnd() != false) {
                ReturnTovaData().SetSessionEnd(false);
                ReturnTovaData().SetActualTimeCounter(false);
                ReturnTovaData().SetResponseTimer(false);
                ReturnTovaData().SetDistractorResponseTimer(false);
            }
            yield return new WaitForSeconds(.3f);
        }
    }

}
