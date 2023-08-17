using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour
{
    [SerializeField] int damage;

    public int Damage() {
        return damage;
    }
}
