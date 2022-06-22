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
    float direction_X;
    float direction_Y;
    float direction_Z;
    Vector3 currentPosition;
    List<string> currentPositionsList = new List<string>();
    List<string> currentPositions_X_List = new List<string>();
    List<string> currentPositions_Y_List = new List<string>();
    List<string> currentPositions_Z_List = new List<string>();
    
    List<float> currentHieghtsList = new List<float>();
    
    List<string> currentDirectionList = new List<string>();
    List<string> currentDirection_X_List = new List<string>();
    List<string> currentDirection_Y_List = new List<string>();
    List<string> currentDirection_Z_List = new List<string>();
    float currentId = 0;
    float currentHight;
    float xPosition;
    float yPosition;
    float zPosition;
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
            else return;
            currentHight = target.transform.position.y;
            currentPosition = target.transform.position;
            xPosition = target.transform.position.x;
            yPosition = target.transform.position.y;
            zPosition = target.transform.position.z;
            
            direction = (currentPosition - Camera.main.transform.position).normalized;
            
            currentHieghtsList.Add(currentHight);
            currentPositionsList.Add(currentPosition.ToString());
            currentPositions_X_List.Add(xPosition.ToString());
            currentPositions_Y_List.Add(yPosition.ToString());
            currentPositions_Z_List.Add(zPosition.ToString());
            if (hasDirection)
            {
                currentDirectionList.Add(direction.ToString());
                currentDirection_X_List.Add(direction.x.ToString());
                currentDirection_Y_List.Add(direction.y.ToString());
                currentDirection_Z_List.Add(direction.z.ToString());
            }
        }
    }
    void SetDataList()
    {
        GetTargetList();
        TovaDataGet.ReturnTovaData().SetTargetListDataHights(string.Join(",", currentHieghtsList));
        
        TovaDataGet.ReturnTovaData().SetTargetListDataPostions(string.Join(",", currentPositionsList));
        TovaDataGet.ReturnTovaData().SetTargetListDataPostions_X(string.Join(",", currentPositions_X_List));
        TovaDataGet.ReturnTovaData().SetTargetListDataPostions_Y(string.Join(",", currentPositions_Y_List));
        TovaDataGet.ReturnTovaData().SetTargetListDataPostions_Z(string.Join(",", currentPositions_Z_List));
      
        TovaDataGet.ReturnTovaData().SetTargetListDataDirections(string.Join(",", currentDirectionList));
        TovaDataGet.ReturnTovaData().SetTargetListDataDirections_X(string.Join(",", currentDirection_X_List));
        TovaDataGet.ReturnTovaData().SetTargetListDataDirections_Y(string.Join(",", currentDirection_Y_List));
        TovaDataGet.ReturnTovaData().SetTargetListDataDirections_Z(string.Join(",", currentDirection_Z_List));
    }

    #region TestWithInvoker
    void TestForInvoker()
    {

        Debug.Log(targets.Length);
        SetDataList();
        string lists = TovaDataGet.ReturnTovaData().GetTargetDataListDirections();
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListPositions_X());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListPositions_Y());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListPositions_Z());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListDirections_X());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListDirections_Y());
        Debug.Log(TovaDataGet.ReturnTovaData().GetTargetDataListDirections_Z());
        Debug.Log(lists + " all " + lists);
    }


    #endregion
}
