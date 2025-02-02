using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static int bossHP = 1000;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameConstant.BULLET_TAG))
        {
            bossHP -= 20;
            if (bossHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
