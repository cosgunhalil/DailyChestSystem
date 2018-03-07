using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyReward : MonoBehaviour {

    public DailyRewardData Data;
    [SerializeField]
    private int _secondsToUnlock;
    [SerializeField]
    private bool _isLocked;

    public void Init(int elapsedTime, int secondsToUnlock)
    {
        secondsToUnlock -= elapsedTime;

        if (_secondsToUnlock < 0)
        {
            //TODO calculate elapsed time
        }

        if (_secondsToUnlock > 0)
        {
            _isLocked = true;
            StartTimer();
        }
        else
        {
            _isLocked = false;
        }

    }

    private void StartTimer()
    {
        StartCoroutine("Counter");
    }

    private IEnumerator Counter()
    {
        var wait = new WaitForSeconds(1f);
        while (_secondsToUnlock > 0)
        {
            _secondsToUnlock--;
            yield return wait;
        }

        _isLocked = false;
    }

    public int GetSecondsToUnlock()
    {
        return _secondsToUnlock;
    }


}
