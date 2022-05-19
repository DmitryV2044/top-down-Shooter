using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;

    public abstract void Shot();
}
