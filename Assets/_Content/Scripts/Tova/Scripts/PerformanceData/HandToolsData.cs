using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HandToolsData : MonoBehaviour
{
    public string handToolTag;
    List<GameObject> handTools = new List<GameObject>();
    float currentId = 0;
    float handToolAngle;
    public Transform toolAngleReference;
    List<string> HandToolsList = new List<string>();

    #region TestWithInvoker
    void InvokerHandToolsTest(bool isStarted)
    {
        TovaDataGet.ReturnTovaData().SetIsActionStarted(isStarted);
        Debug.Log(string.Join(", ", GetHandToolsList().ToArray()));
        Debug.Log(TovaDataGet.ReturnTovaData().GetIsActionStarted());
        TovaDataGet.ReturnTovaData().SetHandToolsListDataAngles(string.Join(",", GetHandToolsList().ToArray()));
        Debug.Log(string.Join(", ", TovaDataGet.ReturnTovaData().GetHandToolsDataList()));
    }
    #endregion
   
    void Update()
    {
        if (TovaDataGet.ReturnTovaData().GetIsActionStarted() == true)
        {
            GameObject handTool = GameObject.FindGameObjectWithTag(handToolTag);
            handTools.Add(handTool);
            GetHandToolsList();
            TovaDataGet.ReturnTovaData().SetIsActionStarted(false);
        }
        if (TovaDataGet.ReturnTovaData().GetSessionEnd() == true)
        {
            TovaDataGet.ReturnTovaData().SetHandToolsListDataAngles(string.Join(",", GetHandToolsList()));
        }
    }
    List<string> GetHandToolsList()
    {
        foreach (GameObject tool in handTools)
        {
            if (currentId < handTools.Count)
            {
                currentId++;
                Debug.Log("Performance id: " + currentId);
                Debug.Log(handTools.Count);
            }
            else return HandToolsList;
            handToolAngle = Vector3.Angle(tool.transform.position, toolAngleReference.transform.forward);
            HandToolsList.Add(handToolAngle.ToString());
        }

        return HandToolsList;
    }
}