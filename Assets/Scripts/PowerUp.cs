using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ItemManager
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConstant.GROUND_TAG)  || other.CompareTag(GameConstant.PLAYER_TAG))
        {
          Recycle();
        }
    }
}
