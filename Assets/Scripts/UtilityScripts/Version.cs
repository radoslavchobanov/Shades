using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    public static string version = "0.0.3";

    private void Start() 
    {
        this.GetComponent<Text>().text += version;
    }
}
