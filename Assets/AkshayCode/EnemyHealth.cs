using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

//stores the health.
    public float health;
    bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageHealth(float damage){
        // deduct health.
        health -= damage;

        if(health <= 0 && !died){
            died = true;
            print("Enemy Died!");
            GameObject.FindGameObjectWithTag("WaveManager").GetComponent<TrackEnemiesAndPlayer>().RemoveEnemy();
            Destroy(transform.gameObject);
            
            
        }   
    }
}
