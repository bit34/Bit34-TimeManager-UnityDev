﻿using System;
using UnityEngine;
using Com.Bit34Games.Unity.Update;


public class AddOnceDelayedTest : TestBase
{
    //  CONSTANTS
    private const int DELAY_SECONDS = 3;
    private const string START_LABEL = "Start : Calls once with {0} seconds delay";
    private const string STOP_LABEL  = "Cancel : Before call time";
    private const string START_INFO  = "Started > will call with {0} seconds delay) > Time : {1}" ;
    private const string UPDATE_INFO = "Updated >  Time : {1}" ;


    //  MEMBERS
    private TimeSpan _delay;


    //  METHODS
    private void Awake()
    {
        InitializeTest(StartTestCallback, string.Format(START_LABEL, DELAY_SECONDS),
                       StopTestCallback,  STOP_LABEL,
                       LockTestCallback);

        _delay = TimeSpan.FromSeconds(DELAY_SECONDS);
    }

    private void StartTestCallback()
    {
        Debug.Log(string.Format(START_INFO, DELAY_SECONDS, GetTimeString()));

        UpdateManager.AddOnce(UpdateCallback, this, _delay, Settings.TimeType);
    }

    private void StopTestCallback()
    {
        Debug.Log("Update once are cancelled(with 3 seconds delay)");

        UpdateManager.RemoveAllFrom(this);

        CancelTest();
    }

    private void LockTestCallback(bool state){}
    
    private void UpdateCallback()
    {
        Debug.Log("Update once called(with 3 seconds delay) > Time > " + GetTimeString());

        CancelTest();
    }

}
