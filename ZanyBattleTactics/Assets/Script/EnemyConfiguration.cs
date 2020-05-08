using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Configuration")]
public class EnemyConfiguration : ScriptableObject
{

    [SerializeField] float timeBreakBeetwenEnemies;
    [SerializeField] GameObject path;
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpeed = 3f;

    public GameObject Enemy { get { return enemy; } }
    public float TimeBreakBeetwenEnemies { get { return timeBreakBeetwenEnemies; } }
    public float EnemySpeed { get { return enemySpeed; } }

    public List<Transform> Points()
    {
        List<Transform> points = new List<Transform>();

        foreach (Transform point in path.transform)
        {
            points.Add(point);
        }
        return points;
    }
}
