using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy
{
    public int health = 3;
    private void OnEnable()
    {
        AddRadiusReaction(Target.transform, 10);// Target даст фабрика, радиус из конфига (но присваевается в фабрике)
                                                //Да и вообще этот метод будет вызываться в фабрике, но фабрики пока что нет))
        RadiusEntered += Attack;
    }

    public override void Attack()
    {
        Debug.Log("ATTACKING!");
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
            Debug.Log("ENEMY IS DIE");
    }

    private void OnDisable()
    {
        RadiusEntered -= Attack;
    }
}
