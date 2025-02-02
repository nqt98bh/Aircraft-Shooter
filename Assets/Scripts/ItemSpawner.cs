using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemType
{
    FireSpeed,
    HealthUp,
    PowerUp,
    Shield,
}

[System.Serializable]
public class ItemProperties
{
    public ItemType itemType;
    public PoolManager itemPool;
    public float SpawnInterval;
}


public class ItemSpawner : MonoBehaviour
{
    
    public List<ItemProperties> itemProperties;
    private Dictionary<ItemType, float> timers = new Dictionary<ItemType, float>();
    //private Dictionary<ItemType, ItemEffect> itemEffects = new Dictionary<ItemType, ItemEffect>();

    private void Start()
    {
        foreach (var item in itemProperties)
        {
            if (timers.ContainsKey(item.itemType))
            {
                timers[item.itemType] = 0f;
            }
            else
            {
                timers.Add(item.itemType, item.SpawnInterval);
                timers[item.itemType] = 0f;
            }
        }
    }

    private void Update()
    {
        foreach (var item in itemProperties)
        {
            timers[item.itemType] += Time.deltaTime;
            if (timers[item.itemType] > item.SpawnInterval)
            {
                SpawnItem(item);
                timers[item.itemType] = 0f;
            }
        }
    }

    private void SpawnItem(ItemProperties item )
    { 
     
        float randomX = Random.Range(-9f, 9f);
        Vector3 spawnPosition = new Vector3(randomX, 4.8f, 10);
        GameObject itemGo = item.itemPool.GetObject(spawnPosition, Quaternion.identity);
        itemGo.transform.position = spawnPosition;
        ItemManager itemEffect = itemGo.GetComponent<ItemManager>();
        itemEffect.Init();
    }

    void RecycleItem(GameObject item)
    {
        ItemManager itemEffect = item.GetComponent<ItemManager>();
        itemEffect.Recycle();
    }
}
