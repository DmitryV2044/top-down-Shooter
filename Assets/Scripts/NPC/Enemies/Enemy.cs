using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    public Player Target => _target.GetComponent<Player>();

    internal float minDistance;
    internal bool isAttacking;

    public virtual void StartAttack()
    {
        if (isAttacking) return;
        UpdateService.OnTick += Attack;
        isAttacking = true;
        Debug.Log("Attack started");
    }

    public virtual void Attack() { MaintainDistance(_target, 10, 11); }
}
