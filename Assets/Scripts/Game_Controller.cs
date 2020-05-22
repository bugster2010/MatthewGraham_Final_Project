using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public bool pause;
    public player1_controller p1;
    public player2_controller p2;
    private GameObject[] balls;
    private BallController ballType;
    public PauseScreen pScr;
    private int ballLeft;
    private int ballRight;
    private bool hasWon;

    public AudioClip gameSong;
    public AudioClip winEffect;

    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(gameSong, Vector3.zero);
        pause = false;
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {

            PauseGame();
            CheckWin();
    }

    void CheckWin()
    {
        ballLeft = 0;
        ballRight = 0;
        balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in balls)
        {
            ballType = ball.GetComponent<BallController>();
            if (ballType.transform.position.x < -0.5)
            {
                ballLeft += 1;
            }else if(ballType.transform.position.x> 0.5)
            {
                ballRight += 1;
            }

        }

        if (p1.hasBall)
        {
            ballLeft += 1;
        }
        if (p2.hasBall)
        {
            ballRight += 1;
        }
        if (ballRight == 0 && ballLeft == 12)
        {
            pScr.GameWin("Right Player");
            AudioSource.PlayClipAtPoint(winEffect, Vector3.zero);
            Thread.Sleep(5000);
            hasWon = true;
            SceneManager.LoadScene("MainMenu");
        }
        if (ballLeft == 0 && ballRight == 12)
        {
            pScr.GameWin("Left Player");
            AudioSource.PlayClipAtPoint(winEffect, Vector3.zero);
            Thread.Sleep(5000);
            SceneManager.LoadScene("MainMenu");
        }
    }
    void PauseGame()
    {
        if(Input.GetAxisRaw("PauseButton") >.99f)
        {
            if(pause == true)
            {
                pause = false;
                balls = GameObject.FindGameObjectsWithTag("Ball");
                foreach(GameObject ball in balls)
                {
                    ballType = ball.GetComponent<BallController>();
                    ballType.Pause();
                }
                p1.Pause();
                p2.Pause();
                pScr.Pause();
            }
            else
            {
                pause = true;
                p1.Pause();
                p2.Pause();
                pScr.Pause();
                balls = GameObject.FindGameObjectsWithTag("Ball");
                foreach (GameObject ball in balls)
                {
                    ballType = ball.GetComponent<BallController>();
                    ballType.Pause();
                }

            }
            Thread.Sleep(500);
        }
    }
}
