using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSession : MonoBehaviour
{

    public void SessionStart()
    {
        FindObjectOfType<BackendSession>().StartSession();
    }
}
