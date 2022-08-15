using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventListner : MonoBehaviour
{
    public GameEvent Event ;
    public UnityEvent response;
    public bool invokedOnce;
    private void OnEnable()
    {
        Event.Register(this);
    }
    private void OnDisable()
    {
        Event.UnRegister(this);
    }
    public void OnEventRaise()
    {
        response.Invoke();
        invokedOnce = true;
    }
}
