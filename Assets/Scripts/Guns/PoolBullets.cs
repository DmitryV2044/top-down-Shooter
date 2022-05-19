using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBullets : MonoBehaviour
{
    [SerializeField] private int poolCount = 10;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Bullet bulletPrefab;

    private PoolManager<Bullet> pool;

    private void Start()
    {
        this.pool = new PoolManager<Bullet>(this.bulletPrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }
    
    public void CreateBullet(Transform shotPoint)
    {
        var bullet = this.pool.GetFreeElement();
        bullet.transform.position = shotPoint.position;
    }
}
