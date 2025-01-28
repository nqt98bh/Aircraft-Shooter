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

    private void Awake()
    {
        if (instance == null)
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


    void BulletLv1()
    {
        Vector3 direction = Vector3.up;
        Vector3 position = playerTransform.position + direction;
        SpawnBulletPosition(direction, position);
        BulletFireFX();

    }
    void BulletLv2()
    {
        Vector3 direction = Vector3.up;
        Vector3 position1 = playerTransform.position + new Vector3(-0.2f, 0, 0) + direction;
        Vector3 position2 = playerTransform.position + new Vector3(0.2f, 0, 0) + direction;
        SpawnBulletPosition(direction,position1);
        SpawnBulletPosition(direction,position2);
        BulletFireFX();

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
        BulletFireFX();


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

    public void BulletFireFX()
    {

        FireEffectSpawner.Instance.FireFXSpawner();

    }
}
