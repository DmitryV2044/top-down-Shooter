using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    public Player Target => _target.GetComponent<Player>();

    public abstract void Attack();
}
