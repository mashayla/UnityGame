using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range = 20f;
    private bool pickupActivated = false;
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Inventory theInventory;

    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            range += 5F;
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated && hitInfo.transform != null)
        {
            Debug.Log("I got " + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName);
            theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
            Destroy(hitInfo.transform.gameObject);
            InfoDisappear();
        }
    }

    private void CheckItem()
    {
        // Corrected raycast direction
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;
    }

    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}