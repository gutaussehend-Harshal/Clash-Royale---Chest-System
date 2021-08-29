using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles scriptable objects and list for tank.
/// </summary>
// namespace Outscal.Clash Royale Chest System
// {
    [CreateAssetMenu(fileName = "ChestScriptableObjects", menuName = "ScriptableObject/NewChest")]
    public class ChestSO : ScriptableObject
    {
        // [Header("Tank Type Specific")]
        // public TankType tankType;

        // [Header("MVC Essentials")]
        // public TankView tankView;

        // [Header("Tank Movement Variables")]
        // public float movementSpeed;
        // public float rotationSpeed;

        // [Header("Tank Health Variables")]
        // public float health;

        // [Header("Tank Shooting Variables")]
        // public float fireRate;
        // public BulletScriptableObjects bulletType;
    }

    [CreateAssetMenu(fileName = "ChestSO_List", menuName = "ScriptableObjectList/ChestListOfSO")]
    public class ChestSOList : ScriptableObject
    {
        public ChestSO[] chests;
    }
// }