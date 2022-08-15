using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowData : MonoBehaviour
{
    [SerializeField] string arrowsTag;
    GameObject[] arrows;
    float currentId = 0;
    float arrowAngle;
    public Transform bow;

    Dictionary<string, List<string>> currentList = new Dictionary<string, List<string>>();
    List<string> ArrowstList = new List<string>();

    public bool isReleased = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isReleased == true)
        {
            arrows = GameObject.FindGameObjectsWithTag(arrowsTag);

            arrowAngle = Vector3.Angle(bow.transform.position, bow.transform.forward);
            //Debug.Log("angle" + arrowAngle);

            //arrowAngle = bow.transform.localRotation.eulerAngles.x;
            isReleased = false;
            Debug.Log(string.Join(", ", GetArrowsList().ToArray()));

        }
    }

    List<string> GetArrowsList()
    {
        foreach (GameObject arrow in arrows)
        {
            if (currentId < arrows.Length)
                currentId++;
            else return ArrowstList;



            currentList[arrowsTag + " " + currentId.ToString()] = new List<string>() { arrowsTag + " " + currentId.ToString(), arrowAngle.ToString() };

            Debug.Log(string.Join(", ", currentList[arrowsTag + " " + currentId.ToString()]));
            ArrowstList.Add(string.Join(", ", currentList[arrowsTag + " " + currentId.ToString()]));
            Debug.Log(string.Join(", ", ArrowstList.ToArray()));
        }
        return ArrowstList;
    }

}
