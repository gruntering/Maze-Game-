using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text finalScore;
    public Text finalTime;

    private void Update()
    {
        finalScore.text = "Coins Collected "+ GameManager.totalScore.ToString();
        finalTime.text = "Time Spent " + GameManager.totalTime.ToString("f1") + "s";


    }
}