using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuEvents : MonoBehaviour
{

    public static int totalcoins;
    public static int totalcoinsIncrement;
    public static bool isreseted=false;
    public Text totalcoinsText;
    
    void Start()
    {
        totalcoins= PlayerPrefs.GetInt("TotalCoins", 0);
        totalcoinsIncrement = totalcoins;
        Time.timeScale = 1;
        totalcoinsText.text = "coins:" +totalcoinsIncrement;
      
    }
    public void LoadLevel( int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Reset()
    {
        isreseted = true;
        totalcoins = 0;
        totalcoinsIncrement = 0;
        PlayerPrefs.SetInt("TotalCoins",totalcoins);
        totalcoinsText.text = "coins:" + totalcoinsIncrement;
    }

}
