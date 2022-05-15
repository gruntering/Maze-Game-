using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public Text winScore;
    public Text totalTime;

    private void Update()
    {
        winScore.text = "Coins Collected "+ GameManager.totalScore.ToString();
        totalTime.text = "Time Spent " + GameManager.totalTime.ToString("f1") +"s";

    }
}
