using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static BossScript instance;
    Animator animator;
    public int bossHP = 1000;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConstant.BULLET_TAG))
        {
            animator.SetTrigger("IsHitted");
            bossHP -= 20;
            if (bossHP <= 0)
            {
                GameController.Instance.onGameFinished?.Invoke(); //check if onGameFinished null
                SmokeSpawner.Instance.SmokeFXSpawn(gameObject.transform);
                Destroy(gameObject);
                
            }
        }
    }

}
