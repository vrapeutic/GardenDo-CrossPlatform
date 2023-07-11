using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTargetMovement : MonoBehaviour
{

    NodeTrigger[] nodes;
    [SerializeField]
    GameObject player;
    Vector3 startPosition;
    Quaternion startRotation;
    Coroutine MoveDistructorCoroutine;
    //start postion for maze
    [SerializeField]
    float speed;
    int curretNode;
    float timer;
    static Vector3 currentPositionHolder;
    static Quaternion currentRotationHolder;
    WaitForSeconds waitTime = new WaitForSeconds(0.002f);
    //hold node postion
    // Use this for initialization
    void Awake()
    {
        nodes = GetComponentsInChildren<NodeTrigger>();
        CheckNodes();
    }
    //check held current node to current postion Holder
    private void CheckNodes()
    {

        timer = 0;
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        currentPositionHolder = nodes[curretNode].transform.position;
        currentRotationHolder = nodes[curretNode].transform.rotation;


    }

    private void Start()
    {
        if (MoveDistructorCoroutine != null)
            StopCoroutine(MoveDistructorCoroutine);
        MoveDistructorCoroutine = StartCoroutine(Movement());
    }

    //public void MoveDistructor()
    //{

    //    if (MoveDistructorCoroutine != null)
    //        StopCoroutine(MoveDistructorCoroutine);
    //    MoveDistructorCoroutine=StartCoroutine(Movement());

    //}

    IEnumerator Movement()
    {
        while (true)
        {
            
                //Debug.Log(curretNode);
                timer += Time.deltaTime * speed;
                // this make the path moves
                if (player.transform.position != currentPositionHolder)
                {
                    //move player to the node
                    player.transform.position = Vector3.Lerp(startPosition, currentPositionHolder, timer);
                     player.transform.rotation = Quaternion.Lerp(startRotation, currentRotationHolder, timer);
            }
                else if (curretNode < nodes.Length - 1)
                {
                    //go to next one
                    curretNode++;
                    CheckNodes();
                }
            else if (curretNode == nodes.Length - 1)
            {
                curretNode = 0;
            }

            yield return waitTime;
        }
    }

    private void OnEnable()
    {
        // Restart the coroutine when the object is set active
        if (MoveDistructorCoroutine == null)
        {
            MoveDistructorCoroutine = StartCoroutine(Movement());
        }
    }

    private void OnDisable()
    {
        // Stop the coroutine when the object is deactivated
        if (MoveDistructorCoroutine != null)
        {
            StopCoroutine(MoveDistructorCoroutine);
            MoveDistructorCoroutine = null;
        }
    }
}
