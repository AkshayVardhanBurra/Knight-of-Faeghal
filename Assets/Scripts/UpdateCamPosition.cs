using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCamPosition : MonoBehaviour
{
    // Store camera position within this variable
    public Transform cameraPosition;

    // Update camera to cameraPosition every frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
