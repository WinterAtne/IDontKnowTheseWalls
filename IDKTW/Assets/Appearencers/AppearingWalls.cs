using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingWalls : MonoBehaviour
{
    [SerializeField] private bool usePlayerDecay = true;
    [SerializeField] private bool sensor = false;
    [SerializeField] private float decayReduction = 2f;

    SpriteRenderer sr;
    private Color color = Color.white;


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
        if (usePlayerDecay) {
            decayReduction = DR;
        }

        if (!GetComponent<MakeAppear>() && sensor) {
            this.gameObject.AddComponent<MakeAppear>();
            Destroy(this.gameObject.GetComponent<MakeAppear>(), decayReduction);
        }
    }
}
