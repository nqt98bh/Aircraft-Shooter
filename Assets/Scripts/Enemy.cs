using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    private float fireInterval;
    public EnemyBulletSpawner enemyBulletSpawner; // Reference to the bullet spawner
    private float fireTimer = 0f;  // Timer for firing bullets
    private Vector3 spawnPosition; // Enemy spawn position
    [SerializeField] private int enemyHP = 5;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(GameConstant.BULLET_TAG))
        {
            enemyHP -= 1;
            if(enemyHP <= 0)
            {
                EnemyRecycle();
            }
        }
    }

    public void EnemyInit()
    {
        
        gameObject.SetActive(true);
    }
    public void EnemyRecycle()
    {
        gameObject.SetActive(false);
    }
}
