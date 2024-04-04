using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for handling click events


public class MedicinePickUp : MonoBehaviour
{
    // This method is called when the bottle is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Make the bottle disappear
        gameObject.SetActive(false);

        // Optionally, increase HP or perform other actions here
        // For example, to increase HP, you might call a method on a player controller:
        // PlayerController.Instance.IncreaseHP(10);
    }
}
