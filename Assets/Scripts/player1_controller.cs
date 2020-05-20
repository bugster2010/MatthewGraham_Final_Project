﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_controller : MonoBehaviour
{
    public float speed;
    public bool hasBall;
    private bool pause;
    private int playerNum;

    public Transform ballShot;
    public float ballShotSpeed = 50f;
    
    private Rigidbody2D rb;
    public GameObject ball;

    public Animator animator;
    
    void Start()
    {
        playerNum = 1;
        hasBall = false;
        pause = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("BallAnim", hasBall);
        if (!pause)
        {
            Move();
            Shoot();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
        }
    }
    void Move()
    {
        float xL = Input.GetAxisRaw("LeftJoyHorizontal1");
        float yL = Input.GetAxisRaw("LeftJoyVertical1");

        float xR = Input.GetAxisRaw("RightJoyHorizontal1");
        float yR = Input.GetAxisRaw("RightJoyVertical1");
        if (xR != 0 || yR != 0)
        {
            float angleA = Mathf.Atan2(xR, yR) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angleA);
        }
        float moveX = xL * speed;
        float moveY = yL * speed;
        rb.velocity = new Vector2(moveX, moveY);
    }
    void Shoot()
    {
        if (Input.GetAxis("RTButton1")>0.5 && hasBall)
        {
            GameObject spawnedBall = Instantiate(ball, ballShot.position, ballShot.rotation);
            Rigidbody2D rbB = spawnedBall.GetComponent<Rigidbody2D>();
            rbB.AddForce(ballShot.up * ballShotSpeed, ForceMode2D.Impulse);
            hasBall = false;

        }
    }

    public void Pause()
    {
        if (pause)
        {
            pause = false;
        }
        else
        {
            pause = true;
        }
    }

}

        

