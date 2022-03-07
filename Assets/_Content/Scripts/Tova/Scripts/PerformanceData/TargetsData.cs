using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsData : MonoBehaviour
{
    [SerializeField] string targetTag;
    [SerializeField] bool hasDirection;
    GameObject[] targets;
    Vector3 direction;
    Vector3 currentPosition;
    List<string> currentPositionsList = new List<string>();
    List<float> currentHieghtsList = new List<float>();
    List<string> currentDirectionList = new List<string>();
    float currentId = 0;
    float currentHight;
    List<string> TargetList = new List<string>();

    void Start()
    {

        targets = GameObject.FindGameObjectsWithTag(targetTag);
            SetDataList();

    }

  



    void GetTargetList()
    {
        foreach (GameObject target in targets)
        {
            if (currentId < targets.Length)
                currentId++;
            else return ;
            currentHight = target.transform.position.y;
            currentPosition = target.transform.position;
            direction = (currentPosition - Camera.main.transform.position).normalized;
            currentHieghtsList.Add(currentHight);
            currentPositionsList.Add(currentPosition.ToString());
            if (hasDirection)
            {

                currentDirectionList.Add(direction.ToString());

            }
       

        }
    }
    void SetDataList()
    {
        GetTargetList();
        TovaDataGet.ReturnTovaData().SetTargetListDataHights(string.Join(", ",currentHieghtsList));
        TovaDataGet.ReturnTovaData().SetTargetListDataPostions(string.Join(", ",currentPositionsList));
        TovaDataGet.ReturnTovaData().SetTargetListDataDirections(string.Join(", ",currentDirectionList));
    }

    #region TestWithInvoker
    void TestForInvoker()
    {

        Debug.Log(targets.Length);
        SetDataList();
        string lists = TovaDataGet.ReturnTovaData().GetTargetDataListDirections();
        Debug.Log( TovaDataGet.ReturnTovaData().GetTargetDataListDirections());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListPositions());
        Debug.Log( TovaDataGet.ReturnTovaData().GetTargetDataListHights());
        Debug.Log(lists+" all "+lists);
    }

  
    #endregion
}
