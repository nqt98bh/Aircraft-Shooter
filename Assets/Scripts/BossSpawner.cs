using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static BossSpawner Instance;
    public GameObject bossPrefab;
    private void Awake()
    {
            Instance = this;
    }
 
    public void SpawnBoss()
    {
        Vector3 spawnPos = new Vector3 (0,2.3f,0);
        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }
}
