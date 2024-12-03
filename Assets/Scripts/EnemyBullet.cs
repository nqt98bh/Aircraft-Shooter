using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int speed = 10;

    Action RecycleAction;
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player")|| other.CompareTag("Ground") || other.CompareTag("Bullet" ))
        {
            RecycleAction?.Invoke();
        }

    }

    public void Fire(Vector3 direction)
    {
        //this.direction = direction;
        gameObject.SetActive(true);
 
    }



    public void Init(Action _recycleAction)
    {
        RecycleAction = _recycleAction;
    }

}
