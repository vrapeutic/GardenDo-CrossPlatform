using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
public class MeunuSequence : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    int currentUIIndex;

    private void Start()
    {

        if (!Statistics.instane.firstEnterMainMenu)
        currentUIIndex =0;
        else currentUIIndex = -1;

        ShowUI();
    }

    public void NextUI()
    {
        Debug.Log("NextUI");
        currentUIIndex++;
        ShowUI();
    }

    public void PreviousUI()
    {
        Debug.Log("PreviousUI");
        currentUIIndex--;
        ShowUI();
    }

    void ShowUI()
    {
        for (int i =0;i< panels.Length; i++)
        {
            if (i == currentUIIndex)
            {
                panels[currentUIIndex].SetActive(true);
                Debug.Log("True : " + panels[currentUIIndex].name);
            }
            else
            {
                panels[i].SetActive(false);
                Debug.Log("False : " + panels[i].name);
            }            
        }
    }
}
