using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Outscal.ChestRoyalSystem
{
    public class PopUpManager : MonoSingleton<PopUpManager>
    {
        [SerializeField] private GameObject popUpScreen;
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Button firstButton;
        [SerializeField] private Button secondButton;
        [SerializeField] private TextMeshProUGUI firstButtonText;
        [SerializeField] private TextMeshProUGUI secondButtonText;
        private Coroutine popUpCoroutine;

        // Display pannel with two buttons
        public void DisplayPopUp(bool chestAddedToQueue, string message, int gemsToUnlock)
        {
            popUpScreen.SetActive(true);
            if (popUpCoroutine != null)
            {
                StopCoroutine(popUpCoroutine);
            }
            // if (!ChestService.GetInstance().timerStarted)
            // {
            //     firstButtonText.text = "Start CountDown";
            // }
            else
            {
                firstButtonText.text = "Add Chest to Unlocking Queue";
            }

            secondButtonText.text = "Unlock using Gems:" + gemsToUnlock.ToString();
            this.message.text = message;

            if (chestAddedToQueue)
            {
                firstButton.transform.gameObject.SetActive(false);
            }
            else
            {
                firstButton.transform.gameObject.SetActive(true);
            }
            secondButton.transform.gameObject.SetActive(true);
        }

        // On button click add chest to unlocking queue
        public void OnFirstBtnClicked()
        {
            popUpScreen.SetActive(false);

            // if (!ChestService.GetInstance().timerStarted)
            // {
            //     Debug.Log("First Chest to be added to Unlocking Queue.");
            //     ChestService.GetInstance().StartUnlockingFirstChest();
            // }
            // else
            // {
                ChestService.GetInstance().AddChestToUnlockingQueue();
            // }
        }

        // On button click unlock chests
        public void OnUnlockChestBtnClicked()
        {
            popUpScreen.SetActive(false);
            ChestService.GetInstance().UnlockChestUsingGemsSelected();
        }

        // Display pannel
        public void OnlyDisplay(string message)
        {
            popUpScreen.SetActive(true);
            this.message.text = message;
            firstButton.transform.gameObject.SetActive(false);
            secondButton.transform.gameObject.SetActive(false);
            popUpCoroutine = StartCoroutine(DisablePopUp());
        }

        IEnumerator DisablePopUp()
        {
            yield return new WaitForSeconds(2f);
            popUpScreen.SetActive(false);
        }
    }
}