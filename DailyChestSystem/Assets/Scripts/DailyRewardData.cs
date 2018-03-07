using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Daily Reward Data")]
public class DailyRewardData : ScriptableObject {
    
    public int DefaultSecondsToUnlock;
    public int MaxDiamondReward;
    public int MaxGoldReward;

}
