using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<GameObject> weapons = new List<GameObject>();
    

    public int currently_equipped_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Reset all the weapons.
        ResetWeapons();

        //weapons count is printed.
        print(weapons.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Scroll through list of weapons based on which direction the scroll wheel is going in.
        if(Input.GetAxis("Mouse ScrollWheel") >= 0.05f){
           //Change the weapon.
            currently_equipped_index = (currently_equipped_index + 1) % weapons.Count;
            ResetWeapons();
            
        } else if(Input.GetAxis("Mouse ScrollWheel") <= -0.05f){
            
            //Change the weapon.
            if(currently_equipped_index != 0){
                currently_equipped_index -= 1;
            }
            ResetWeapons();
        }
    }


//This function deactivates all weapons that aren't equipped.
    void ResetWeapons(){
        for(int i=0; i < weapons.Count; i++){
            if(currently_equipped_index != i){
                weapons[i].SetActive(false);
            }else{
                weapons[i].SetActive(true);
            }
        }
    }


//Add a weapon.
    public void Add(GameObject weapon){
        weapons.Add(weapon);
        UpdateList();
        ResetWeapons();
    }


//Update the list of weapons.
    public void UpdateList(){
        weapons = new List<GameObject>();

        foreach(AnimationActivator obj in transform.GetComponentsInChildren<AnimationActivator>()){
            weapons.Add(obj.gameObject);
        }
    }
}
