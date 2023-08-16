using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmmiter : MonoBehaviour
{
    FairyScript fs;
    Transform fairyTransform;
    [SerializeField] float radius;

    void Start() {
        fairyTransform = GameObject.Find("Fairy").GetComponent<Transform>();
        fs = GameObject.Find("Fairy").GetComponent<FairyScript>();
        if (!fs.Emmit(this.transform.position)) Destroy(this);
        Debug.Log(fs.Emmit(transform.position));
    }

    void FixedUpdate() {
        if (Vector3.Distance(fairyTransform.position, this.transform.position) <= radius) {
            fs.Emmit(this.transform.position);
        }
    }
}
