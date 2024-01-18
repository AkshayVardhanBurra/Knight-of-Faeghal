using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeaponAttack : MonoBehaviour
{
    // Start is called before the first frame update


// Get a references to Inventory and animation activator of current weapon.
    public Inventory inventory;
    public AnimationActivator activator;

// Get the index of the currently equipped weapon.
    public int currentIndex = 0;

    // Get the instance of the current weapon.
    public GameObject currentWeapon;
    void Start()
    {
        // Current weapon should equal the current weapon in the list of weapons.
        currentWeapon = inventory.weapons[currentIndex];
        activator = currentWeapon.GetComponent<AnimationActivator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Change current weapon in this script when user changes their weapon.

        if(currentIndex!= inventory.currently_equipped_index){
            currentIndex = inventory.currently_equipped_index;
            currentWeapon = inventory.weapons[currentIndex];
            activator = currentWeapon.GetComponent<AnimationActivator>();
        }
        
    }

// This method will  be used as a event in the attack animation.
    void Attack(){
        Debug.LogWarning("Attackihng");
        activator.Attack();
    }
}
