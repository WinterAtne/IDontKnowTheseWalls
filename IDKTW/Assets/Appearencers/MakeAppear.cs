using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAppear : MonoBehaviour
{
    [SerializeField] float decayReduction = 1f;

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<AppearingWalls>()) {
            collision.gameObject.GetComponent<AppearingWalls>().Lighten(decayReduction);
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<AppearingWalls>()) {
            collision.gameObject.GetComponent<AppearingWalls>().Lighten(decayReduction);
        }
    }

    public float DecayReduction() {
        return decayReduction;
    }
}
