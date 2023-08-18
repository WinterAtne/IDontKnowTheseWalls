using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehind : Approach
{

    private Transform transformP;

    void OnEnable() {
        try {
            transformP = GameObject.Find("Player").GetComponent<Transform>();
        }
        catch {
            this.enabled = false;
        }
    }

    void Update() {
        target = transformP.position;

        ApproachTarget();
    }
}
