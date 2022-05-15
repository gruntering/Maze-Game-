using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D other)
    {

       bool stateNew = GameObject.Find("GameManager").GetComponent<GameManager>().areAllCoinsSelected;


                if (other.CompareTag("Player") && stateNew == true)
                {
                SceneManager.LoadScene(2);
                   
                 }
            

        }
}

