using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpable : MonoBehaviour
{
    Rigidbody2D rigidbodyO;
    AudioManager am;

    [SerializeField] private string[] soundName;

    void Start() {
        rigidbodyO = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void PlaySound() {
        am.Play(soundName[Random.Range(0,soundName.Length)]);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        PlaySound();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        PlaySound();
    }
}
