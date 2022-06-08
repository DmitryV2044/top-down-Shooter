using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock17 : Gun
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject poolBullets;
    [SerializeField] private Camera camera;
    
    private EnumGuns.TypeOfGun _typeOfGun = EnumGuns.TypeOfGun.Glock17;
    private GameObject _player;

    private Glock17BulletsPoll _pool;

    private float _rotZ;
    public float rotZ { get; set; }

    public float offset;


    private void Start()
    {
        this._player = GameObject.FindGameObjectWithTag("Player");
        this._pool = this.poolBullets.GetComponent<Glock17BulletsPoll>();

        this.offset = 0f;
        
        this.haveBulletsInClip = 16;
        this.maxBulletsInClip = 16;
        this.haveBullets = 64;

        var controller = this._player.GetComponent<PlayerController>();
        controller.WhatIsGun(this._typeOfGun);
    }


    public override void Shot()
    {
        if (this.timeBtwShot <= 0 && haveBulletsInClip > 0)
        {
            this.haveBulletsInClip -= 1;
            this._pool.GetBullet(this.shotPoint);
            this.timeBtwShot = this.startTimeBtwShot;

            RaycastHit2D hitInfo = Physics2D.Raycast(this.shotPoint.position, this.shotPoint.right);
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if(enemy != null)
                    enemy.TakeDamage(damage);
            }
        }
        else
            this.timeBtwShot -= Time.deltaTime;
    }
    public override void ReloadGun()
    {
        this.haveBullets += this.haveBulletsInClip;
        this.haveBulletsInClip = 0;

        if (this.haveBullets >= this.maxBulletsInClip)
        {
            this.haveBulletsInClip += this.maxBulletsInClip;
            this.haveBullets -= this.maxBulletsInClip;
        }
        else if (this.haveBullets > 0)
        {
            this.haveBulletsInClip += this.haveBullets;
            this.haveBullets = 0;
        }

    }
    
}
