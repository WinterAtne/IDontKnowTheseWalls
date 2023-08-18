using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRoam : Approach
{
    [SerializeField] float timeBetweenMoves = 1f;

    [SerializeField] Vector2 targetLeft;
    [SerializeField] Vector2 targetRight;
    private bool roaming = false;

    void OnEnable() {
        timeAdjustedMovement = false;
        roaming = true;
        StartCoroutine(Roam());
    }

    void OnDisable() {
        roaming = false;
        StopCoroutine(Roam());
    }

    void ChoosePosition() {
        target = new Vector2(Random.Range(targetLeft.x, targetRight.x), Random.Range(targetLeft.y, targetRight.y));
    }

    public void SetTargets(Vector2 tarLeft, Vector2 tarRight) {
        targetLeft = tarLeft;
        targetRight = tarRight;
    }


    IEnumerator Roam() {
        while(roaming) {
            ApproachTarget();
            yield return new WaitForSeconds(timeBetweenMoves);
        }
    }
}
