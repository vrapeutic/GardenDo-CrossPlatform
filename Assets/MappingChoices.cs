using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MappingChoices : MonoBehaviour
{
    //[SerializeField] StringVariable typeOfAttention;//sustained //selective //adaptive
    ////choose environment
    //[SerializeField] IntVariable sustainedValue;
    //[SerializeField] IntVariable noOfDistractor;
    public MenuController menuController;

    public void Mapper(int[] settings)
    {
        //if (settings[0] == 1) typeOfAttention.Value= "sustained";
        //else if (settings[0] == 2) typeOfAttention.Value = "selective";
        //else typeOfAttention.Value = "adaptive";

        //if (settings[2] == 1) sustainedValue.Value = 20;
        //else if (settings[2] == 2) sustainedValue.Value = 40;
        //else sustainedValue.Value = 60;

        //if (settings[3] == 1) noOfDistractor.Value = 1;
        //else if (settings[3] == 2) noOfDistractor.Value = 2;
        //else noOfDistractor.Value = 3;
        //StartCoroutine(LoadGameScene());

        // Take the first and third elements
        int firstElement = settings[0]; // attention type
        int subLevel = firstElement == 1 ? settings[2] : settings[3]; // level number in attention type

        // Concatenate them to form a two-digit number
        int level = firstElement * 10 + subLevel;

        bool isGarden = settings[1] == 1; // scene selection - 1 = garden, 2 = balcony

        // settings regardless of level
        menuController.setLanguage(1); // default for now
        menuController.SetEnviroment(isGarden);
        menuController.SetCompleteCourse(false); // default for now
        menuController.SetVisualOnly(false); // default for now
        menuController.ChooseCharacter(Random.Range(0, 2));
        menuController.SetWateringCycle(4);
        menuController.SetFlowerGrowthPeriod(0);
        //menuController.SetCurrentFlowerIndeex(0);

        if (level == 11) // level 1
        {
            menuController.setLevel(1);
        }
        else if (level == 12) // level 2
        {
            menuController.setLevel(2);
            menuController.SetWateringCycle(8);
        }
        else if (level == 13) // level 3
        {
            menuController.setLevel(3);
            menuController.SetWateringCycle(12);
        }
        else if (level == 21) // level 4
        {
            menuController.setLevel(4);
        }
        else if (level == 22) // level 5
        {
            menuController.setLevel(5);
        }
        else if (level == 23) // level 6
        {
            menuController.setLevel(6);
        }
        else if (level == 31) // level 7
        {
            menuController.setLevel(7);
        }
        else if (level == 32) // level 8
        {
            menuController.setLevel(8);
        }
        else if (level == 33) // level 9
        {
            menuController.setLevel(9);
        }

        menuController.LoadScene();

    }

    //public IEnumerator LoadGameScene()
    //{
    //    yield return new WaitForSeconds(1);
    //    SceneManager.LoadScene(1);
    //}
}
