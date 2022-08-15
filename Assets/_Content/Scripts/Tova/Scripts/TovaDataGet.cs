using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TovaDataGet : MonoBehaviour
{

    public static TovaDataSet dataSet;
    TovaDataGet[] getData;
    [SerializeField] float TAS;
    [SerializeField] float instractionTime = 5;
    [SerializeField] float responseDistractorWight = 0.5f;
    [SerializeField] float responseWight = 0.5f;
    private void Awake()
    {

        dataSet = ScriptableObject.CreateInstance<TovaDataSet>();
        getData = FindObjectsOfType<TovaDataGet>();
        if (getData.Length > 1)
            Destroy(getData[0].gameObject);
        DontDestroyOnLoad(this.gameObject);

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
            if (ReturnTovaData().GetSessionEnd() != false)
            {
                ReturnTovaData().SetSessionEnd(false);
                ReturnTovaData().SetActualTimeCounter(false);
                ReturnTovaData().SetResponseTimer(false);
                ReturnTovaData().SetDistractorResponseTimer(false);
                //  Invoke( "ResetData",3);
            }

            yield return new WaitForSeconds(.3f);
        }
    }

    private void ResetData()
    {
        // Destroy(this.gameObject);
    }


}
