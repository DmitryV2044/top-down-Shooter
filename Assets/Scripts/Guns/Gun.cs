using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int damage;
    
    public int haveBulletsInClip;
    public int maxBulletsInClip;
    public int haveBullets;

    public float timeBtwShot;
    public float startTimeBtwShot;
    
    public Transform shotPoint;

    public bool isAutomatic = false;

    public abstract void Shot();
    public abstract void ReloadGun();
}
