using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectSpawner : MonoBehaviour
{
    public static FireEffectSpawner Instance;
    public PoolManager FireFXPool;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void FireFXSpawn()
    {
      
        Vector3 spawnPosition = transform.position;
        GameObject fireFXGo = FireFXPool.GetObject(spawnPosition, Quaternion.identity);
        fireFXGo.transform.position = spawnPosition;
        FireFX fireFX = fireFXGo.GetComponent<FireFX>();
        fireFX.FireFXInit(spawnPosition);

    }
    public void RecycleFireFX(GameObject fireFX)
    {
        FireFXPool.ReturnPool(fireFX);
    }
}
