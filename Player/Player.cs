using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    //for movement
    [Header("Movement")]
    [SerializeField]
    float MoveXPerSecond = 3;
    float moveXPerFrame;
    [Header("Collison")]
    //for collisoion
    [SerializeField]
    LayerMask obstaclesLayer;
    [SerializeField]
    Transform ColliderCheckBottom;
    [SerializeField]
    Transform ColliderCheckTop;
    [SerializeField]
    Transform ColliderCheckFront;
    const float ObstaclesCheckRadius = 0.2f;
    bool isCollided=false;
    [Header("Jump")]
    //for jumping;
    Rigidbody2D rb;
    [SerializeField]
    float jumpPower=10;
    //for animator
    [Header("Animator")]
    Animator animator;
    bool gameOverSoundPlayed = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        #region ColliderFields
        Collider2D[] colliderFront = Physics2D.OverlapCircleAll(ColliderCheckFront.position, ObstaclesCheckRadius, obstaclesLayer);
        Collider2D[] colliderBottom = Physics2D.OverlapCircleAll(ColliderCheckBottom.position, ObstaclesCheckRadius, obstaclesLayer);
        Collider2D[] colliderTop = Physics2D.OverlapCircleAll(ColliderCheckTop.position, ObstaclesCheckRadius, obstaclesLayer);
        //for collision check
        #endregion
        if(colliderFront.Length>0||colliderBottom.Length>0||colliderTop.Length>0)
        {
            isCollided = true;
          
            if (!PlayerManager.isGameEnded && HealthManager.health == 1)
            {
                PlayerManager.isGameEnded = true;
                gameObject.SetActive(false);

                GameOverSoundPlay();
                isCollided = false;
                HealthManager.health += 3;
              gameObject.transform.position = new Vector2(-8, 2);
            }
            else
            {
                HealthManager.health--;
                AudioManager.instance.Play("Ouch");
                gameObject.transform.position = PlayerManager.lastCheckPoint;
                isCollided = false;
                rb.velocity = Vector3.zero;

            }
        }
         Movement();
         Animation();
    }

    private void Animation()
    {
        if (!isCollided)
        {
            animator.SetFloat("yVelocity", Mathf.Abs(rb.velocity.y));

        }
    }
    private void Movement()
    {
        Vector3 position = transform.position;
        moveXPerFrame = MoveXPerSecond * Time.deltaTime;
        if (!isCollided)
        {
            position.x += moveXPerFrame;
        }
        if (Input.GetButton("Jump"))
        {
            if (!isCollided)
            {
                rb.AddForce(new Vector2(0f, jumpPower));
            }
        }
        transform.position = position;

    }
    
    private void GameOverSoundPlay()
    {
        if (!gameOverSoundPlayed)
        {
            gameOverSoundPlayed = true;
            AudioManager.instance.Play("Game Over");
        }

    }
}
