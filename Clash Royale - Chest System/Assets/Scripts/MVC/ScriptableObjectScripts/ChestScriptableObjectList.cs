using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// This class contains ChestScriptableObjects.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    [CreateAssetMenu(fileName = "ChestScriptableObjectList", menuName = "ScriptableObjects/NewChestScriptableObjectList")]
    public class ChestScriptableObjectList : ScriptableObject
    {
        [Header("Chest Scriptable Object List Settings")]
        public ChestScriptableObject[] Chests;
    }

    [Serializable]
    public class ChestScriptableObject
    {
        public string type;
        public int minCoins;
        public int maxCoins;
        public int minGems;
        public int maxGems;
        public int timeToUnlockInSeconds;
    }
}