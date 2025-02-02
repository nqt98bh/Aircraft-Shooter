using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackGroundController : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float backGroundHeight = 10f;
    [SerializeField] List<GameObject> backGroundObjects = new List<GameObject>();

    private Vector3 startPosition;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        startPosition = transform.position;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        foreach (GameObject go in backGroundObjects)
        {

            if(go.transform.position.y <= -backGroundHeight)
            {
                float heightestY = GetHeightestPosition();
                go.transform.position = new Vector3(go.transform.position.x, heightestY + backGroundHeight , go.transform.position.z);
            }
            go.transform.Translate(Vector3.down * scrollSpeed *Time.deltaTime);
        }

       
    }
    float GetHeightestPosition()
    {
        float hightest = 0;
        foreach (var backGroundObject in backGroundObjects)
        {
            if(backGroundObject.transform.position.y > hightest)
            {
                hightest = backGroundObject.transform.position.y;
            }
        }
        return hightest;
    }
    
}
