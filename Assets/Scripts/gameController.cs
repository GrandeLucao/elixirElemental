using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    public float TimeLeft;
    public bool TimerOn=false;
    public Slider timeSlider;

    public GameObject pauseScreen, pauseButton, gameOverObj;
    
    void Awake()
    {
        instance=this;
    }

    void Start()
    {
        timeSlider.maxValue=TimeLeft;
        timeSlider.value=TimeLeft;

    }



    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft>0)
            {
                TimeLeft-=Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else{
                TimeLeft=0;
                TimerOn=false;
                GameOver();
            }
        }
        
    }

    void updateTimer(float currentTime)
    {
        currentTime+=1;
        float minutes=Mathf.FloorToInt(currentTime/60);
        float seconds=Mathf.FloorToInt(currentTime%60);
        timeSlider.value=TimeLeft;

    }

    public void GamePause()
    {
        TimerOn=false;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void GameUnpause()
    {
        TimerOn=true;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().Stop("BGM");        
        gameOverObj.SetActive(true);
    }
    
    public void MenuGo()
    {
            SceneManager.LoadScene(1);    
    }

    public void Restart()
    {
            int lvl=SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(lvl);        
    }

}
