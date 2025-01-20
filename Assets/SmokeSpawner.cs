using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    public static SmokeSpawner Instance;
    public PoolManager FireFXPool;
    private float timer = 0;
    [SerializeField] float recycleTime = 1f;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SmokeFXSpawner()
    {
        SmokeFXSpawn();
        timer += Time.deltaTime;
        if (timer >= recycleTime)
        {
            RecycleFX(gameObject);
            timer = 0;
        }

    }
    public void SmokeFXSpawn()
    {
        foreach (GameObject enemy in GameController.instance.EnemySpawner.enemyPool.GetPoolList())
        {

            Vector3 spawnPosition = enemy.transform.position;
            GameObject smokeFXGo = FireFXPool.GetObject(spawnPosition, Quaternion.identity);
            smokeFXGo.transform.position = spawnPosition;
            Effect smokeFX = smokeFXGo.GetComponent<Effect>();
            smokeFX.FXInit();
        }
    }
    public void RecycleFX(GameObject fireFX)
    {
        FireFXPool.ReturnPool(fireFX);
    }
}
