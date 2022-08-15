using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUI : MonoBehaviour
{
    WaitForSeconds a2seconds = new WaitForSeconds(2f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExchanngeImage());
    }
    
    //To controll UI blinking
    IEnumerator ExchanngeImage()
    {
        while (true)
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
            transform.GetChild(1).transform.gameObject.SetActive(true);
            yield return a2seconds;
            transform.GetChild(0).transform.gameObject.SetActive(true);
            transform.GetChild(1).transform.gameObject.SetActive(false);
            yield return a2seconds;
        }
    }
}
