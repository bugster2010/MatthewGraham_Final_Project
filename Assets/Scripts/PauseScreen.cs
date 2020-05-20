using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    public void Pause()
    {
        if (!pause)
        {
            GetComponent<Text>().text = "PAUSED";
            pause = true;
        }
        else
        {
            GetComponent<Text>().text = "";
            pause = false;
        }
    }

    public void GameWin(string player)
    {
        GetComponent<Text>().text = player + " wins!!!";
    }
}
