using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{

    public Item item; //items
    public int itemCount; //items count
    public Image itemImage;

    //needed components
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    private void SetColor(float _alpha){
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    public void Additem(Item _item, int _count = 1){
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if(item.itemType != Item.ItemType.Equipment){
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else{
            text_Count.text = "0";
            go_CountImage.SetActive(false);
            
        }
        

        SetColor(1);

    }
    public void SetSlotCount(int _count){
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if(itemCount <= 0)
            ClearSlot();
    }
    private void ClearSlot(){
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);


        text_Count.text = "0";
        go_CountImage.SetActive(false);
        
    }
}