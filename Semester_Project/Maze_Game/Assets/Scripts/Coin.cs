using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;

    public void Collect()
    {
        FindObjectOfType<GameManager>().CoinCollected(this);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            Collect();
        }
    }
}
