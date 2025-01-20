using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectSpawner : MonoBehaviour
{
    public static FireEffectSpawner Instance;
    public PoolManager FireFXPool;
    private float timer =0;
    [SerializeField] float recycleTime = 0.05f;
    public Transform playerTransform;
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
    public void FireFXSpawner()
    {
        FireFXSpawn();
        timer += Time.deltaTime;
        if (timer >= recycleTime)
        {
            RecycleFireFX(gameObject);
            timer = 0;
        }

    }
    public void FireFXSpawn()
    {

        Vector3 spawnPosition = playerTransform.transform.position + new Vector3(0, 1, 10);
        GameObject fireFXGo = FireFXPool.GetObject(spawnPosition, Quaternion.identity);
        fireFXGo.transform.position = spawnPosition;
        Effect fireFX = fireFXGo.GetComponent<Effect>();
        fireFX.FXInit();

    }
    public void RecycleFireFX(GameObject fireFX)
    {
        FireFXPool.ReturnPool(fireFX);
    }
}
