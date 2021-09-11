using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Outscal.ChestRoyalSystem
{
    public class ChestView : MonoBehaviour
    {
        [HideInInspector]
        public ChestController chestController;

        [Header("Text Settings")]
        // [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI gemsText;
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private TextMeshProUGUI unlockGemsText;
        public Sprite currentSprite;


        void Start()
        {
            transform.SetParent(ChestService.GetInstance().chestSlotGroup.transform);
            chestController.MakeChestEmpty();
        }

        // Display Chest Data
        public void DisplayChestData()
        {
            // timerText.text = "Timer:" + chestController.timeToUnlock.ToString();
            typeText.text = "Type:" + chestController.type;
            gemsText.text = "Gems:" + chestController.gems.ToString();
            coinsText.text = "Coins:" + chestController.coins.ToString();
            statusText.text = "Status:" + chestController.status;
            unlockGemsText.text = "GemsToUnlock:" + chestController.unlockGems.ToString();
            gameObject.GetComponent<Image>().sprite = currentSprite;
        }

        // Chest button on click
        public void ChestButtonOnClicked()
        {
            chestController.ChestClicked();
        }

        // Show timer and unlock gems
        public void DisplayTimerAndUnlockGems(int timeLeft, int UnlockGems)
        {
            // timerText.text = "Timer:" + timeLeft.ToString();
            unlockGemsText.text = "GemsToUnlock:" + UnlockGems.ToString();
        }

        // public string ConvertTimer(int timeInSec)
        // {
        //     //Debug.Log("TimeInSec=" + timeInSec);
        //     string Time = timeInSec.ToString();
        //     if (timeInSec >= 60)
        //     {
        //         int min = timeInSec / 60;
        //         if (min >= 60)
        //         {
        //             min = min % 60;
        //         }

        //         int sec = timeInSec % 60;
        //         int hour = timeInSec / 3600;

        //         if (hour > 0)
        //         {
        //             Time = hour.ToString() + "hr" + min.ToString() + "min" + sec.ToString();
        //         }
        //         else
        //         {
        //             Time = min.ToString() + "min" + sec.ToString();
        //         }
        //     }
        //     return Time + "sec";
        // }
    }
}