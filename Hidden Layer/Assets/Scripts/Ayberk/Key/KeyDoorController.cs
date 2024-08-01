using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController:MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation Names")] 
        [SerializeField]  private string openAnimationName = "DoorOpen";
        [SerializeField]  private string closeAnimationName = "DoorClose";

        [SerializeField] private int timeToShowUı = 1;
        [SerializeField] private GameObject showDoorLockedUI =null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDıırInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventory.hasKey)
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void OpenDoor()
        {
            if (!doorOpen&&!pauseInteraction)
            {
                doorAnim.Play(openAnimationName,0,0.0f);
                doorOpen = true;
                StartCoroutine(PauseDıırInteraction());
            }
            else if(doorOpen&&!pauseInteraction)
            {
                doorAnim.Play(closeAnimationName,0,0.0f);
                doorOpen = false;
                StartCoroutine(PauseDıırInteraction());
            }
        }
        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUı);
            showDoorLockedUI.SetActive(false);

        }
    }
}