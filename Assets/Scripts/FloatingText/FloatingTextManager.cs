using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager singleton;

    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Awake() 
    {
        if (singleton == null)
            singleton = this;    
    }

    private void Update() 
    {
        foreach (FloatingText txt in floatingTexts)
            txt.Update(); 
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText temp = GetFloatingText();

        temp.textComponent.text = msg;
        temp.textComponent.fontSize = fontSize;
        temp.textComponent.color = color;

        temp.textGO.transform.position = Camera.main.WorldToScreenPoint(position);
        temp.motion = motion;
        temp.duration = duration;

        temp.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText temp = floatingTexts.Find(t => !t.active);

        if (temp == null)
        {
            temp = new FloatingText();
            temp.textGO = Instantiate(textPrefab);
            temp.textGO.transform.SetParent(textContainer.transform);
            temp.textComponent = temp.textGO.GetComponent<Text>();

            floatingTexts.Add(temp);
        }

        return temp;
    }
}
