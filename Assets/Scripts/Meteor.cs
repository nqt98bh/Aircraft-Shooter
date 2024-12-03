using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("phat hien va cham");
        if (other.CompareTag("Ground") || other.CompareTag("Bullet") || other.CompareTag("Player"))
        {
            Recycle();
        }
    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void Recycle()
    {
        gameObject.SetActive(false);
        Debug.Log("Meteor recycled back to the pool.");
    }
}
