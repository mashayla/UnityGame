using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;
    private Slots[] slots;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slots>();
    }

    void Update()
    {
        TryOpenInventory();
    }

    void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;
            if (inventoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        bool itemAdded = false;

        // First, try to add to an existing slot with the same item
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.itemName == _item.itemName)
            {
                slots[i].SetSlotCount(_count);
                itemAdded = true;
                break;
            }
        }

        // If the item wasn't added to an existing slot, find an empty slot
        if (!itemAdded)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].Additem(_item, _count);
                    itemAdded = true;
                    break;
                }
            }
        }

        // Optionally, handle the case where no slots are available
        if (!itemAdded)
        {
            Debug.Log("No available slots for " + _item.itemName);
        }
    }
}