using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {

    private string _dataFileName;
    private string _gameDataFilePath;
    private GameData _gameData;


    public void Init()
    {
        _dataFileName = "data.txt";
        _gameDataFilePath = "/Data/data.txt";
    }

    public DateTime GetLastActiveTimeData()
    {
        
        DateTime appLastClosingTime = DateTime.MinValue;

        if (_gameData == null)
        {
            LoadGameData();
        }
            appLastClosingTime = new DateTime(
                _gameData.LastClosingTimeContainer.Year, 
                _gameData.LastClosingTimeContainer.Mounth, 
                _gameData.LastClosingTimeContainer.Day, 
                _gameData.LastClosingTimeContainer.Hour, 
                _gameData.LastClosingTimeContainer.Minute, 
                _gameData.LastClosingTimeContainer.Second
            );

        return appLastClosingTime;
    }

    public GameData GetAppData()
    {
        if (_gameData == null)
        {
            LoadGameData();
        }

        return _gameData;
    }

    private void LoadGameData()
    {
        var filePath = Application.dataPath + _gameDataFilePath;

        if (File.Exists(filePath))
        {
            var dataString = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(dataString);
        }
    }

    public void SaveAppData()
    {
        var gameData = new GameData();
        var dateTime = NtpServerConnectionManager.Instance.GetTime();

        gameData.LastClosingTimeContainer.SetDate(
            dateTime.Year, 
            dateTime.Month, 
            dateTime.Day,
            dateTime.Hour,
            dateTime.Minute,
            dateTime.Second
        ); 

        Debug.Log(gameData.LastClosingTimeContainer.GetDate());

        gameData.DailyRewardData.SecondsToUnlock = GameManager.Instance._dailyReward.GetSecondsToUnlock();

        var gameDataString = JsonUtility.ToJson(gameData);
        Debug.Log(gameDataString);

        var filePath = Application.dataPath + _gameDataFilePath;
        File.WriteAllText(filePath, gameDataString);

        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(gameDataString);
            }
        }
    }
}

[Serializable]
public class GameData
{
    public LastAppClosingTimeContainer LastClosingTimeContainer;
    public DailyRewardDataContainer DailyRewardData;

    public GameData()
    {
        LastClosingTimeContainer = new LastAppClosingTimeContainer();
        DailyRewardData = new DailyRewardDataContainer();
    }

}

[Serializable]
public class LastAppClosingTimeContainer
{
    public int Year;
    public int Mounth;
    public int Day;
    public int Hour;
    public int Minute;
    public int Second;

    public void SetDate(int year, int month, int day, int hour, int minute, int second)
    {
        Day = day;
        Mounth = month;
        Year = year;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public DateTime GetDate()
    {
        var date = new DateTime(Year, Mounth, Day, Hour, Minute, Second);
        return date;
    }
}

[Serializable]
public class DailyRewardDataContainer
{
    public int SecondsToUnlock;
}

