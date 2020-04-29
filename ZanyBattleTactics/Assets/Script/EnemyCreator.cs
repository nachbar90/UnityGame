using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    [SerializeField] List<EnemyConfiguration> enemyConfigurations;
    int index = 0;
    void Start()
    {
        StartCoroutine(InvokeFlyingAndWalkingEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InvokeFlyingAndWalkingEnemies()
    {
        for (int i = index; i < enemyConfigurations.Count; i++)
        {
            var currentConfig = enemyConfigurations[i];
            yield return StartCoroutine(InvokeEnemy(currentConfig));
        }

    }

    private IEnumerator InvokeEnemy(EnemyConfiguration enemyConfiguration)
    {
        var enemy = Instantiate(enemyConfiguration.Enemy, enemyConfiguration.Points()[0].transform.position, Quaternion.identity);
        enemy.GetComponent<FlyingEnemyPath>().EnemyConfiguration = enemyConfiguration;
       // Debug.LogError("name " +enemyConfiguration.Enemy.name);
        yield return new WaitForSeconds(enemyConfiguration.TimeBreakBeetwenEnemies);
    }
}
