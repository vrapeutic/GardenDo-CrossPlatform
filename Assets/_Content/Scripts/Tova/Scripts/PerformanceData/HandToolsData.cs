using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandToolsData : MonoBehaviour
{
    [SerializeField] string handToolTag;
    GameObject[] handTools;
    float currentId = 0;
    float handToolAngle;
    [SerializeField] Transform toolAngleReference;
    List<string> HandToolsList = new List<string>();

    #region TestWithInvoker
    void InvokerHandToolsTest(bool isStarted)
    {
        TovaDataGet.ReturnTovaData().SetIsActionStarted(isStarted);
        Debug.Log(GetHandToolsList());
        Debug.Log(TovaDataGet.ReturnTovaData().GetIsActionStarted());
        TovaDataGet.ReturnTovaData().SetHandToolsListDataAngles(string.Join(", ", TovaDataGet.ReturnTovaData().GetHandToolsDataList()));
        Debug.Log(string.Join(", ", TovaDataGet.ReturnTovaData().GetHandToolsDataList()));

    }
    #endregion

    void Update()
    {
        if (TovaDataGet.ReturnTovaData().GetIsActionStarted() == true)
        {
            handTools = GameObject.FindGameObjectsWithTag(handToolTag);
            GetHandToolsList();
            TovaDataGet.ReturnTovaData().SetIsActionStarted(false);
        }


        if (TovaDataGet.ReturnTovaData().GetSessionEnd() == true)
            TovaDataGet.ReturnTovaData().SetHandToolsListDataAngles(string.Join(", ", TovaDataGet.ReturnTovaData().GetHandToolsDataList()));

    }


    List<string> GetHandToolsList()
    {
        foreach (GameObject tool in handTools)
        {
            if (currentId < handTools.Length)
                currentId++;
            else return HandToolsList;

           handToolAngle = Vector3.Angle(tool.transform.position, toolAngleReference.transform.forward);
            HandToolsList.Add(handToolAngle.ToString());
        }
        return HandToolsList;
    }
}
