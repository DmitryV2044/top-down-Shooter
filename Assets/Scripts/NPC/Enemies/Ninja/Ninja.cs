using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy
{
    private void OnEnable()
    {
        RadiusEntered += StartAttack;
        UpdateService.OnFixedUpdate += LookAtTarget;
    }
    
    public override void Attack()
    {
        //attack logic
        Follow(Target.transform);
    }

    private void LookAtTarget()
    {
        LookAtTarget(Target.transform);
    }

    private void OnDisable() {
        RadiusEntered -= Attack;
        UpdateService.OnFixedUpdate -= LookAtTarget;
    }
}
