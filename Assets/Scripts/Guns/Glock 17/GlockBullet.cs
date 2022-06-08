using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockBullet : Bullet
{
    private Rigidbody2D _rigidbody;
    
    private void OnEnable()
    {
        UpdateService.OnUpdate += MoveBullet;
        StartCoroutine(DisableBulletCoroutine());
    }

    private void Start()
    {
        this.speed = 20;
        this.damage = 2;
        this.lifeTime = 2;

        this._rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void MoveBullet()
    {
        this._rigidbody.AddForce(this.transform.right * this.speed, ForceMode2D.Impulse);
    }
    
    private IEnumerator DisableBulletCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        this.gameObject.SetActive(false);
    }
    
    private void OnDisable()
    {
        UpdateService.OnUpdate -= MoveBullet;
    }
}
