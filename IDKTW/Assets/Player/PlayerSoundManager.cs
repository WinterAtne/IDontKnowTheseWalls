using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    Rigidbody2D rigidbodyP;
    AudioManager am;

    private float threashold = 1f;

    private bool hasBegunWalking = false;
    private string walkSoundName = "WalkWoodenFloor";
    private string[] walkSoundList;

    void Start() {
        rigidbodyP = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<FloorSoundMaker>()) {
            am.Pause(walkSoundName);
            walkSoundName = other.gameObject.GetComponent<FloorSoundMaker>().Sound();
            am.Play(walkSoundName);
        }
    }

    void Update()
    {
        PlayWalkingSound();
    }

    void PlayWalkingSound() {
        if (rigidbodyP.velocity.magnitude > threashold && !hasBegunWalking) {
            hasBegunWalking = true;
            am.Play(walkSoundName);
        } else if (rigidbodyP.velocity.magnitude <= threashold) {
            hasBegunWalking = false;
            am.Pause(walkSoundName);
        }
    }
}
