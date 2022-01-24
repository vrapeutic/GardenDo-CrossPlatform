using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tachyon;
using UnityEngine.UI;
public class EndSession : MonoBehaviour
{
    public static bool isExitClicked;
    public static bool isMenuClicked;
    private bool canEnterEndCanvasIEnum = true;
    bool canEnterCanvas = true;
    [SerializeField] GameObject endCanvas;
    [SerializeField] GameObject onPlayCanvas;
    [SerializeField] GameObject savePanel;
    //text for testing stats
   // [SerializeField] GameObject debugText;


    public static EndSession instance = new EndSession();

    Statistics stats;
    private void Awake()
    {
        //Debug.Log("LeveL End : " + stats.level);
        if (instance == null) instance = this;
        else Destroy(this);


        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = Statistics.instane;
        canEnterEndCanvasIEnum = true;
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("GameOverRPC", invokationManager);
    }


    public void GameOver()
    {
        if (!Statistics.android)
        {
            try
            {
               StatisticsManager.instance.OnSendStatistics();
                Debug.Log("stats  send");

            }
            catch
            {
                Debug.Log("stats not send");
            }
            EndGameCanvas();
           // StartCoroutine(EndCanvasIEnum());
        }
        Debug.Log("Game Over Buton /// ");
        //  NetworkManager.InvokeServerMethod("GameOverRPC", this.gameObject.name);
    }

    public void GameOverRPC()
    {


        Debug.Log("Game Over Start !! ");
    }
    IEnumerator EndCanvasIEnum()
    {

        // send stats RPC on stats manager
        if (!canEnterEndCanvasIEnum) yield break;
        //  if (Statistics.android) StatisticsManager.instance.OnSendStatistics();
        canEnterEndCanvasIEnum = false;
        if (HandleFlowersTransition.tasksAreDone) yield return new WaitForSeconds(3f);
        else yield return new WaitForSeconds(4f);
        try
        {
          //  StatisticsManager.instance.ResetStatistics();
            
        }
        catch
        {
            Debug.Log("reset stats failed");
        }
        if (!Statistics.android)
        {/*
            endCanvas.SetActive(true);
            savePanel.SetActive(false);
            onPlayCanvas.SetActive(false);*/
        }
    }

    void EndGameCanvas()
    {
        if (!canEnterEndCanvasIEnum) return;
        canEnterCanvas = true;
        endCanvas.SetActive(true);
        savePanel.SetActive(false);
        onPlayCanvas.SetActive(false);
       // StatisticsManager.instance.ResetStatistics();
    }

    public void SaveConfirmed()
    {
        GameOver();
    }

    public void SaveDenied()
    {
        // StatisticsManager.instance.ResetStatistics();
         endCanvas.SetActive(true);
         savePanel.SetActive(false);
         onPlayCanvas.SetActive(false);
    }

    public void QuitSession()
    {
        savePanel.SetActive(true);
    }




}
