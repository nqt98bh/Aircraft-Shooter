using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    [SerializeField] private int enemyHP = 5;
    [SerializeField] private float moveSpeed = 2f;
    private Transform[] path;
    public Animator animator;
    float time = 0f;
    private void Start()
    {
         animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(GameConstant.BULLET_TAG))
        {
            IsHitted();
            enemyHP -= 1;
            if(enemyHP <= 0)
            {
                OnDead();
                ScoreManager.Instance.AddScore(100);


                EnemyRecycle();

            }


        }
       
    }
    public void IsHitted()
    {

        animator.SetTrigger("IsHitted");
    }

    public void OnDead()
    {
        SmokeSpawner.Instance.SmokeFXSpawner();
    }
  


    public void EnemyInit(Vector3 direction)
    {
        gameObject.SetActive(true);
    }
    public void EnemyRecycle()
    {
        gameObject.SetActive(false);
    }
}
