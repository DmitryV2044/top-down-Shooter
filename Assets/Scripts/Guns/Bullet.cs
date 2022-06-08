using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float lifeTime;
    public float distance;
    public float speed;
    public int damage;
    public LayerMask whatIsSolid;
}
