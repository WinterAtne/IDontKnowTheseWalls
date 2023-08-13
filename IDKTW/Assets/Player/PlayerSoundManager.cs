using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    Rigidbody2D rigidbodyP;
    AudioManager am;

    private bool hasBegunWalking = false;
    private string walkSoundName = "WalkWoodenFloor";

    void Start() {
        rigidbodyP = this.GetComponent<Rigidbody2D>();
        am = GameObject.Find("EventSystem").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (rigidbodyP.velocity.magnitude != 0 && !hasBegunWalking) {
            hasBegunWalking = true;
            am.Play(walkSoundName);
        } else {
            hasBegunWalking = false;
            am.Pause(walkSoundName);
        }
    }
}
