<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
=======
>>>>>>> main
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;
<<<<<<< HEAD
    
=======
>>>>>>> main
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;
<<<<<<< HEAD

    private Slots[] slots;


    // Start is called before the first frame update
    void Start()
    {   
        slots = go_SlotsParent.GetComponentsInChildren<Slots>();

        
    }

    // Update is called once per frame
=======
    private Slots[] slots;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slots>();
    }

>>>>>>> main
    void Update()
    {
        TryOpenInventory();
    }

    void TryOpenInventory()
<<<<<<< HEAD
{
    if(Input.GetKeyDown(KeyCode.I))
    {
        inventoryActivated = ! inventoryActivated;

        if(inventoryActivated)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }
}
=======
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
>>>>>>> main

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

<<<<<<< HEAD
public void AcquireItem(Item _item, int _count = 1){

    if(Item.ItemType.Equipment != _item.itemType){
        for (int i = 0; i < slots.Length; i++){
            if(slots[i].item != null){
                if(slots[i].item.itemName == _item.itemName){
                slots[i].SetSlotCount(_count);
                return;
            }
            }
        }

    }
    for (int i = 0; i < slots.Length; i++){
        if(slots[i].item.itemName == null){
            slots[i].Additem(_item, _count);
            return;
        }

    }
}

=======
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
>>>>>>> main
}