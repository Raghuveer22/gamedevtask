using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpScript : MonoBehaviour
{
   public GameObject LevelCompeletedScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.isGameCompleted = true;
            LevelCompeletedScreen.SetActive(true);
            AudioManager.instance.Play("Level Complete");
            Time.timeScale = 0;
            CheckPoint.scoreAtCheckPoint = PlayerManager.coins;
        }
    }
}
