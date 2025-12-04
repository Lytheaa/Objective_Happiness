using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Inst;

    [SerializeField] private float TimeMultiplier = 1;

    public float CurrentTime { get; private set; } = 0;
    public int[] TimeInHours { get; private set; } = new int[3];
    
    private void Awake()
    {
        if(Inst == null)
            Inst = this;
    }

    private void Update()
    {
        //print($"{CurrentTime} seconds ||| {TimeInHours[0]}h {TimeInHours[1]}min {TimeInHours[2]}sec ||| hoursToSec {HoursToSec(TimeInHours)}");
        CurrentTime += Time.deltaTime * TimeMultiplier;
        SecToHours();
        
    }

    private void SecToHours()
    {
        TimeInHours[0] = (int) (CurrentTime / 3600);
        TimeInHours[1] = (int) (CurrentTime % 3600) / 60;
        TimeInHours[2] = (int) (CurrentTime % 3600) % 60;
    }

    public float HoursToSec(int[] time)
    {
        return time[0]*3600 + time[1]*60 + time[2];
    }
}
