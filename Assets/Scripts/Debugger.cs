using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    public static void Log(object message)
    {
        if (Constants.singleton.DEBUG)
            Debug.Log(message);
    }
    public static void Log(Object obj, object message)
    {
        if (Constants.singleton.DEBUG)
            Debug.Log(obj.name + ": " + message);
    }
}
