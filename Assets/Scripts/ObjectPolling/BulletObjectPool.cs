using System;
using UnityEngine;
using System.Collections.Generic;

public class BulletObjectPool : PersistentSingleton<BulletObjectPool>
{
    [SerializeField] private Bullet BulletPrefab;
    private Queue<Bullet> Pool = new Queue<Bullet>();

    public Bullet GetBullet()
    {
        if(Pool.Count == 0)
        {
            AddBullet(1);
        }
        Bullet bullet= Pool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;       
    }

    private void AddBullet(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(BulletPrefab);
            bullet.gameObject.SetActive(false);
            Pool.Enqueue(bullet);
        }
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        Pool.Enqueue(bullet);
    }

}
