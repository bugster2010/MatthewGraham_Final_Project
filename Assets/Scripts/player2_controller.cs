﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_controller : MonoBehaviour
{
    public float speed;
    public bool hasBall;
    private bool pause;
    private int playerNum;
    public Rigidbody2D rb;
    public GameObject ball;

    void Start()
    {
        playerNum = 2;
        hasBall = false;
        pause = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause == false)
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
            float xL = Input.GetAxisRaw("LeftJoyHorizontal2");
            float yL = Input.GetAxisRaw("LeftJoyVertical2");

            float xR = Input.GetAxisRaw("RightJoyHorizontal2");
            float yR = Input.GetAxisRaw("RightJoyVertical2");
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
        if (Input.GetAxis("RBButton2")==1 && hasBall)
        {
            GameObject.Instantiate(ball, transform);
        }
    }

    public void Pause()
    {
        pause = true;
    }

    public void Unpause()
    {

    }


}