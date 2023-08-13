using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpable : MonoBehaviour
{
    Rigidbody2D rigidbodyO;
    AudioManager am;

    private bool moving = false;
    [SerializeField] private string soundName = "BumpIntoWood";

    void Start() {
        rigidbodyO = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void Update()
    {
        PlaySound();
        Debug.Log(moving);
    }

    void PlaySound() {
        if (rigidbodyO.velocity.magnitude != 0 && !moving) {
            moving = true;
            am.Play(soundName);
        } else if (rigidbodyO.velocity.magnitude == 0 && moving) {
            moving = false;
            am.Pause(soundName);
        }
    }
}
