using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{

    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Close game
    public void quitGame()
    {
        print("Quitting");
        Application.Quit();
    }
}
