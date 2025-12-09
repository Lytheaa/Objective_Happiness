using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Inst;

    [SerializeField] private float TimeMultiplier = 1;

    public float GlobalTime { get; private set; } = 0;
    //public float GlobalTime { get; private set; } = 0;
    public float CurrentTime { get; private set; } = 0;
    public int[] TimeInHours { get; private set; } = new int[3];

    private float _eventCooldown = 2;
    private float _lastEventTime = 0;
    private float _lastSpawnTime = 0;

    public UnityEvent OnStartGame = new UnityEvent();

    public UnityEvent OnWorkTime = new UnityEvent();
    public UnityEvent OnSleepTime = new UnityEvent();
    public UnityEvent OnDayEnds = new UnityEvent();
    public UnityEvent OnSpawnTime = new UnityEvent();

    [SerializeField] private int[] workTime = new int[3] { 9, 0, 0 };
    [SerializeField] private int[] sleepTime = new int[3] {20, 0, 0 };
    [SerializeField] private int[] spawnTime = new int[3] {24*3 , 0, 0 }; // tous les 3 jours

    private void Awake()
    {
        if(Inst == null)
            Inst = this;
    }

    private void Start()
    {

        OnStartGame.Invoke();
        Debug.Log("Game Started, First Spawn initialized");
    }

    private void Update()
    {
        //print($"{CurrentTime} seconds ||| {TimeInHours[0]}h {TimeInHours[1]}min {TimeInHours[2]}sec ||| hoursToSec {HoursToSec(TimeInHours)}");

        //print($"{GlobalTime} seconds total, {CurrentTime} seconds today");

        CurrentTime += Time.deltaTime * TimeMultiplier;
        GlobalTime = Time.time * TimeMultiplier;

        SecToHours();
        if (CurrentTime >= HoursToSec(new int[] { 24, 0, 0 }))
        {
            CurrentTime = 0;
            OnDayEnds?.Invoke();
        }

        if (CurrentTime >= HoursToSec(workTime) && CurrentTime < HoursToSec(workTime)+1 && GlobalTime >= _lastEventTime + _eventCooldown)
        {
            _lastEventTime = GlobalTime;
            OnWorkTime?.Invoke();
        }
        
        if (CurrentTime >= HoursToSec(sleepTime) && CurrentTime < HoursToSec(sleepTime)+1 && GlobalTime >= _lastEventTime + _eventCooldown)
        {
            _lastEventTime = GlobalTime;
            OnSleepTime?.Invoke();
        }

        if (GlobalTime >= _lastSpawnTime + HoursToSec(spawnTime))
        {
            _lastSpawnTime = GlobalTime;
            OnSpawnTime?.Invoke();
        }
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
