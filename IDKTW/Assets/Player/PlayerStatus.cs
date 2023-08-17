using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    private int maxHealth = 3;
    private int currentHealth;

    private bool isDamageable = true;

    private float invunlnerableTime = 0.5f;

    public void Start() {
        currentHealth = maxHealth;
    }

    void SetHealth(int newHealth) {
        currentHealth = newHealth;
        ResetHealth();
    }
    

    void Damage(int damage) {
        if (!isDamageable) return;
        currentHealth -= damage;

        StartCoroutine(InvunlnerableTime());

        Debug.Log(currentHealth);
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<DamagingObject>()) {
            Damage(other.gameObject.GetComponent<DamagingObject>().Damage());
        }
    }

    IEnumerator InvunlnerableTime() {
        isDamageable = true;
        yield return new WaitForSeconds(invunlnerableTime);

        isDamageable = false;
    }
}
