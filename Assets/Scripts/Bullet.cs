using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;  
    private Vector3 direction;
    Action RecycleAction;
    //public FireEffectSpawner fireEffectSpawner;
    void Update()
    {
      

        if (gameObject.activeInHierarchy)
        {
            transform.Translate(direction * GameController.Instance.BulletSpawner.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConstant.ENEMY_TAG) || other.CompareTag(GameConstant.METEOR_TAG) ||
            other.CompareTag(GameConstant.ROOF_TAG) || other.CompareTag(GameConstant.ENEMY_BULLET_TAG)||other.CompareTag(GameConstant.BOSS_TAG))
        {
            RecycleAction?.Invoke();
        }
    }

    //public void BulletFireAudio()
    //{
    //    AudioSource bulletAudio = gameObject.GetComponent<AudioSource>();
    //    bulletAudio.Play();
    //}

  

    public void Fire(Vector3 direction)
    {
        this.direction = direction;
        gameObject.SetActive(true);
     
    }
    public void Init(Action _recycleAction)
    {
        RecycleAction = _recycleAction;
        //BulletFireAudio();
        
      
    }
 

}
