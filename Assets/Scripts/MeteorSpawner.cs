using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static MeteorSpawner instance;
    public PoolManager meteorPool;
    [SerializeField] private float timer;
    [SerializeField] private float spawnInterval = 1.0f;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            MeteorSpawn();
            timer = 0.0f;
        }
    }
    void MeteorSpawn()
    {
        float randomX = Random.Range(-9f, 9f);
        Vector3 spawnPosition = new Vector3(randomX, 4.8f, 10);
        GameObject meteorGo = meteorPool.GetObject(spawnPosition,Quaternion.identity);
        meteorGo.transform.position = spawnPosition;
        Meteor meteor = meteorGo.GetComponent<Meteor>();
        meteor.Init();
         
    }
    public void RecycleMeteor(GameObject meteor)
    {
        meteorPool.ReturnPool(meteor);
    }

}
