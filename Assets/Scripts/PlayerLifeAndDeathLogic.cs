using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeAndDeathLogic : MonoBehaviour
{
    // Create player health variables
    public int PLAYER_MAX_HEALTH;
    public int playerHealth;
    public bool alive;

    // Connect player health to health bar
    public HealthBar healthBar;

    // Connect player life and death to rigidbody so I can isKinematic it when they die
    Rigidbody rb;

    // Health Potion variables
    public bool healthPotReady;
    public float healthPotCooldown;
    public KeyCode healthPotButton;
    public int healthPotHealAmt;
    public GameObject hPCVisualComponent;

    public float deathTime;

    // Make player alive and set health to max health
    private void Start()
    {
        playerHealth = PLAYER_MAX_HEALTH;
        healthBar.SetMaxHealth(PLAYER_MAX_HEALTH);
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        alive = true;
        ResetHealthPotion();
    }

    // Check to see if player is alive, if not go to death scene
    private void Update()
    {
        // Death logic
        if (playerHealth <= 0)
        {
            alive = false;
        }
        if (!alive)
        {
            rb.isKinematic = true;
            Invoke(nameof(Die), deathTime);
        }

        // Health potion logic
        if (Input.GetKeyDown(healthPotButton) && healthPotReady)
        {
            healthPotReady = false;
            hPCVisualComponent.SetActive(true);
            dealDamageToPlayer(-healthPotHealAmt);
            Invoke(nameof(ResetHealthPotion), healthPotCooldown);
        }
    }

    // Get method for player health
    public int getPlayerHealth()
    {
        return playerHealth;
    }

    // Deal damage to player (set method for player health)
    public void dealDamageToPlayer(int damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
    }

    // Reset health potion cooldown
    public void ResetHealthPotion()
    {
        healthPotReady = true;
        hPCVisualComponent.SetActive(false);
        Debug.Log("Health Potion Ready");
    }

    // Reload the scene on player death
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
