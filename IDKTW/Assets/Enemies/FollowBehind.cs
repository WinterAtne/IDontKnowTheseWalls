using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehind : MonoBehaviour
{
    Transform target;

    [SerializeField] float lerpSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    void Awake() {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, lerpSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
