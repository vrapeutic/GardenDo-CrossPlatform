using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    List<EventListner> listners = new List<EventListner>();

    public void Raise()
    {
       // Debug.Log("Raise Enter");

        for (int i = 0; i < listners.Count; i++)
        {
            listners[i].OnEventRaise();
        }
    }
    public void Register (EventListner listner)
    {
        if(!listners.Contains(listner))
        {
            listners.Add(listner);
        }
    }
    public void UnRegister(EventListner listner)
    {
        if (listners.Contains(listner))
        {
            listners.Remove(listner);
        }
    }
}
