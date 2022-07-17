using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TotalScoreText;
    
    void Update()
    {

        scoreText.text = "SCORE:" + PlayerManager.coins;
        TotalScoreText.text = "totalcoins:" + MenuEvents.totalcoinsIncrement;
    }
}
