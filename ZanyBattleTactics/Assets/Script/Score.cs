using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int pointsForBat;
    [SerializeField] int pointsForZombie;
    [SerializeField] Text scoreText;

    int totalScore = 0;

    public void AddPointsToTotalScore(GameObject gameObject)
    {
        if (gameObject.tag.Equals("Bat"))
        {
            totalScore += pointsForBat;
        } 
        else
        {
            totalScore += pointsForZombie;
        }

        scoreText.text = totalScore.ToString();
    }
}
