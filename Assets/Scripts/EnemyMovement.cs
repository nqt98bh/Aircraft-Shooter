using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform pointA, pointB, pointC, pointD;
    [SerializeField] float speed = 0.5f;
    
    public void SetPath(Transform[] path)
    {
        Vector3[] paths = new Vector3[path.Length];
       for (int i = 0;i < path.Length;i++)
        {
            paths[i] = path[i].position;
        }
     
        transform.DOPath(paths, speed, PathType.CatmullRom).OnUpdate(() => { transform.position = new Vector3 (transform.position.x, transform.position.y, 0); }).
            SetEase(Ease.Linear).SetLoops(-1);
    }


    Vector3 CalculateBezierPoint (float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0; // (1-t)^3 * p0
        p += 3 * uu * t * p1; // 3(1-t)^2 * t * p1
        p += 3 * u * tt * p2; // 3(1-t) * t^2 * p2
        p += ttt * p3; // t^3 * p3
        p.z = 0;
        return p;

    }


}
