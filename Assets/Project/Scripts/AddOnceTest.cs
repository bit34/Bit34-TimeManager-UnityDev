﻿using UnityEngine;


public class AddOnceTest : TestBase
{
    //  CONSTANTS
    private const string START_LABEL = "Start : Calls on next frame";
    private const string STOP_LABEL  = "Cancel";
    private const string START_INFO  = "Started > Frame : {0}";
    private const string UPDATE_INFO = "Updated > Frame : {0}";
    private const string STOP_INFO   = "Stopped > Frame : {0}";

    //  METHODS
    private void Awake()
    {
        InitializeTest(StartTestCallback, START_LABEL,
                       StopTestCallback,  STOP_LABEL,
                       LockTestCallback);
    }

    private void StartTestCallback()
    {
        Debug.Log(string.Format(START_INFO, Time.frameCount));

        Manager.Scheduler.AddTick(this, Settings.TimeType, UpdateCallback, 1);
    }

    private void StopTestCallback()
    {
        Debug.Log(string.Format(STOP_INFO, Time.frameCount));

        Manager.Scheduler.Remove(this, UpdateCallback);

        CancelTest();
    }

    private void LockTestCallback(bool state){}

    private void UpdateCallback(float timeStep)
    {
        Debug.Log(string.Format(UPDATE_INFO, Time.frameCount));

        CancelTest();
    }

}
