using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAppearer : MonoBehaviour
{
    SpriteRenderer sr;
    Transform playerTransform;
    private Color color = Color.white;
    [SerializeField] bool useGlobalDecay = true; //determines weather to use the player's timer for when to flash
    [SerializeField] float localDecay = 1f;

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

        if (useGlobalDecay) {
            color.a += (Time.deltaTime / ma.DecayReduction()) * colorCorrector;
        } else {
            color.a += (Time.deltaTime / localDecay) * colorCorrector;
        }

        sr.color = color;
    }
}
