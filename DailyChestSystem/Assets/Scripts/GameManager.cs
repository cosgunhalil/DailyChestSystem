using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public DataManager _dataManager;
    public DailyReward _dailyReward;

	void Start () 
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _dataManager.Init();
        _dailyReward.Init(CalculateClosedAppSeconds(), _dataManager.GetAppData().DailyRewardData.SecondsToUnlock);
	}

    private int CalculateClosedAppSeconds()
    {
        var lastActiveTime = _dataManager.GetLastActiveTimeData();
        var currentTime = NtpServerConnectionManager.Instance.GetTime();
        var differance = currentTime - lastActiveTime;

        Debug.Log("Last closed time = " + lastActiveTime);
        Debug.Log("Now = " + currentTime);
        Debug.Log("Difference = " + (int)differance.TotalSeconds);

        return (int)differance.TotalSeconds;
    }

    private void OnApplicationQuit()
    {
        _dataManager.SaveAppData();
    }

}
