using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public bool isFinalLevel;
    public GameObject canvas;
    public GameObject win;
    public GameObject lose;
    bool winner;
    float time = 0;
    bool endScreen;
    void Start()
    {
        Time.timeScale = 1;
        winner = false;
        endScreen = false;
        canvas.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }
    void Update()
    {  
        if (endScreen)
        {
            time += 0.016f;
            if (time > 3.0f)
            {
                if (isFinalLevel && winner)
                {
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    SceneManager.LoadScene("Level" + level);
                }
            }
        }
    }
     public void EndScreen(bool youWin)
    {
        Time.timeScale = 0;
        winner = youWin;
        time = 0;
        endScreen = true;
        canvas.SetActive(true);
        if (winner)
        {
            win.SetActive(true);
            lose.SetActive(false);
            level++;
        }
        else
        {
            win.SetActive(false);
            lose.SetActive(true);
        }
    }
}