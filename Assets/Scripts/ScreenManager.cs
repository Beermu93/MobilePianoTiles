using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowDebugScreenInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowDebugScreenInfo()
    {
        Debug.Log("Screen Width: " + Screen.width);
        Debug.Log("Screen Height: " + Screen.height);
        Debug.Log("Screen Aspect Ratio: " + ((float)Screen.width / (float)Screen.height));
    }
}
