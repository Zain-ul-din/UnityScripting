using UnityEngine;

// Custom Types def 
namespace Randoms.ParkingKit.Internals
{
    // Player Selection
    
    /// <summary>
    /// Player Data Container for Selection
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public   GameObject   playerPrefab;
        public   float        unlockCost;
        public   int          unlockLevel;
    }
    
    /// <summary>
    /// Player Unlock Selection
    /// </summary>
    public enum PlayerUnlockSelection
    {
        Coins ,
        Levels
    }
    
    
}
