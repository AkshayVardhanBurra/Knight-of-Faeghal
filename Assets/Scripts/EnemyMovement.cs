using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class EnemyMovement : MonoBehaviour
{
    // Set up the NavMesh
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // Additional user-made classes
    public CheckForPause pauseCheck;
    public PlayerLifeAndDeathLogic hitPlayer;

    // Patrol variables
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Quip variable Unspoken
    public bool unspoken = true;

    // Attacking variables
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int attackDamage;

    // States
    public float sightRage, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    bool first = false;

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        alreadyAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for sight or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRage, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //playerInAttackRange = Math.Abs(Vector3.Distance(player.position, transform.position)) <= attackRange ;
        Debug.Log(playerInAttackRange);
        // Enemy Logic
        if (pauseCheck.paused) agent.SetDestination(transform.position);
        else if (playerInAttackRange) Attacking();
        else if (playerInSightRange) Chasing();
        else Chasing();
    }

    // This method allows the enemy to move toward a set walk point if the player is not nearby
    private void Patrolling()
    {
        // If there is no point to walk to, find one, otherwise move toward it
        // if (!walkPointSet) SearchWalkPoint();
        // else agent.SetDestination(walkPoint);

        // // Calculate distance from set point
        // Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // // When the enemy reaches a walkpoint, prepare to search for a new one
        // if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;

        agent.SetDestination(transform.position);
        
    }

    // This method allows the enemy to search for and set a walk point to move to
    // private void SearchWalkPoint()
    // {
    //     // Find random point to move to
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     // Set random point to move to
    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //     // If random point is on ground, confirm walk point
    //     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    // }

    // This method allows the enemy to chase the player if they enter a certain range
    private void Chasing()
    {
       
      animator.Play("Walk");
    
            
        
        
        // Simply set a point where the player is and move to it
        agent.SetDestination(player.position);

        // If we want any audio cues during random times during a chase they can go here
        // if (unspoken)
        // {
        //     unspoken = false;
        //     Invoke(nameof(Quip), Unity.Random.Range(3, 10));
        // }
    }

    // This method allows the enemy to attack if the player gets too close
    private void Attacking()
    {
        
        // Stop the enemy and look straight into the player's soul, letting them know death is knocking at their door
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        // If the enemy has not already attacked, make it attack
        if (!alreadyAttacked)
        {
            // For now, there is a debug message here so I know this works. Akshay's attack script will go here.
            Debug.Log("Attack! Thou shalt breathe thy final breath at the top of this fateful morrow!");
            // Deal damage to player
            hitPlayer.dealDamageToPlayer(attackDamage);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("zombie_attack")){
    
            animator.Play("zombie_attack");
            }
    
            

            // Attack cooldown
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    // Just a method for things to do when attack resets
    private void ResetAttack()
    {
        // Setting alreadyAttacked to false allows the enemy to attack again
        alreadyAttacked = false;
    }

    // Enemy will say something based while chasing the player
    // private void Quip()
    // {
    //     string[] possibleQuips = {"I love you!", "Die, foul beast!", "We've been trying to reach you about your car's extended warranty", "I am the Grapple Gremlin! Yaaah!", "etc.", "Put those foolish ambitions to rest.", "No one outfoxes Arquebus.", "I won't miss.", "Eternus is our salvation!", "Sure! Noooo!"};
    //     Debug.Log(possibleQuips[Random.Range(0, possibleQuips.Length)]);
    //     unspoken = true;
    // }
}
