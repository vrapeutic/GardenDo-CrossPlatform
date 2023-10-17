using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;


public class LanguageSelection : MonoBehaviour
{
    [SerializeField] MeunuSequence menuSequence;

    Statistics stats;
    private void Awake()
    {
        /*
        if (Statistics.firstEnterMainMenu)
        {
            menuSequence.NextUI();
            //Destroy(gameObject);
        }
        */
    }

    private void Start()
    {
        //stats = Statistics.instane;
        ////InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        ////NetworkManager.InvokeClientMethod("OnLanguageSelectRPC", invokationManager);
        //if (stats.firstEnterMainMenu)
        //{
        //    menuSequence.NextUI();
        //    //Destroy(gameObject);
        //}
    }

    public void OnLanguageSelect(int languageNO)
    {
        OnLanguageSelectRPC(languageNO);
       // NetworkManager.InvokeServerMethod("OnLanguageSelectRPC", this.gameObject.name, languageNO);
        //stats.firstEnterMainMenu = true;
    }

    public void OnLanguageSelectRPC(int languageNO)
    {
        Statistics.languageIndex = languageNO;
        //gameObject.SetActive(false);
    }
}

