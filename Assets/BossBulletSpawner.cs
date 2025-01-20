using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossBulletSpawner : MonoBehaviour
{
    public PoolManager bossBulletPool;
    public Transform motherShip;
    public Transform Ship1;
    public Transform Ship2;

    private float FireInterval =2f;
    private float fireTimer = 0f;
    private void Start()
    {

    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (FireInterval <= fireTimer)
        {
            Level1();
            fireTimer = 0f;

        }
    }
    public void Level1()
    {

        Vector3 position1 = motherShip.transform.position;
        BulletSpawn(position1);

        Vector3 position2 = Ship1.transform.position;
        BulletSpawn(position2);

        Vector3 position3 = Ship2.transform.position;
        BulletSpawn(position3);


    }

    public void BulletSpawn(Vector3 position)
    {
        GameObject enemyBulletGo = bossBulletPool.GetObject(position, Quaternion.identity);
        EnemyBullet bullet = enemyBulletGo.GetComponent<EnemyBullet>();
        enemyBulletGo.transform.position = position;
        bullet.Init(() =>
        {
            Recycle(enemyBulletGo);
        });
        bullet.Fire(position);
    }
    public void Recycle(GameObject bullet)
    {
        bossBulletPool.ReturnPool(bullet);
    }


}

