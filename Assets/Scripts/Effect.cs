using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    public void FXInit()
    {
        gameObject.SetActive(true);
    }
    public void FXRecycle()
    {
        gameObject.SetActive(false);
    }
}
