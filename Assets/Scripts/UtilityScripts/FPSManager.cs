using UnityEngine;
using UnityEngine.UI;

public class FPSManager : MonoBehaviour
{
    private float refreshSpeed = 1.0f; // the time between updating the fps text on the screen

    private Text fpsTextComponent;
    private float elapsedTime = 0f;

    private void Start() 
    {
        if (this.TryGetComponent<Text>(out Text outComponent))
            fpsTextComponent = outComponent;
        else Debug.Log("FPSManager: Text component not found!");
    }

    private void Update() 
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= refreshSpeed)
        {
            elapsedTime = 0f;
            fpsTextComponent.text = GetFPSText();
        }
    }

    private string GetFPSText()
    {
        return "fps: " + ((int)(1.0f/Time.deltaTime)).ToString();
    }
}
