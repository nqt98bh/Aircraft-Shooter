using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFX : MonoBehaviour
{

    public void FireFXInit(Vector3 direction)
    {
        gameObject.SetActive(true);
    }
    public void FireFXRecycle()
    {
        gameObject.SetActive(false);
    }
}
