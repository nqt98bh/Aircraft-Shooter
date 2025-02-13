using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    [SerializeField] private int enemyHP = 3;
    private Transform[] path;
    public Animator animator;
    private void Start()
    {
         animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(GameConstant.BULLET_TAG))
        {
            enemyHP -= 1;

            IsHitted();
            if(enemyHP <= 0)
            {
                SoundFX.Instance.PlaySoundFX(SoundType.Explosion);
                SmokeSpawner.Instance.SmokeFXSpawn(gameObject.transform);
                ScoreManager.Instance.AddScore(100);
                EnemyRecycle();
            }
        }
    }
    public void IsHitted()
    {

        animator.SetTrigger("IsHitted");
    }
    
    public void EnemyInit(Vector3 direction)
    {
        gameObject.SetActive(true);
    }
    public void EnemyRecycle()
    {
        gameObject.SetActive(false);
        enemyHP = 3;
    }


}
