using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    protected Vector2 target;

    [SerializeField] float speed = 4f;
    [SerializeField] Vector2 offset;

    void LateUpdate() {
        Vector3 desiredPosition = target + offset;
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);

        transform.position = smoothedPosition;
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }
}
