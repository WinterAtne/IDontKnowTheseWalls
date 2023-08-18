using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFollow : Approach
{
    [SerializeField] float timeBetweenMoves = 1f;

    [SerializeField] Vector2 targetLeft;
    [SerializeField] Vector2 targetRight;
    private bool following = false;

    private Transform transformP;

    void OnEnable() {
        timeAdjustedMovement = false;
        following = true;
        StartCoroutine(Roam());

        try {
            transformP = GameObject.Find("Player").GetComponent<Transform>();
        }
        catch {
            this.enabled = false;
        }
    }

    void OnDisable() {
        following = false;
        StopCoroutine(Roam());
    }

    void Update() {
        target = transformP.position;
    }


    IEnumerator Roam() {
        while(following) {
            ApproachTarget();
            yield return new WaitForSeconds(timeBetweenMoves);
        }
    }
}
