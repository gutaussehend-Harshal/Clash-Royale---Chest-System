using System;
using UnityEngine;

namespace Outscal.ChestRoyalSystem
{
    public class Timer : MonoBehaviour
    {
        private DateTime startTimeStamp;
        private ChestController unlockingChest;
        [SerializeField] int timer;

        void Start()
        {
            StartTimer();
        }

        void Update()
        {
            StartUnlockingChest();
        }

        public void SetController(ChestController controller)
        {
            unlockingChest = controller;
        }

        public void StartTimer()
        {
            startTimeStamp = DateTime.Now;
            Debug.Log("StartTimeStamp=" + startTimeStamp);
            // ChestService.GetInstance().timerStarted = true;
        }

        public void StartUnlockingChest()
        {
            DateTime curtimer = DateTime.Now;
            timer = GetSubSeconds(startTimeStamp, curtimer);
            int timeLeft = unlockingChest.ChestModel.TimeToUnlock - timer;
            // unlockingChest.unlockGems = unlockingChest.CountGemsToUnlock(timeLeft);
            unlockingChest.ChestView.DisplayTimerAndUnlockGems(timeLeft, unlockingChest.unlockGems);
            if (timer >= unlockingChest.ChestModel.TimeToUnlock)
            {
                Debug.Log("Chest Unlocked at " + curtimer);
                unlockingChest.ChestUnlocked();
            }
        }

        public int GetSubSeconds(DateTime startTimer, DateTime endTimer)
        {
            TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

            TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

            TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

            return (int)subTimer.TotalSeconds;
        }
    }
}