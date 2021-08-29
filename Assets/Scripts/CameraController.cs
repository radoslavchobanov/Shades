using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;

    void Start () 
    {
        offset = transform.position - Player.singleton.transform.position;
    }

    void LateUpdate () 
    {
        transform.position = Player.singleton.transform.position + offset;
    }
}
