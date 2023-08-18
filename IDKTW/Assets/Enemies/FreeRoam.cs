using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoam : Approach
{
    [SerializeField] Vector2 targetLeft;
    [SerializeField] Vector2 targetRight;

    void OnEnable() {
        ChoosePosition();
    }

    void Update() {
        if (transform.position == new Vector3(target.x, target.y, 0f)) {
            ChoosePosition();
        }

        ApproachTarget();
    }

    void ChoosePosition() {
        target = new Vector2(Random.Range(targetLeft.x, targetRight.x), Random.Range(targetLeft.y, targetRight.y));
    }

    public void SetTargets(Vector2 tarLeft, Vector2 tarRight) {
        targetLeft = tarLeft;
        targetRight = tarRight;
    }
}
