using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    public Player Target;

    public abstract void Attack();
}
