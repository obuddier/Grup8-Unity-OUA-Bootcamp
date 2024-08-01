using System;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController:MonoBehaviour
    {
        [SerializeField] private bool door = false;
        [SerializeField] private bool key = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (door)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
           
        }

        public void ObjectInteraction()
        {
            if (door)
            {
                doorObject.PlayAnimation();
            }
            
            else if (key)
            {
                _keyInventory.hasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}