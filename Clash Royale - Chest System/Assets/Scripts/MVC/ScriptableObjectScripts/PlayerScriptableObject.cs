using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains PlayerScriptableObject.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/NewPlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public string playerName;
        public int coins;
        public int gems;
    }
}