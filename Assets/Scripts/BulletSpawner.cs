using System.IO.Pipes;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] public int speed = 5;
    public static BulletSpawner instance;
    public PoolManager bulletPool;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fireInterval = 2f;
    private float fireTimer = 0f;
    private int bulletCount =1;


    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not assigned in the Inspector!", this);
            return;
        }

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            FirePowerUp();
            fireTimer = 0f;  // Reset the timer
        }
    }

    void FirePowerUp()
    {
        if (bulletCount == 1)
        {
            BulletLv1();
        }
        else if (bulletCount == 2)
        {
            BulletLv2();
        }
        else
        {
            BulletLv3();
        }
    }

    //void BulletLevel1()
    //{

    //    Vector3 fireDirection = Vector3.up;
    //    Vector3 position = playerTransform.position + fireDirection;
    //    GameObject bulletGo = bulletPool.GetObject(fireDirection, Quaternion.identity);
    //    Bullet bullet = bulletGo.GetComponent<Bullet>();
    //    bulletGo.transform.position = position;
    //    bullet.Init(() =>
    //    {
    //        Recycle(bulletGo);
    //    });
    //    bullet.Fire(fireDirection);
    //}

    //void BulletLevel2()
    //{
    //    Vector3 fireDirection = Vector3.up;

    //    Vector3 position1 = playerTransform.position + new Vector3(-0.2f, 0, 0) + fireDirection;
    //    Vector3 position2 = playerTransform.position + new Vector3(0.2f, 0, 0) + fireDirection;

    //    GameObject bulletGo1 = bulletPool.GetObject(fireDirection, Quaternion.identity);
    //    GameObject bulletGo2 = bulletPool.GetObject(fireDirection, Quaternion.identity);

    //    Bullet bullet1 = bulletGo1.GetComponent<Bullet>();
    //    Bullet bullet2 = bulletGo2.GetComponent<Bullet>();

    //    bulletGo1.transform.position = position1;
    //    bulletGo2.transform.position = position2;

    //    bullet1.Init(() =>
    //    {
    //        Recycle(bulletGo1);
    //    });
    //    bullet2.Fire(fireDirection);

    //    bullet1.Init(() =>
    //    {
    //        Recycle(bulletGo2);
    //    });
    //    bullet1.Fire(fireDirection);
    //}

    //void BulletLevel3()
    //{
    //    // First bullet (straight ahead)
    //    Vector3 fireDirection = Vector3.up;
    //    Vector3 position = playerTransform.position + fireDirection;
    //    GameObject bulletGo = bulletPool.GetObject(fireDirection, Quaternion.identity);
    //    Bullet bullet = bulletGo.GetComponent<Bullet>();
    //    bulletGo.transform.position = position;
    //    bullet.Init(() =>
    //    {
    //        Recycle(bulletGo);
    //    });
    //    bullet.Fire(fireDirection);

    //    // Second bullet (Right diagonal upward)
    //    float angleDegrees = 85;
    //    float angleRadians = angleDegrees * Mathf.Deg2Rad;
    //    Vector3 moveDirection1 = new Vector3(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0).normalized;
    //    Vector3 positionRight = playerTransform.position + moveDirection1;
    //    GameObject bulletGoRight = bulletPool.GetObject(moveDirection1, Quaternion.identity);
    //    Bullet bulletRight = bulletGoRight.GetComponent<Bullet>();
    //    bulletGoRight.transform.position = positionRight;
    //    bulletRight.Init(() =>
    //        {
    //            Recycle(bulletGoRight);
    //        });
    //    bulletRight.Fire(moveDirection1);

    //    // Thỉd bullet (Left diagonal upward)

    //    Vector3 moveDirection2 = new Vector3(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0).normalized;
    //    Vector3 positionLeft = playerTransform.position + moveDirection2;
    //    GameObject bulletGoLeft = bulletPool.GetObject(moveDirection2, Quaternion.identity);
    //    Bullet bulletLeft = bulletGoLeft.GetComponent<Bullet>();
    //    bulletGoLeft.transform.position = positionLeft;
    //    bulletLeft.Init(() =>
    //    {
    //        Recycle(bulletGoLeft);
    //    });
    //    bulletLeft.Fire(moveDirection2);

    //} //

    void BulletLv1()
    {
        Vector3 direction = Vector3.up;
        Vector3 position = playerTransform.position + direction;
        SpawnBulletPosition(direction, position);

    }
    void BulletLv2()
    {
        Vector3 direction = Vector3.up;
        Vector3 position1 = playerTransform.position + new Vector3(-0.2f, 0, 0) + direction;
        Vector3 position2 = playerTransform.position + new Vector3(0.2f, 0, 0) + direction;
        SpawnBulletPosition(direction,position1);
        SpawnBulletPosition(direction,position2);
    }
    void BulletLv3()
    {
        float angleDegrees = 85;
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        Vector3 direction1 = Vector3.up;
        Vector3 direction2 = new Vector3(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)).normalized;
        Vector3 direction3 = new Vector3(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)).normalized;
        
        Vector3 Position1 = playerTransform.position + direction1;
        Vector3 Position2 = playerTransform.position + direction2;
        Vector3 Position3 = playerTransform.position + direction3;

        SpawnBulletPosition(direction1,Position1);
        SpawnBulletPosition(direction2, Position2);
        SpawnBulletPosition(direction3, Position3);

    }
    void SpawnBulletPosition(Vector3 direction, Vector3 potition)
    {
        GameObject bulletGo = bulletPool.GetObject(direction, Quaternion.identity);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bulletGo.transform.position = potition;
        bullet.Init(() =>
        {
            Recycle(bulletGo);
        });
        bullet.Fire(direction);
    }
   
    public void BulletSpeedUp(int amount)
    {
        speed += amount;
    }
    public void BulletFireUp(float amount)
    {
        fireInterval -= amount;
        if(fireInterval <= 0.1f)
        {
            fireInterval = 0.1f;
        }
        Debug.Log("Fire speed:" +  fireInterval);
    }

    public void Recycle(GameObject bullet)
    {
        bulletPool.ReturnPool(bullet);
    }

    public void DoubleFire(int amount)
    {
        bulletCount += amount;
    }
    
}
