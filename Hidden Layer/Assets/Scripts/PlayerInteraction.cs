using UnityEngine;
using Fusion;

public class PlayerInteraction : NetworkBehaviour
{
    public float interactionRange = 3f;
    public LayerMask interactableLayer;
    public Transform handPosition; // Oyuncunun elindeki referans noktasý

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                PickupItem pickupItem = interactable as PickupItem;
                if (pickupItem != null)
                {
                    pickupItem.PickUp(handPosition);
                }
                interactable.Interact();
            }
        }
    }
}
