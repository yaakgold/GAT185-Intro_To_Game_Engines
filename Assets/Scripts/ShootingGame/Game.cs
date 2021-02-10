using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public float Score { get; set; } = 0;
    public TextMeshProUGUI scoreUI, timerUI, highScoreUI;
    public GameObject startScreen, gameOverScreen;
    public AudioSource music;
    public bool useTimer = true;
    public float timeScoreMult;
    public Character playerObj;
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

    public void AddScore(float points)
    {
        Score += points;
        scoreUI.text = string.Format(Score.ToString());
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
                scoreUI.text = string.Format(Score.ToString());
                timer = 20;
                startScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                music.Play();
                highScoreUI.text = "High Score: " + UpdateHighScore(Score);
                State = eState.GAME;
                break;
            case eState.GAME:
                if(useTimer)
                {
                    timer -= Time.deltaTime;
                    timerUI.text = string.Format("Time: {0}s", Mathf.FloorToInt(timer));

                    if(timer <= 0)
                    {
                        music.Stop();
                        State = eState.GAME_OVER;
                    }
                }
                else
                {
                    AddScore(Time.deltaTime * timeScoreMult);
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

    public static float UpdateHighScore(float score)
    {
        float hs = PlayerPrefs.GetInt("HighScore");
        if(score > hs)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        return PlayerPrefs.GetFloat("HighScore");
    }

    public void StartGame()
    {
        if (playerObj != null)
        {
            playerObj.ResetGame();
        }
        State = eState.START_GAME;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
