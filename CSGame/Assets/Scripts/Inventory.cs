using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;
    
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    private Slots[] slots;


    // Start is called before the first frame update
    void Start()
    {   
        slots = go_SlotsParent.GetComponentsInChildren<Slots>();

        
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    void TryOpenInventory()
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

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

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

}