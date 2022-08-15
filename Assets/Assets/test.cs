using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public AnimationEventsHandler instance;
    // Start is called before the first frame update
    void Start()
    {
        instance.HandleEvent(0);
    }

}
