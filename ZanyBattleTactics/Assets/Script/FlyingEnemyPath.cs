using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    private EnemyConfiguration _enemyConfiguration;
    public EnemyConfiguration EnemyConfiguration { get { return _enemyConfiguration; } set { _enemyConfiguration = value;  } }
    int i = 0;

    void Start()
    {
        points = _enemyConfiguration.Points();
        transform.position =  points[i].transform.position;
    }

    void Update()
    {
        if (i < points.Count)
        {
            var target = points[i].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * _enemyConfiguration.EnemySpeed);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
