using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public DataManager _dataManager;
    public TimeManager _timeManager;
    public NtpServerConnectionManager _ntpServerConnectionManager;
    public ChestManager _chestManager;

	// Use this for initialization
	void Start () 
    {
        if (Instance == null)
        {
            Instance = this;
        }
	}
}
