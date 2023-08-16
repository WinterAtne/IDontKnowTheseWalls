using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Transform transformP;
    Rigidbody2D rigidbodyP;

    private bool movementLocked;

    void Start() {
        transformP = this.GetComponent<Transform>();
        rigidbodyP = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (movementLocked) return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rigidbodyP.velocity = (new Vector2(x, y)) * speed;
    }

    public void LockMovement() {
        movementLocked = true;
    }

    public void UnlockMovement() {
        movementLocked = false;
    }
}
