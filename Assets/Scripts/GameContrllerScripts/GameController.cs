using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject titleScreen, optionsScreen, pauseScreen;

    public AudioMixer mixer;

    bool isPaused = false;
    float timeScale;

    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoadGameScene(string scene)
    {
        titleScreen.SetActive(false);
        SceneManager.LoadScene(scene);
    }

    public void OnLoadMenuScene(string scene)
    {
        titleScreen.SetActive(true);
        SceneManager.LoadScene(scene);
    }

    public void OnTitleScreen()
    {
        titleScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void OnOptionsScreen()
    {
        titleScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void OnPauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = timeScale;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            timeScale = Time.timeScale;
            Time.timeScale = 0;
        }
    }

    public void OnPause()
    {
        OnPauseScreen();
    }
}
