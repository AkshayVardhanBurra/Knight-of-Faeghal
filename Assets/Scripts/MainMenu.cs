using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Move to the first cutscene on button click
    public void Play()
    {
        SceneManager.LoadScene("Cutscene 1");
    }
}
