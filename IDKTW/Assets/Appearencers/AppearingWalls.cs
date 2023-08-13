using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingWalls : MonoBehaviour
{

    SpriteRenderer sr;
    private Color color = Color.white;
    private float decayReduction = 2f;


    void Awake() {
        sr = this.GetComponent<SpriteRenderer>();
        color.a = 0f;
    }

    void Update() {
        sr.color = color;
        color.a -= Time.deltaTime / decayReduction;
    }

    public void Lighten(float DR) {
        color.a = 1f;

        decayReduction = DR;
    }
}
