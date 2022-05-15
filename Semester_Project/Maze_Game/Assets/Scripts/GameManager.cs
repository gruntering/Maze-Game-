using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Beast[] beasts;

    public Hero hero;
    public Transform coins;
    public Text scoreText;
    public Text livesText;
    public Text timeText;
    public static int totalScore;
    public static float totalTime;
    [SerializeField] float startTime;

    private float currentTime;

    private bool timeStarted = false;

    
    


    public int score { get;private set; }
    

    public int lives { get; private set; }

    public bool areAllCoinsSelected = false;



    private void Start()
    {
        NewGame();
        currentTime = startTime;



    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(2);
        NewRound();
        timeStarted = true;
      


    }

    private void Update()
    {
        if (timeStarted)
        {
            currentTime += Time.deltaTime;
        }
        else if (this.lives == 0 && Input.anyKeyDown)
        {
            timeStarted = false;
            totalTime = currentTime;
            currentTime = 0;
            Debug.Log("You Have lost");
            NewGame();
            
        }
     
        scoreText.text = score.ToString() + " coins";
        livesText.text = lives.ToString() + "x Lives";
        timeText.text = currentTime.ToString("f1") + "s";
        totalScore = score;
        totalTime = currentTime;
        

        

    

       
    }

    private void NewRound()
    {

        foreach (Transform coin in this.coins)
        {
            coin.gameObject.SetActive(true);
        }
        
        ResetState();

    }

    private void ResetState()
    {
        for (int i = 0; i < this.beasts.Length; i++)
        {
           this.beasts[i].ResetState();

        }
        this.hero.ResetState();
    }

    private void GameOver()
    {
        for (int i = 0; i < this.beasts.Length; i++)
        {
            this.beasts[i].gameObject.SetActive(false);

        }
        this.hero.gameObject.SetActive(false);
      
        SceneManager.LoadScene(3);
        


    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void HeroDied()
    {
        this.hero.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 2.0f);
        }
        else
        {
            GameOver();
        }
    }

    public void CoinCollected(Coin coin)
    {
        coin.gameObject.SetActive(false);
        SetScore(this.score + coin.points);
        if (!HasCollectedAllCoins())
        {
            //this.hero.gameObject.SetActive(false);
            //Invoke(nameof(NewRound), 3.0f);
            areAllCoinsSelected = true;
        }
        
    }

    

    public bool HasCollectedAllCoins()
    {
        foreach (Transform coin in this.coins)
        {
            if (coin.gameObject.activeSelf)
            {
                
                return true;
            }
            
            
        }
        return false;

    }



}