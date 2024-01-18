using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivator : MonoBehaviour
{

    //Get the activator
    [SerializeField] Animator animator;

    //Get the is change
    private bool change = false;

    // Is it swingable yet? Basically checks against time to see if we can swing the sword.
    private float swingable = 0f;

    // The reload time of the sword
    [SerializeField] float reloadTime = 2f;


    // How far does the sword hit
    [SerializeField] float regularRange = 3f;
    float range;

    // Get the transform.
    [SerializeField] Transform camera;

    [SerializeField] LayerMask enemy;

    // Allows weapon animations to be rendered futile when game is paused
    public CheckForPause pauseChecker;

    // Start is called before the first frame update
    void Start()
    {
        range = regularRange;
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is paused, set sword range to 0 so you can't hit enemies. Otherwise, set it back to default range.
        if (pauseChecker.paused)
        {
            range = 0;
        }
        else
        {
            range = regularRange;
        }

        //If mouse button is pressed and sword is ready to swing, swing sword.
        if(Input.GetMouseButtonDown(0) && Time.time >= swingable){
            if(!change){
                animator.Play("swing right");
            }
            swingable = Time.time + reloadTime;

        }
    }

    public void Attack(){
        //Raycast and get the enemy


        // Get information about the hit.
        RaycastHit hit;

        // Shoot a raycast to look get the enemy if its an enemy.
        if(Physics.Raycast(camera.position, camera.forward, out hit, range, enemy)){
            GameObject enemy = hit.transform.gameObject;
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            // Deal damage to the enemy.
            health.DamageHealth(20);
            print("Hit enemy");
        }
    }
}
