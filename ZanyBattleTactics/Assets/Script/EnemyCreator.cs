
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return StartCoroutine(WinGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InvokeFlyingAndWalkingEnemies()
    {
        for (int i = index; i < enemyConfigurations.Count; i++)
        {
            var randomIndex = Random.Range(0, 3);
            var currentConfig = enemyConfigurations[randomIndex];
            yield return StartCoroutine(InvokeEnemy(currentConfig));
        }

    }

    private IEnumerator InvokeEnemy(EnemyConfiguration enemyConfiguration)
    {
        var enemy = Instantiate(enemyConfiguration.Enemy, enemyConfiguration.Points()[0].transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().EnemyConfiguration = enemyConfiguration;
        yield return new WaitForSeconds(enemyConfiguration.TimeBreakBeetwenEnemies * Random.Range(0.5f, 1f));
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("WinScene");
    }
}
