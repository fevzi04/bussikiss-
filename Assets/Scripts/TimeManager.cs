using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public int tempMinute;
    public static int Minute{get; set;}
    public static int Hour{get; set;}

    [SerializeField] private float minuteToRealTime = 0.5f;
    private float timer;

    public bool timePaused = false; 

    void Start()
    {
        Minute = 0;
        Hour = 8;
        timer = minuteToRealTime;
    }

    void Update()
    {
        if(!timePaused){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Minute++;
                OnMinuteChanged?.Invoke();
                if(Minute >= 60){
                    Hour++;
                    tempMinute = Minute - 60;
                    Minute = tempMinute;
                    OnHourChanged?.Invoke();
                }

                timer = minuteToRealTime;
            }
        }
    }

    public void addMinute(int n){
        Minute += n;
    }

    void pauseTime(){
        timePaused = true;
    }

    void unPauseTime(){
        timePaused = false;
    }
}
