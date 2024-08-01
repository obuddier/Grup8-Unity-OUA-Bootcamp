using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast:MonoBehaviour
    {
        [SerializeField] private int rayLenght = 5;
        [SerializeField] private LayerMask LayerMaskInteract;
        [SerializeField] private string excluseLayerName=null;

        private KeyItemController raycastedObject;
        
        [SerializeField]  private KeyCode openDoorKey = KeyCode.Mouse0;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";
        private string parchmentTag = "Parchment";


        public int ParchmentCount = 0;
        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | LayerMaskInteract.value;

            if (Physics.Raycast(transform.position,fwd,out hit,rayLenght,mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }

                else if (hit.collider.CompareTag(parchmentTag))
                { 
                    CrosshairChange(true);
                    isCrosshairActive = true;
                    
                    if (Input.GetKeyDown(openDoorKey))
                    {
                        isCrosshairActive = true;
                        Destroy(hit.collider.gameObject);
                        ParchmentCount += 1;
                        Debug.Log(ParchmentCount);
                    }
                }
            }

            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange(bool on)
        {
            if (on&&!doOnce)
            {
                crosshair.color=Color.red;
            }
            else
            {
                crosshair.color=Color.white;
                isCrosshairActive = false;
            }
        }
    }
    }
