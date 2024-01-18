using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will run on the title screen and only the title screen
public class QuitCheck : MonoBehaviour
{
    // Check to see if user wants to quit by hitting escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Hello there!");
            Application.Quit();
        }
    }
}
