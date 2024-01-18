using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPause : MonoBehaviour
{
    // Declare paused variable
    public bool paused;

    // Create GameObject for the pause panel
    public GameObject pauseMenu;

    // Set paused to false
    void Start()
    {
        paused = false;
    }

    // Check to see if player wants to pause/resume game
    void Update()
    {
        // Toggle pause status by hitting esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        // Enable/Disable pause menu if game is or is not paused
        if (paused)
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
