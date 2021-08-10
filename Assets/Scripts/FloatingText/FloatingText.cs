using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject textGO; // 
    public Text textComponent;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        textGO.SetActive(true);
    }

    public void Hide()
    {
        active = false;
        textGO.SetActive(false);
    }

    public void Update()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        textGO.transform.position += motion * Time.deltaTime;
    }
}
