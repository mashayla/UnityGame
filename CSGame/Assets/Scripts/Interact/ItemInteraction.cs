using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Transform itemHolder; // Attachment point on the player's body where items will be held
    private GameObject heldItem; // Reference to the currently held item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }

    private void PickUpItem(GameObject item)
    {
        // Disable rendering and physics of the item
        item.GetComponent<Renderer>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        // Parent the item to the itemHolder attachment point
        item.transform.SetParent(itemHolder);

        // Set the position and rotation of the item relative to the attachment point
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        // Store reference to the held item
        heldItem = item;
    }

    public void DropItem()
    {
        if (heldItem != null)
        {
            // Enable rendering and physics of the held item
            heldItem.GetComponent<Renderer>().enabled = true;
            heldItem.GetComponent<Rigidbody>().isKinematic = false;

            // Detach the item from the itemHolder attachment point
            heldItem.transform.SetParent(null);

            // Reset the reference to the held item
            heldItem = null;
        }
    }
}
