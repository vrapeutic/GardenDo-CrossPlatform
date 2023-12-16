using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tachyon;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] instruction;

    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
        InvokationManager invokationManager = new InvokationManager(this, this.gameObject.name);
        NetworkManager.InvokeClientMethod("LoadSceneRPC", invokationManager);
        NetworkManager.InvokeClientMethod("setLevelRPC", invokationManager);
        NetworkManager.InvokeClientMethod("LoadMainMenuRPC", invokationManager);
        NetworkManager.InvokeClientMethod("ChooseCharacterRPC", invokationManager);
        NetworkManager.InvokeClientMethod("SetCompleteCourseRPC", invokationManager);
        NetworkManager.InvokeClientMethod("SetWateringCycleRPC", invokationManager);
        NetworkManager.InvokeClientMethod("SetEnviromentRPC", invokationManager);
        NetworkManager.InvokeClientMethod("ExitModuleRPC", invokationManager);
        stats.currentFlowerIndex = 0;
    }

    public void ShowInstructionsUI(int _number)
    {
        if (_number != stats.instructionNumber)
        {
            instruction[(_number - 1)].SetActive(true);
        }
        else
        {
            instruction[(_number - 1)].SetActive(false);
        }
    }

    public void DisableInstructionsUI(GameObject instructionsToShow)
    {
        for (int i = 0; i < instruction.Length; i++)
        {
            instruction[i].SetActive(false);
        }
    }

    public void ChangeMenue(GameObject MenueToAppear)
    {
        MenueToAppear.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LoadScene()
    {
        LoadSceneRPC();
       // NetworkManager.InvokeServerMethod("LoadSceneRPC", this.gameObject.name);
    }
    public void SetCompleteCourse(bool isCompleteCourse)
    {
        SetCompleteCourseRPC(isCompleteCourse);
        Debug.Log("set course ");
       // NetworkManager.InvokeServerMethod("SetCompleteCourseRPC", this.gameObject.name, isCompleteCourse);
    }
    public void SetCompleteCourseRPC(bool isCompleteCourse)
    {
        Debug.Log("set course RPC");
        stats.isCompleteCourse = isCompleteCourse;
    }

    public void SetEnviroment(bool isGarden)
    {
        //
        SetEnviromentRPC(isGarden);
       // NetworkManager.InvokeServerMethod("SetEnviromentRPC", this.gameObject.name, isGarden);
    }
    public void SetEnviromentRPC(bool isGarden)
    {
        stats.isGardenEnviroment = isGarden;
        Debug.Log(stats.isGardenEnviroment);
        Debug.Log(isGarden);
    }

    public void setLevel(int level)
    {
        Debug.Log("set level ");
        stats.instructionNumber = level;
        // NetworkManager.InvokeServerMethod("setLevelRPC", this.gameObject.name, level);
       setLevelRPC(level);
    }
    public void setLevelRPC(int level)
    {
        Debug.Log("set level RPC");
        stats.level = level;
        Debug.Log("LeveL : " + stats.level);
    }
    public void SetWateringCycle(int wateringCycle)
    {
        SetWateringCycleRPC(wateringCycle);
       // NetworkManager.InvokeServerMethod("SetWateringCycleRPC", this.gameObject.name, wateringCycle);
    }
    public void SetWateringCycleRPC(int wateringCycle)
    {
        stats.numberOfFlowers = wateringCycle;
        stats.totalNumberOfTasks = wateringCycle;
        Debug.Log("number of flowers " + wateringCycle);
    }

    public void SetVisualOnly(bool isVisualOnly)
    {
        stats.isVisualOnly = isVisualOnly;
    }

    public void ChooseCharacter(int characterNo)
    {
        ChooseCharacterRPC(characterNo);
       // NetworkManager.InvokeServerMethod("ChooseCharacterRPC", this.gameObject.name, characterNo);
    }
    public void ChooseCharacterRPC(int characterNo)
    {
        stats.character = characterNo;
    }

    public void LoadSceneRPC()
    {



        if (stats.isGardenEnviroment)
        {
            SceneManager.LoadScene("Garden");
        }
        else
        {
            SceneManager.LoadScene("Balacony");
        }

    }

    public void LoadMainMenu()
    {
        //
        //StatisticsManager.instance.OnSendStatistics();
        NetworkManager.InvokeServerMethod("LoadMainMenuRPC", this.gameObject.name);
        Invoke("LoadMainMenuRPC", 4f);
    }

    public void LoadMainMenuRPC()
    {
        //FindObjectOfType<BackendSession>().StartSession();
        //CSVWriter.Instance.WriteEndTime();
        CSVWriter.Instance.WriteCSV();
        SceneManager.LoadScene("Main Menu");
        Destroy(FindObjectOfType<TovaDataGet>().gameObject);
    }


    public void ExitModule()
    {
        Debug.Log("Exit Module");
        //ServerRequest.instance.SendPutRequest();

        //StatisticsManager.instance.OnSendStatistics();
        Invoke("ExitModuleRPC", 0f);
        /*if (!Statistics.android)*/
        //NetworkManager.InvokeServerMethod("ExitModuleRPC", this.gameObject.name);
        // 
    }

    public void ExitModuleRPC()
    {
        Invoke("bye", 0f);

        Debug.Log("bye");


    }

    public void bye()
    {
        Debug.Log("Exit Module RPC");
        //StartCoroutine(ExitEnum());     
        //if (Statistics.android)
            Application.Quit();
    }

    //IEnumerator ExitEnum()
    //{
    //    //if (Statistics.android)
    //    //    JsonPreparation.instance.PutRequest();
    //    NetworkManager.instance.DisconnectToServer();
    //    yield return new WaitForSeconds(1);
    //    if (Statistics.android) SceneManager.LoadScene("Lobby");
    //    else Application.Quit();
    //}
}
