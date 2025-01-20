using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static BossSpawner Instance;
    public GameObject bossPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void SpawnBoss()
    {
        Vector3 spawnPos = transform.position;
        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }
}
