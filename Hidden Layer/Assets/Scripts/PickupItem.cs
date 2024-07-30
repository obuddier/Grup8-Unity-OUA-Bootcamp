using UnityEngine;
using Fusion;

public class PickupItem : NetworkBehaviour
{
    public Transform playerHand; // Oyuncunun elinde bulunan referans nokta
    private NetworkObject networkObject;

    public override void Spawned()
    {
        networkObject = GetComponent<NetworkObject>();
    }

    public void PickUp(Transform hand)
    {
        playerHand = hand;

        // Objenin pozisyon ve rotasyonunu oyuncunun eline ayarla
        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;

        // Objenin oyuncunun eline baðlý olmasýný saðla
        transform.SetParent(playerHand);

        // Objenin Rigidbody'sini kapat ki fiziksel etkileþim olmasýn
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log("Item picked up!");

        // Photon Fusion üzerinden obje hareketini senkronize et
        Runner.SessionManager.OnObjectPickedUp(networkObject, playerHand);
    }
}
