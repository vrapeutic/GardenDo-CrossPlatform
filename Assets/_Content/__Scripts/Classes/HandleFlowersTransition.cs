using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandleFlowersTransition : MonoBehaviour
{
    [SerializeField]
    GameObject playerHeadCollider;
    [SerializeField]
    GameObject bucketCollider;
    [SerializeField]
    Flower[] flowers;
    int flowerIndex = 0;
    [SerializeField]
    GameEvent gameFinished;
  //  [SerializeField]
    //Text indexText;
    Statistics stats;
    int numberOfFLower;
    public static bool tasksAreDone = false;
    private void Start()
    {

        stats = Statistics.instane;
        numberOfFLower = stats.numberOfFlowers;
        flowerIndex = 0;
        if (numberOfFLower > 4 && numberOfFLower < 10)
        {
            for (int i = 4; i <= 8; i++)
            {
                flowers[i].gameObject.SetActive(true);
                
            }
        }
        else if (numberOfFLower > 10)
        {
            for (int i = 8; i <= stats.numberOfFlowers; i++)
            {
                flowers[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 4; i <= 12; i++)
            {
                flowers[i].gameObject.SetActive(false);
            }
        }
        flowers[numberOfFLower ].gameObject.SetActive(false);
    //    indexText.text = "current index =" + flowerIndex + "flower number =" + stats.numberOfFlowers;
    }
    public void ReadyForWatering()
    {
        flowerIndex = 0;
        playerHeadCollider.GetComponent<Collider>().enabled = true;
        bucketCollider.GetComponent<Collider>().enabled = true;
        flowers[0].GetReadyForWatering();
        flowerIndex++;

    }



    public void MakeNextFlowerReady()
    {
        flowers[flowerIndex].GetReadyForWatering();
        flowerIndex = flowerIndex + 1;

        Debug.Log(numberOfFLower+"flower index " + flowerIndex);
        if (flowerIndex > numberOfFLower )
        {
            FinishGame();
            tasksAreDone = true;
            Debug.Log("task finished"+numberOfFLower);
        }

        Debug.Log("make next flower ready called");
      //  indexText.text = "current index =" + flowerIndex + "flower number =" + stats.numberOfFlowers;
    }

    public void FinishGame()
    {

        gameFinished.Raise();
        Debug.Log("game finished");
      //  indexText.text = "current index =" + flowerIndex + "flower number =" + stats.numberOfFlowers;
    }

}
