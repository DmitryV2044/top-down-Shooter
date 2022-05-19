using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    public Player Target;
    public int health;

    public abstract void Attack();
    public abstract void TakeDamage(int damage);
}
