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
    public Text TimerTxt;
    
    void Awake()
    {
        instance=this;
    }

    void Start()
    {
              
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
        TimerTxt.text=string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    //Timer, sceneManager
}
