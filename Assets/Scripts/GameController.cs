using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance ;
    [SerializeField] EnemyBulletSpawner enemyBulletSpawner;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] BulletSpawner bulletSpawner;
    [SerializeField] MeteorSpawner meteorSpawner;
    [SerializeField] PlayerController playerController;

    public EnemyBulletSpawner EnemyBulletSpawner => enemyBulletSpawner; //getter
    public EnemySpawner EnemySpawner => enemySpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    public MeteorSpawner MeteorSpawner => meteorSpawner;
    public PlayerController PlayerController => playerController;
    private void Awake()
    {
        
            instance = this;
           
      
    }
  
}
