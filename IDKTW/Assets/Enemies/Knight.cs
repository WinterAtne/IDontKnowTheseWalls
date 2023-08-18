using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    FreeRoam freeRoam;
    FollowBehind followBehind;
    Stay stay;

    [SerializeField] float detectionRadius;
    [SerializeField] float attackRadius;
    [SerializeField] LayerMask playerMask;

    [SerializeField] Vector2 targetLeft;
    [SerializeField] Vector2 targetRight;

    [SerializeField] float speed;
    [SerializeField] float timeToAttack;

    void Start() {
        freeRoam = this.gameObject.AddComponent<FreeRoam>();
        freeRoam.SetTargets(targetLeft, targetRight);
        freeRoam.SetSpeed(speed);
        followBehind = this.gameObject.AddComponent<FollowBehind>();
        followBehind.SetSpeed(speed);
        stay = this.gameObject.AddComponent<Stay>();
    }

    void FixedUpdate() {
        if (DetectPlayer(attackRadius)) {
            freeRoam.enabled = false;
            followBehind.enabled = false;
            WaitAttack();
        }
        else if (DetectPlayer(detectionRadius)) {
            freeRoam.enabled = false;
            StopCoroutine(WaitAttack());
            followBehind.enabled = true;
        }
        else {
            followBehind.enabled = false;
            StopCoroutine(WaitAttack());
            freeRoam.enabled = true;
        }
    }

    bool DetectPlayer(float radius) {
        if (Physics2D.OverlapCircle(this.transform.position, radius, playerMask)) {
            return true;
        }
        else {
            return false;
        }
    }

    IEnumerator WaitAttack() {
        yield return new WaitForSeconds(timeToAttack);
        Attack();
    }

    void Attack() {
        Debug.Log("I steb u!");
        return;
    }
}
