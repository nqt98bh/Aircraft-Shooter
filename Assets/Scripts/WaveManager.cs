using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public EnemySpawner enemySpawner;
    public Transform[] pathSet1;
    public Transform[] pathSet2;
    public Transform[] pathSet3;

    private void Awake()
    {
        instance = this;

    }

    public Transform[] GetRandomPath()
    {
        int randomPathIndex = Random.Range(0, 3);
        Transform[] path = randomPathIndex switch
        {
            0 => pathSet1,
            1 => pathSet2,
            2 => pathSet3,
            _ => pathSet1, // Default to pathSet1 if anything goes wrong
        };
        return path;
    }


}
