using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public PoolManager enemyPool;
    public EnemyBulletSpawner enemyBullet;
    private float timer =0f;
    [SerializeField] private float spawnInterval = 5.0f;
    [SerializeField] private float fireInterval;
   
    [SerializeField] public int wave = 0;
    public int defaultWave;
    [SerializeField] int[] enemiesPerWave = { 8, 12, 16 };
    private bool isWaveInProgress = false;
    Transform[] path;

    private void Start()
    {
        Instance = this;
        wave = GameConstact.levelDefault;
        if (GameMenuManager.Instance.isContinue)
        {
            wave = Mathf.Clamp( PlayerData.GetCurrentLevelPlayer()-1,0,3);
            
        }
      
        StartCoroutine(SpawnEnemy());
        
        
    }
    private void Update()
    {
        if (CheckIfWaveCompleted()&& !isWaveInProgress )
        {
          isWaveInProgress = true;
          SpawnNextWave();
        }

    }

    private void SpawnNextWave()
    {
        

        if (wave < enemiesPerWave.Length)
        {
            timer += Time.deltaTime;
            if (timer > spawnInterval)
            {
                wave++;
                if (wave >= enemiesPerWave.Length)
                {
                    //wave = enemiesPerWave.Length - 1;
                    BossSpawn();
                    return;
                }
                StartCoroutine(SpawnEnemy());
                timer =0f;
            }
        }


        isWaveInProgress =false;
      
    }

    public IEnumerator SpawnEnemy()
    {
        path = WaveManager.instance.GetRandomPath();  // Use the method to get random paths

        int totalEnemies = enemiesPerWave[wave];

        for (int i = 0; i < totalEnemies; i++)
        {
            Vector3 spawnPosition = path[0].position; // Keep Y position constant for wave 1

            SpawnEnemyAtPosition(spawnPosition);
            yield return new WaitForSeconds(0.5f);
        }


    }
    
    public void BossSpawn()
    {
        BossSpawner.Instance.SpawnBoss();
    }
    void SpawnEnemyAtPosition(Vector3 spawnPosition)
    {
        GameObject enemyGo = enemyPool.GetObject(spawnPosition, Quaternion.identity);
        enemyGo.transform.position = spawnPosition;
        Enemy enemy = enemyGo.GetComponent<Enemy>();
        enemy.EnemyInit(spawnPosition);
        AssignPathToEnemy(enemyGo);

    }

    public bool CheckIfWaveCompleted()
    {
        foreach (GameObject enemy in GameController.instance.EnemySpawner.enemyPool.GetPoolList())
        {
           if(enemy.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
  
    }
    public void RecycleEnemy(GameObject enemy)
    {
        enemyPool.ReturnPool(enemy);
    }

    void AssignPathToEnemy(GameObject enemy)
    {

        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
          
                enemyMovement.SetPath(path);
                Debug.Log($"Assigned path to {enemy.name}");
            
        }
    }

}
