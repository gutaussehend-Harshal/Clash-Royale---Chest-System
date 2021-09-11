using System;
using UnityEngine;

/// <summary>
/// This class contains chests logic.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    [Serializable]
    public class ChestController
    {
        [Header("Chest Properties")]
        public string type;
        public int coins;
        public int gems;
        public int timeToUnlock;
        public string status;
        public int unlockGems;

        // DateTime startTimeStamp;

        [HideInInspector]
        public bool isAddedToQueue;
        [HideInInspector]
        public bool isEmpty;
        [HideInInspector]
        public bool isLocked;
        [HideInInspector]
        private bool isChestCanBeUnlocked;
        private  string message;
        private Sprite emptySprite;
        // private Timer timer;

        public ChestModel ChestModel { get; }
        public ChestView ChestView { get; }

        public ChestController(ChestModel chestModel, ChestView chestPrefab, Sprite chestSprite)
        {
            ChestModel = chestModel;
            ChestView = GameObject.Instantiate<ChestView>(chestPrefab);
            ChestView.chestController = this;
            emptySprite = chestSprite;
            Debug.Log("ChestView Created", ChestView);
            // timer = ChestView.GetComponent<Timer>();
        }

        // Make chest empty
        public void MakeChestEmpty()
        {
            ChestModel.SetType("Empty");
            ChestModel.SetCoins(0);
            ChestModel.SetGems(0);
            ChestModel.SetTimeToUnlock(0);
            isEmpty = true;
            status = "Empty";
            isAddedToQueue = false;
            unlockGems = 0;
            ChestView.currentSprite = emptySprite;
            ChestView.DisplayChestData();
        }

        // Set data function
        public void AddChestToController(ChestScriptableObject chestSO, Sprite chestSprite)
        {
            isLocked = true;
            isEmpty = false;
            type = chestSO.type;
            coins = UnityEngine.Random.Range(chestSO.minCoins, chestSO.maxCoins);
            gems = UnityEngine.Random.Range(chestSO.minGems, chestSO.maxGems);
            timeToUnlock = chestSO.timeToUnlockInSeconds;
            status = "Locked";
            // unlockGems = CountGemsToUnlock(timeToUnlock);
            ChestView.currentSprite = chestSprite;
            ChestView.DisplayChestData();
        }

        // Count gems to unlock chest
        // public int CountGemsToUnlock(int timeToUnlock)
        // {
        //     int noOfGems = 0;
        //     int unlockTimeInMin = timeToUnlock / 60;
        //     noOfGems = unlockTimeInMin / 10;
        //     // Debug.Log("No of Gems: " + noOfGems);
        //     return noOfGems + 1;
        // }

        // Unlock chest using gems
        public void UnlockChestUsingGems()
        {
            isChestCanBeUnlocked = Player.Instance.RemoveFromPlayer(unlockGems);
            if (isChestCanBeUnlocked)
            {
                ChestUnlocked();
            }
            else
            {
                ChestService.Instance.DisplayMessageOnPopUp("Unsufficient Gems. Cannot Unlock Chest");
            }
        }

        // Show chest unlock
        public void ChestUnlocked()
        {
            Debug.Log("Chest Unlocked");
            // timer.enabled = false;
            isLocked = false;
            status = "Unlocked";
            // timeToUnlock = 0;
            unlockGems = 0;
            ChestView.DisplayChestData();
            ChestService.Instance.UnlockNextChest(ChestView);
        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        // Show chest status
        public void ChestClicked()
        {
            if (isEmpty)
            {
                message = "Chest Slot is Empty";
                ChestService.Instance.DisplayMessageOnPopUp(message);
                return;
            }
            if (!isLocked)
            {
                Player.Instance.AddToPlayer(coins, gems);
                message = "Added " + coins + " coins and " + gems + " gems";
                ChestService.Instance.DisplayMessageOnPopUp(message);
                MakeChestEmpty();
            }
            else
            {
                message = "Chest is Locked.";
                ChestService.Instance.DisplayPopUp(this, isAddedToQueue, message, unlockGems);
            }
        }

        // public void StartTimer()
        // {
        //     timer.SetController(this);
        //     timer.enabled = true;
        // }
    }
}