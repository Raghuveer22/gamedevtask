using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    
    public static bool isGameEnded;
    public static bool isGameCompleted=false;
  
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public static int coins;
    public static Vector2 lastCheckPoint= new Vector2(-8,2);

    Animator animator;
     void Awake()
    {
       
        Time.timeScale = 1;

        isGameEnded = false;
        if(!isGameCompleted)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPoint;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-8,2);

        }
       

    }
     void Start()
    {
        coins = CheckPoint.scoreAtCheckPoint;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameEnded)
        {
            gameOverScreen.SetActive(true);
      
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void Pause ()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    public void NextLevel(int index)
    {
        
        SceneManager.LoadScene(index);
    }
}
