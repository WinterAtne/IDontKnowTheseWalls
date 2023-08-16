using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] GameObject sword;

    private PlayerMovement playerMovement;
    private Rigidbody2D playerRigidBody;
    

    void Start() {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return; //To ensure we don't do anything besides attack;

        StabAttack();
    }
    void StabAttack() {
        GameObject swordInstance = Instantiate(sword, transform);
    }
}
