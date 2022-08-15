using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class LocalEventManager : MonoBehaviour
{

    public static Dictionary<string, Action<SocketIOEvent>> globalHandlers = new Dictionary<string, Action<SocketIOEvent>>();

    public static void On(string ev, Action<SocketIOEvent> callback)
    {
        if (!globalHandlers.ContainsKey(ev))
        {
            globalHandlers[ev] = new Action<SocketIOEvent>(callback);
        }
        // globalHandlers[ev] += callback;
    }

    public static void InvokeLocalEvent(string fnName, JSONObject data)
    {
        if (!globalHandlers.ContainsKey(fnName))
        {
            return;
        }
        SocketIOEvent ev = new SocketIOEvent(fnName, data);
        globalHandlers[fnName].Invoke(ev);
    }

}