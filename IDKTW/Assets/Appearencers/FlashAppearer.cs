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

    private float colorCorrector = 1f;

    void Start() {
        sr = this.GetComponent<SpriteRenderer>();
        ma = GameObject.Find("Player").GetComponent<MakeAppear>();

        color.a = Random.Range(0f, 0.99f);
        colorCorrector = Random.Range(0, 2);
        if (colorCorrector == 0) colorCorrector = -1;
    }

    void FixedUpdate() {
        if (color.a <= 0f) {
            colorCorrector = 1f;
        } else if (color.a >= 1f) {
            colorCorrector = -1f;
        }

        if (useGlobalDecay) {
            color.a += (Time.deltaTime / ma.DecayReduction()) * colorCorrector;
        } else {
            color.a += (Time.deltaTime / localDecay) * colorCorrector;
        }

        sr.color = color;
    }
}
