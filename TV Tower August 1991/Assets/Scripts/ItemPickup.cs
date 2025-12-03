using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform playerHoldPoint; // Position am Spieler, z.B. leeres GameObject vor dem Spieler
    private GameObject heldItem;      // aktuell gehaltenes Objekt

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Taste zum Aufheben/Loslassen
        {
            if (heldItem == null)
            {
                TryPickUp();
            }
            else
            {
                DropItem();
            }
        }
    }

    void TryPickUp()
    {
        // Raycast vor den Spieler (2m Reichweite)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.gameObject.CompareTag("Pickable")) // tag zuvor zuweisen
            {
                heldItem = hit.collider.gameObject;
                heldItem.GetComponent<Rigidbody>().isKinematic = true; // Physik aus
                heldItem.transform.SetParent(playerHoldPoint);
                heldItem.transform.localPosition = Vector3.zero;
            }
        }
    }

    void DropItem()
    {
        heldItem.transform.SetParent(null);
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        rb.isKinematic = false; // Physik an
        rb.AddForce(transform.forward * 2f, ForceMode.Impulse); // kleines "wegschubsen"
        heldItem = null;
    }
}
