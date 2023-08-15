using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] GameObject sword;

    private PlayerMovement playerMovement;
    private Rigidbody2D playerRigidBody;
    private Camera cameraP;

    void Start() {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        cameraP = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update() {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return; //To ensure we don't do anything besides attack;

        StabAttack();
    }
    void StabAttack() {
        Vector3 attackDirectionPoint = cameraP.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(attackDirectionPoint.x - transform.position.x, attackDirectionPoint.y - transform.position.y);

        GameObject swordInstance = Instantiate(sword, transform);
        swordInstance.GetComponent<Transform>().up = direction;
    }
}
