using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    void SetHealth(int newHealth) {
        currentHealth = newHealth;
        ResetHealth();
    }
    

    void Damage(int damage) {
        currentHealth -= damage;
    }

    void Heal(int health) {
        currentHealth += health;

        ResetHealth();
    }

    void ResetHealth() {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
