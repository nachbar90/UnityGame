using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Configuration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] int enemies;
    [SerializeField] float creationTimeOfEnemy = 1f;
    [SerializeField] float randomness = 0.5f;
    [SerializeField] GameObject path;
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpeed = 3f;

    public GameObject Enemy { get { return enemy; } }
    public float CreationTimeOfEnemies { get { return creationTimeOfEnemy; } }
    public float Randomness { get { return randomness; } }
    public int Enemies { get { return enemies; } }

    public List<Transform> Points()
    {
        List<Transform> points = new List<Transform>();

        foreach (Transform point in path.transform)
        {
            Debug.Log("test");
            points.Add(point);
        }
        return points;
    }
}
