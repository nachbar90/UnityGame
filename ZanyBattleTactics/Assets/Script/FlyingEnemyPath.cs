using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] float speed = 4f;
    int i = 0;

    void Start()
    {
        transform.position =  points[i].transform.position;
    }

    void Update()
    {
        if (i < points.Count)
        {
            var target = points[i].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);

            if (transform.position == target)
            {
                i++;
            }
                
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
