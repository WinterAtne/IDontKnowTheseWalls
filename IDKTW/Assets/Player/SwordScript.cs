using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    static SwordScript instance;
    float rotation;

    int damage = 1;
    float deployTime = 0.2f;

    private Camera cameraP;
    void Start() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        cameraP = GameObject.Find("Camera").GetComponent<Camera>();
        UpdateRotation(); //Avoids a glitch where for one frame it appears that the sword sticks straight out;
        Invoke("SheathSword", deployTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Damageable>() != null) {
            other.gameObject.GetComponent<Damageable>().Damage(damage);
        }

        SheathSword();
    }

    public void UpdateRotation() {
        this.transform.Rotate(0f, 0f, -rotation);
        

        Vector3 attackDirectionPoint = cameraP.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        rotation = Mathf.Atan((attackDirectionPoint.y) / (attackDirectionPoint.x)) * (180 / 3.1415f);

        //I don't know why the Atan function doesn't return values greater than 90 or less than -90, and I don't care to ask at this point
        if (attackDirectionPoint.x < 0 ) {
            rotation += 180f;
        }
        this.transform.Rotate(0f, 0f, rotation);
    }

    public void SheathSword() {
        Destroy(this.gameObject);
    }
}
