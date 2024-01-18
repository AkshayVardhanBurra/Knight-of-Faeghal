using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask weapon;
    public float weaponDistance = 20f;

    public Inventory inventory;

    public Transform parentObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Input.GetKeyDown(KeyCode.R)){
            Debug.DrawRay(transform.position, transform.forward, Color.red, 7);
        }
        if(Input.GetKeyDown(KeyCode.R) && Physics.Raycast(transform.position, transform.forward, out hit, weaponDistance, weapon)){
            //Add weapon to inventory.
           

            

           
           hit.transform.SetParent(parentObj);
           hit.transform.localPosition = new Vector3(0,0,0);
           
 

           print(hit.transform.name + "Original");

           inventory.Add(hit.transform.gameObject);

            
            //else, it is a special weapon.
            
        }
    }
}
