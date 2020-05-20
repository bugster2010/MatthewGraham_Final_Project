using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool pause;
    private Vector2 ballMove;
    private float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause)
        {
            if (collision.gameObject.layer == 8)
            {
                if (!collision.gameObject.GetComponent<player1_controller>().hasBall)
                {
                    collision.gameObject.GetComponent<player1_controller>().hasBall = true;
                    Destroy(this.gameObject);
                }

            }
            else if (collision.gameObject.layer == 9)
            {
                if (!collision.gameObject.GetComponent<player2_controller>().hasBall)
                {
                    collision.gameObject.GetComponent<player2_controller>().hasBall = true;
                    Destroy(this.gameObject);
                }

            }
        }
    }
    public void Pause()
    {
        if (!pause)
        {    
            pause = true;
            ballMove = rb.velocity;
            angularVelocity = rb.angularVelocity;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        else
        {
            pause = false;
            rb.velocity = ballMove;

        }
    }


}
