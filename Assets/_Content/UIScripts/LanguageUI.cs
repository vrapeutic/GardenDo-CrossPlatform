using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUI : MonoBehaviour
{
    [SerializeField]
    MeunuSequence menuSequence;
    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
        if (!menuSequence)
        {
            menuSequence = FindObjectOfType<MeunuSequence>();
        }
        if (stats.firstEnterMainMenu)
        {
            menuSequence.NextUI();
        }
    }


    void Update()
    {

    }
}
