using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class creates chests.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    public class ChestService : MonoSingleton<ChestService>
    {
        public GameObject chestSlotGroup;
        [SerializeField] int noOfChestSlots;
        private ChestController[] chestSlots;
        [SerializeField] ChestScriptableObjectList chestSOL;
        [SerializeField] List<ChestView> unlockingQueue;
        [SerializeField] int allowedChestToUnlock = 3;
        [SerializeField] Sprite[] chestSprites;
        // [HideInInspector]
        // public bool timerStarted = false;
        [SerializeField] ChestView chestPrefab;
        private ChestView popUpChest;
        private ChestModel chestModel;
        private ChestController chestController;
        private int chestSlotAlreadyOccupied = 0;

        void Start()
        {
            chestSlots = new ChestController[noOfChestSlots];
            for (int i = 0; i < noOfChestSlots; i++)
            {
                chestSlots[i] = CreateEmptyChestSlot();
            }
        }

        // Create empty chest slot
        private ChestController CreateEmptyChestSlot()
        {
            return CreateNewChestController(chestSOL.Chests[chestSOL.Chests.Length - 1], chestPrefab, chestSprites[chestSprites.Length - 1]);
        }

        // Create new chest controller
        private ChestController CreateNewChestController(ChestScriptableObject chestScriptableObject, ChestView chestPrefab, Sprite chestSprite)
        {
            chestModel = new ChestModel(chestScriptableObject);
            chestController = new ChestController(chestModel, chestPrefab, chestSprite);
            return chestController;
        }

        // Unlock first chest
        public void StartUnlockingFirstChest()
        {
            unlockingQueue.Add(popUpChest);
            Debug.Log("Unlocking queue = " + unlockingQueue.Count);
            popUpChest.chestController.isAddedToQueue = true;
            // popUpChest.chestController.StartTimer();
        }

        // Unlock chest using gems
        public void UnlockChestUsingGemsSelected()
        {
            popUpChest.chestController.UnlockChestUsingGems();
        }

        // Create random chest
        public void CreateRandomChest()
        {
            int randomChest = UnityEngine.Random.Range(0, chestSOL.Chests.Length - 1);
            AddChestToSlot(randomChest);
        }

        // Add chest to unlocking queue
        public void AddChestToUnlockingQueue()
        {
            // if (timerStarted && unlockingQueue.Count == allowedChestToUnlock)
            if (unlockingQueue.Count == allowedChestToUnlock)
            {
                Debug.Log("Unlocking Queue Limit Reached");
                DisplayMessageOnPopUp("Unlocking Queue Limit Reached");
            }
            else
            {
                Debug.Log("Chest added to Unlocking Queue.");
                DisplayMessageOnPopUp("Chest added to Unlocking Queue.");
                unlockingQueue.Add(popUpChest);
                popUpChest.chestController.isAddedToQueue = true;
            }
        }

        // Add chest to slot
        public void AddChestToSlot(int chestIndex)
        {
            for (int i = 0; i < chestSlots.Length; i++)
            {
                if (chestSlots[i].IsEmpty())
                {
                    chestSlots[i].AddChestToController(chestSOL.Chests[chestIndex], chestSprites[chestIndex]);
                    DisplayMessageOnPopUp("Chest Added to Slot:" + ++i);
                    i = chestSlots.Length + 1;
                }
                else
                {
                    chestSlotAlreadyOccupied++;
                }
            }
            if (chestSlotAlreadyOccupied == chestSlots.Length)
            {
                Debug.Log("Chest not added. All slots are occupied");
                DisplayMessageOnPopUp("Chest not added. All slots are occupied");
            }
        }

        // Unlock next chest
        public void UnlockNextChest(ChestView unlockedChestView)
        {
            unlockingQueue.Remove(unlockedChestView);
            // if (unlockingQueue.Count > 0)
            // {
            //     unlockingQueue[0].chestController.StartTimer();
            // }
        }   

        // Display pannel
        public void DisplayMessageOnPopUp(string message)
        {
            PopUpManager.GetInstance().OnlyDisplay(message);
        }

        // Display pannel
        public void DisplayPopUp(ChestController callingChestController, bool chestAddedToQueue, string message, int gemsToUnlock)
        {
            popUpChest = callingChestController.ChestView;
            PopUpManager.GetInstance().DisplayPopUp(chestAddedToQueue, message, gemsToUnlock);
        }
    }
}