using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 4;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    //the script is taken from a youtube video of gdtitans
    void Update()
    {
        foreach(Image image in hearts)
        {
            image.sprite = EmptyHeart;
        }
       
            for (int i = 0; i < health; i++)
            {
                hearts[i].sprite = fullHeart;
            }
        
    }
}
