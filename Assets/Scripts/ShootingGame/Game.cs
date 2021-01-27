using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public TextMeshProUGUI scoreUI, timerUI, highScoreUI;
    public GameObject startScreen, gameOverScreen;
    public AudioSource music;
    public int HighScore { get; set; } = 0;

    float timer = 20.0f;

    #region Singleton
    static Game _instance = null;

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;

        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    #endregion

    public enum eState
    {
        TITLE,
        START_GAME,
        GAME,
        GAME_OVER
    }

    public eState State { get; set; } = eState.TITLE;

    public void AddScore(int points)
    {
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }

    private void Update()
    {
        switch (State)
        {
            case eState.TITLE:
                gameOverScreen.SetActive(false);
                startScreen.SetActive(true);
                break;
            case eState.START_GAME:
                Score = 0;
                scoreUI.text = string.Format("{0:D4}", Score);
                timer = 20;
                startScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                music.Play();
                highScoreUI.text = "High Score: " + UpdateHighScore(Score);
                State = eState.GAME;
                break;
            case eState.GAME:
                timer -= Time.deltaTime;
                timerUI.text = string.Format("Time: {0}s", Mathf.FloorToInt(timer));

                if(timer <= 0)
                {
                    music.Stop();
                    State = eState.GAME_OVER;
                }
                break;
            case eState.GAME_OVER:
                gameOverScreen.SetActive(true);
                highScoreUI.text = "High Score: " + UpdateHighScore(Score);
                break;
            default:
                break;
        }
    }

    public static int UpdateHighScore(int score)
    {
        int hs = PlayerPrefs.GetInt("HighScore");

        if(score > hs)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        return PlayerPrefs.GetInt("HighScore");
    }

    public void StartGame()
    {
        State = eState.START_GAME;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
