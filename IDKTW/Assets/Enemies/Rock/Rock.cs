using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    FreeRoam freeRoam;
    FollowBehind followBehind;

    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask playerMask;

    [SerializeField] Vector2 targetLeft;
    [SerializeField] Vector2 targetRight;

    [SerializeField] float speed;

    void Start() {
        freeRoam = this.gameObject.AddComponent<FreeRoam>();
        freeRoam.SetTargets(targetLeft, targetRight);
        freeRoam.SetSpeed(speed);

        followBehind = this.gameObject.AddComponent<FollowBehind>();
        followBehind.SetSpeed(speed);
    }

    void OnDestroy() {
        freeRoam.enabled = false;
        followBehind.enabled = false;
    }

    void FixedUpdate() {
        if (DetectPlayer()) {
            freeRoam.enabled = false;
            followBehind.enabled = true;
        }
        else {
            followBehind.enabled = false;
            freeRoam.enabled = true;
        }
    }

    bool DetectPlayer() {
        if (Physics2D.OverlapCircle(this.transform.position, detectionRadius, playerMask)) {
            return true;
        }
        else {
            return false;
        }
    }
}
