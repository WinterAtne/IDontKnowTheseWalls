using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;
    [SerializeField] float invunlnerableTime;
    private int currentHealth;

    private bool isInvulnerable = false;
    [SerializeField] bool continueMoving = true;
    [SerializeField] MonoBehaviour movementScript;
    [SerializeField] float timeToFadeOnDeath = 2f;

    public void Start() {
        currentHealth = maxHealth;
    }

    public void Damage(int damage) {

        if (isInvulnerable) return;
        currentHealth -= damage;

        if (currentHealth <= 0) Die();
        StartCoroutine(InvunlnerableTime(invunlnerableTime));
    }

    public void Heal(int health) {
        currentHealth += health;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    IEnumerator InvunlnerableTime(float time) {
        isInvulnerable = true;
        yield return new WaitForSeconds(time);

        isInvulnerable = false;
    }

    void Die() {
        if (!continueMoving) {
            Destroy(movementScript);
            Debug.Log("I am ded");
        }
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        Destroy(this.gameObject, timeToFadeOnDeath);

    }
}
