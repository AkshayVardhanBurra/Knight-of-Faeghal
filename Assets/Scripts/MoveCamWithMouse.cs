using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamWithMouse : MonoBehaviour
{
    // Declare variables for camera movement with mouse
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    float yRotation;
    float xRotation;
    public Transform orientation;

    // Pause checker
    public CheckForPause pauseChecker;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Get mouse input and update camera rotation accordingly
    private void Update()
    {
        // If the game isn't paused, allow for camera rotation
        if (!pauseChecker.paused)
        {
            // Get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotate camera and player orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
