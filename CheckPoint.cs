using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{


    
    Animator animator;
    static public int scoreAtCheckPoint;
    void Awake()
    {
        animator = GetComponent<Animator>(); 
        if(PlayerManager.isGameCompleted==true)
        {
            gameObject.tag = "Unsaved";
        }

    }
     void Start()
    {
      
        if(gameObject.tag=="Saved")
        {
            animator.SetFloat("Saved", 1);
        }
        else
        {
            animator.SetFloat("Saved", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.tag = "Saved";
            PlayerManager.lastCheckPoint = transform.position;
            scoreAtCheckPoint = PlayerManager.coins;
            AudioManager.instance.Play("Check Point");
        }
    }
    void Update()
    {
        if (gameObject.tag == "Saved")
        {
            animator.SetFloat("Saved", 1);
        }
    }

}
