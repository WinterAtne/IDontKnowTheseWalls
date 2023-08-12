using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAppearer : MonoBehaviour
{
    SpriteRenderer sr;
    Transform playerTransform;
    private Color color = Color.white;

    MakeAppear ma;

    private float colorCorrector;

    void Awake() {
        sr = this.GetComponent<SpriteRenderer>();
        ma = GameObject.Find("Player").GetComponent<MakeAppear>();
    }

    void FixedUpdate() {
        if (color.a <= 0) {
            colorCorrector = 1;
        } else if (color.a >= 1) {
            colorCorrector = -1;
        }

        color.a += (Time.deltaTime / ma.DecayReduction()) * colorCorrector;
        Debug.Log(color.a);

        sr.color = color;
    }
}
