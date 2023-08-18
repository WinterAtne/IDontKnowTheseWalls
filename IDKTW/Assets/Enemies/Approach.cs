using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    protected Vector2 target;
    protected bool timeAdjustedMovement = true;

    [SerializeField] float speed = 4f;
    [SerializeField] Vector2 offset;

    protected void ApproachTarget() {
        Vector3 desiredPosition = target + offset;
        float timedSpeed = speed;
        if (timeAdjustedMovement) timedSpeed *= Time.deltaTime;
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition,timedSpeed);

        transform.position = smoothedPosition;
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }
}
