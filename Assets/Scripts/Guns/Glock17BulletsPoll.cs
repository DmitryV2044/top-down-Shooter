using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock17BulletsPoll : MonoBehaviour
{
    [SerializeField] private int poolCount = 10;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Bullet bulletPrefab;

    private PoolManager<Bullet> _poolManager;
    private Glock17 _glock17;

    private void Start()
    {
        var gun = GameObject.FindGameObjectWithTag("Gun");
        this._glock17 = gun.GetComponent<Glock17>();
        
        this._poolManager = new PoolManager<Bullet>(this.bulletPrefab, this.poolCount, this._glock17.transform);
        this._poolManager.autoExpand = this.autoExpand;
    }
    
    public void GetBullet(Transform shotPoint)
    {
        var bullet = this._poolManager.GetFreeElement();
        bullet.transform.position = shotPoint.position;
    }
}
