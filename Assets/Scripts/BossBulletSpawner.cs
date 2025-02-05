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

    private float FireInterval = 2f;
    private float fireTimer = 0f;
  
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (FireInterval <= fireTimer)
        {
            BulletLevel();
            fireTimer = 0f;

        }
    }
    
    private void BulletLevel()
    {
        if (EnemySpawner.Instance.wave == 3)
        {
            if (BossScript.instance.bossHP > 700 || BossScript.instance.bossHP <= 1000)
            {
                Level1();
            }
            else if (BossScript.instance.bossHP > 300 || BossScript.instance.bossHP <= 7000)
            {
                Level2();
            }
            else { }
        }
        
    }
    private void Level1()
    {

        Vector3 position1 = motherShip.transform.position ;
        BossBulletSpawn(Vector3.down,position1);

        Vector3 position2 = Ship1.transform.position;
        BossBulletSpawn(Vector3.down, position2);

        Vector3 position3 = Ship2.transform.position;
        BossBulletSpawn(Vector3.down, position3);


    }
    private void Level2()
    {
        float angleDegrees = 75;
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        Vector3 direction1 = Vector3.down;
        Vector3 direction2 = new Vector3(Mathf.Cos(angleRadians), -Mathf.Sin(angleRadians)).normalized;
        Vector3 direction3 = new Vector3(-Mathf.Cos(angleRadians), -Mathf.Sin(angleRadians)).normalized;

        Vector3 Position1 = motherShip.position + direction1;
        Vector3 Position2 = Ship1.position + direction2;
        Vector3 Position3 = Ship2.position + direction3;

        BossBulletSpawn(direction1, Position1);
        BossBulletSpawn(direction2, Position2);
        BossBulletSpawn(direction3, Position3);
    }


    public void BossBulletSpawn(Vector3 derection ,Vector3 position)
    {
        GameObject enemyBulletGo = bossBulletPool.GetObject(position + new Vector3(0,-1,0), Quaternion.identity);
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

