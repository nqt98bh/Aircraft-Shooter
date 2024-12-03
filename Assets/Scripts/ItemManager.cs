using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemManager : MonoBehaviour
{
    public  void Init()
    {
        gameObject.SetActive(true);
    }

    public void Recycle()
    {
        gameObject.SetActive(false);
    }

}
