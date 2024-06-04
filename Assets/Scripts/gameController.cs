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

    //Timer, sceneManager
}
