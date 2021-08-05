using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Constants singleton;

    [SerializeField] public bool DEBUG; // true -> printing actions in the console ... false -> no printing


    private void Awake() 
    {
        if (singleton == null)
            singleton = this;
        else 
            Debugger.Log("More than one Constants !!!");
    }

    private void Start() 
    {
    }
}
