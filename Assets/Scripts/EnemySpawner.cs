using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public PoolManager enemyPool;
    public EnemyBulletSpawner enemyBullet;
    private float timer;
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float fireInterval;
    [SerializeField] float verticalOffset = 4f; // Offset in the vertical direction (Y-axis)
    [SerializeField] float verticalSpacing = 3f;
    [SerializeField] int numberOfRows = 2;
    [SerializeField] int wave = 0;
    [SerializeField] private int[] enemiesPerWave = { 4, 6, 12 };
    private bool isWaveInProgress = false;
    public Transform other;

    private void Start()
    {
        instance = this;
        SpawnEnemy();
    }
    private void Update()
    {
        
        if (CheckIfWaveCompleted()&& !isWaveInProgress)
        {
          isWaveInProgress = true;
          Invoke("SpawnNextWave", 3f);
        }

    }

    void SpawnNextWave()
    {
        if (wave < enemiesPerWave.Length)
        {
            wave++;
            SpawnEnemy();
           
        }
        
        isWaveInProgress=false;
    }

    void SpawnEnemy()
    {
        Camera mainCamera = Camera.main;

        int totalEnemies = enemiesPerWave[wave];
        // Get the screen's width in world units
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float halfScreenWidth = cameraWidth / 2;
        float distanceBetweenEnemies = cameraWidth / (totalEnemies + 1);
        if (wave == 0)
        {
            FirstWave(totalEnemies, halfScreenWidth, distanceBetweenEnemies, cameraWidth);
        }
        else
        {
            NextWave(totalEnemies, halfScreenWidth, distanceBetweenEnemies, cameraWidth);
        }
     


    }
    void FirstWave(int totalEnemies, float halfScreenWidth, float distanceBetweenEnemies, float cameraWidth)
    {
        float xPositionOffset = -halfScreenWidth + (cameraWidth / (totalEnemies + 1));
        for (int i = 0; i < totalEnemies; i++)
        {
            float xPosition = xPositionOffset + i * distanceBetweenEnemies; // Evenly spaced positions
            Vector3 spawnPosition = new Vector3(xPosition, verticalOffset, 0); // Keep Y position constant for wave 1
            SpawnEnemyAtPosition(spawnPosition);
        }
    }
    void NextWave(int totalEnemies, float halfScreenWidth, float distanceBetweenEnemies, float cameraWidth)
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            float yPosition = verticalOffset + (row * verticalSpacing);
            for (int i = 0; i < totalEnemies / 2; i++)
            {
                float xPosition = -halfScreenWidth + (i + 1) * distanceBetweenEnemies; // Spawn position on the left half
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);
                SpawnEnemyAtPosition(spawnPosition);
            }
            for (int i = 0; i < totalEnemies / 2; i++)
            {
                float xPosition = halfScreenWidth - (i + 1) * distanceBetweenEnemies;
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);
                SpawnEnemyAtPosition(spawnPosition);
            }
        }
    }
    void SpawnEnemyAtPosition(Vector3 spawnPosition)
    {
        GameObject enemyGo = enemyPool.GetObject(spawnPosition, Quaternion.identity);
        enemyGo.transform.position = spawnPosition;
        Enemy enemy = enemyGo.GetComponent<Enemy>();
        enemy.EnemyInit();
    }

    bool CheckIfWaveCompleted()
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

    public void Enemycount(int amount)
    {

    }
}
