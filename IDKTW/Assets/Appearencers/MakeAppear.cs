using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAppear : MonoBehaviour
{
    [SerializeField] float decayReduction = 2f;

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Appearer")) {
            collision.gameObject.GetComponent<AppearingWalls>().Lighten(decayReduction);
        }
    }

    public float DecayReduction() {
        return decayReduction;
    }
}
