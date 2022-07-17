using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{

   
     void Start()
    {
        if(PlayerManager.isGameCompleted)
        {
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            PlayerManager.coins++;
            MenuEvents.totalcoinsIncrement++;
            PlayerPrefs.SetInt("TotalCoins", MenuEvents.totalcoinsIncrement);

            AudioManager.instance.Play("Coins");
            gameObject.SetActive(false);
        }
    }
}
