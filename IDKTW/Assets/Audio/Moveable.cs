using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    Rigidbody2D rigidbodyO;
    AudioManager am;

    float threashold = 1f;

    private bool moving = false;
    [SerializeField] private string soundName = "BumpIntoWood";

    void Start() {
        rigidbodyO = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void Update()
    {
        PlaySound();
    }

    void PlaySound() {
        if (rigidbodyO.velocity.magnitude > threashold && !moving) {
            moving = true;
            am.Play(soundName);
        } else if (rigidbodyO.velocity.magnitude <= threashold && moving) {
            moving = false;
            am.Pause(soundName);
        }
    }
}
