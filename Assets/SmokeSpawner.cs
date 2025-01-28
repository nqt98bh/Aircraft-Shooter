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
            Instance = this;
    }
    //public void SmokeFXSpawner()
    //{
    //    SmokeFXSpawn();
    //    timer += Time.deltaTime;
    //    if (timer >= recycleTime)
    //    {
    //        RecycleFX(gameObject);
    //        timer = 0;
    //    }

    //}
    public void SmokeFXSpawn(Transform position)
    {
    

            Vector3 spawnPosition = position.transform.position;
            GameObject smokeFXGo = FireFXPool.GetObject(spawnPosition, Quaternion.identity);
            smokeFXGo.transform.position = spawnPosition;
            Effect smokeFX = smokeFXGo.GetComponent<Effect>();
            smokeFX.FXInit();
         timer += Time.deltaTime;
        if (timer >= recycleTime)
        {
            RecycleFX(gameObject);
            timer = 0;
        }

    }
    public void RecycleFX(GameObject fireFX)
    {
        FireFXPool.ReturnPool(fireFX);
    }
}
