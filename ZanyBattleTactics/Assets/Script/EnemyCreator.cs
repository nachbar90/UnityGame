using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    [SerializeField] List<EnemyConfiguration> enemyConfigurations;
    [SerializeField] int numberOfLoops = 3;
    int index = 0;

    IEnumerator Start()
    {
        int i = 0;
        while (i < numberOfLoops)
        {
            yield return StartCoroutine(InvokeFlyingAndWalkingEnemies());
            i++;
        }
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
        enemy.GetComponent<Enemy>().EnemyConfiguration = enemyConfiguration;
       // Debug.LogError("name " +enemyConfiguration.Enemy.name);
        yield return new WaitForSeconds(enemyConfiguration.TimeBreakBeetwenEnemies);
    }
}
