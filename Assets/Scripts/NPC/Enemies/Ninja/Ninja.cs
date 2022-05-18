using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy
{
    private void OnEnable() => RadiusEntered += Attack;
    
    public override void Attack()
    {
        //attack logic
        Debug.Log("ATTACKING!");
    }

    private void OnDisable() => RadiusEntered -= Attack;
}
