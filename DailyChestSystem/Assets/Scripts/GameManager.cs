using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public DataManager _dataManager;
    public TimeManager _timeManager;
    public ChestManager _chestManager;

	// Use this for initialization
	void Start () 
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _dataManager.Init();
        Debug.Log("Last closed time = " + _dataManager.GetAppLastClosingTime());
        Debug.Log("Now = " + NtpServerConnectionManager.Instance.GetTime());
	}

    private void OnApplicationQuit()
    {
        _dataManager.SaveAppLastClosingTime();
    }

}
