using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xSens;
    public float ySens;

    float rotationx;
    float rotationy;

    public Transform orientation;

    public CheckForPause pauseChecker;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only runs if the game is not paused
        if (!pauseChecker.paused)
        {
            // Mouse x is the x rotation

            float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;

            // Mouse y is the y value for how fast the mouse is moving.
            float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;


            //Add or subtract them from the rotations.
            rotationy += mouseX;
            rotationx -= mouseY;



            //Set the rotation of the player
            rotationx = Mathf.Clamp(rotationx, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationx, rotationy, 0);

            orientation.rotation = Quaternion.Euler(0, rotationy, 0);
        }
        /*
        // Mouse x is the x rotation

        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;

        // Mouse y is the y value for how fast the mouse is moving.
        float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;


        //Add or subtract them from the rotations.
        rotationy += mouseX;
        rotationx -= mouseY;

    

        //Set the rotation of the player
        rotationx = Mathf.Clamp(rotationx, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationx, rotationy, 0);

        orientation.rotation = Quaternion.Euler(0, rotationy, 0);
        */




    }
}
