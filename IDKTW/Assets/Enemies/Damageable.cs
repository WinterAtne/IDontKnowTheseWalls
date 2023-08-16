using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;
    [SerializeField] float invunlnerableTime;
    private int currentHealth;

    private bool isInvulnerable = false;

    public void Start() {
        currentHealth = maxHealth;
    }

    public void Damage(int damage) {

        if (isInvulnerable) return;
        currentHealth -= damage;

        StartCoroutine(InvunlnerableTime(invunlnerableTime));
        if (currentHealth <= 0) Die();
    }

    public void Heal(int health) {
        currentHealth += health;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    private void Die() {
        Destroy(this.gameObject);
    }

    IEnumerator InvunlnerableTime(float time) {
        isInvulnerable = true;
        yield return new WaitForSeconds(time);

        isInvulnerable = false;
    }
}
