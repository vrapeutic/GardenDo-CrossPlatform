using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{

    string number = null;
    int index = -1;
    string id = null;
    string id2 = null;
    [SerializeField] InputField idInputField = null;
    char[] idNumber = new char[30];
    public void UserNumberEntry(string _selectedNumber)
    {
        idInputField.placeholder.gameObject.GetComponent<Text>().text = null;
        index++;
        char[] keepChar = _selectedNumber.ToCharArray();
        idNumber[index] = keepChar[0];
        id = idNumber[index].ToString();
        number = number + id;
        idInputField.text = number;


    }
    public void DeleteNumber()
    {
        if (index >= 0)
        {
            index--;
            id2 = null;
            for (int i = 0; i < index + 1; i++)
            {
                id2 = id2 + idNumber[i].ToString();
            }
            number = id2;
            idInputField.text = number;

        }
       
    }
}
