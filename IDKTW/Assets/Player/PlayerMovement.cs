using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Transform transformP;
    Rigidbody2D rigidbodyP;

    AudioManager am;

    void Start() {
        transformP = this.GetComponent<Transform>();
        rigidbodyP = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rigidbodyP.velocity = (new Vector2(x, y)) * speed;
    }
}
