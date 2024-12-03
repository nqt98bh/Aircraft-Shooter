using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public static EnemyBulletSpawner Instance;
    public PoolManager enemyBulletPool;
    [SerializeField] private float maxInterval;
    [SerializeField] private float minInterval;
    
    private float FireInterval;
    private float fireTimer = 0f;

    private void Start()
    {
        Instance = this;
        FireInterval = Random.Range(minInterval, maxInterval);

    }

    private void Update()
    {
       fireTimer += Time.deltaTime;
        if (FireInterval <= fireTimer)
        {
            EnemyFire();
            fireTimer = 0f;
            FireInterval = Random.Range(minInterval, maxInterval);

        }
    }
    public void EnemyFire()
    {
        foreach (GameObject enemy in GameController.instance.EnemySpawner.enemyPool.GetPoolList())
        {
            if(enemy.activeInHierarchy == false)
            {
                continue;
            }
            Vector3 position = enemy.transform.position;
            GameObject enemyBulletGo = enemyBulletPool.GetObject(position, Quaternion.identity);
            EnemyBullet bullet = enemyBulletGo.GetComponent<EnemyBullet>();
            enemyBulletGo.transform.position = position;
            bullet.Init(() =>
            {
                Recycle(enemyBulletGo);
            });
            bullet.Fire(position);
          
            
        }

    }
    public void Recycle(GameObject bullet)
    {
        enemyBulletPool.ReturnPool(bullet);
    }

 
}
