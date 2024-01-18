using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackEnemiesAndPlayer : MonoBehaviour
{


    // Make an array of enemies.
    [SerializeField] GameObject[] enemies;

    // Count for number of enemies in scene.
    [SerializeField] int enemyCount;

    bool changed = false;
 
    // Start is called before the first frame update
    void Start()
    {
        // Load the enemies
        LoadEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        //If there are no enemies change the scene in 3 seconds.
        if(enemyCount  <= 0 && !changed){
            changed = true;
            Invoke("ChangeScene", 3);
            
        }
    }


// This function Loads the enemies by finding game objects with the tag enemy. it loads it into the array.
// Then it stores the length in the enemyCount variable.
    public void LoadEnemies(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

//Whenever an enemy dies, this function will get called.
    public void RemoveEnemy(){

        enemyCount --;
    }


// Method that handles changing scenes.
    public void ChangeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
