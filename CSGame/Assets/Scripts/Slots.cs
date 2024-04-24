<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
=======
>>>>>>> main
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
<<<<<<< HEAD

    public Item item; //items
    public int itemCount; //items count
    public Image itemImage;

    //needed components
=======
    public Item item;
    public int itemCount;
    public Image itemImage;
>>>>>>> main
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
<<<<<<< HEAD
    private void SetColor(float _alpha){
=======

    private void SetColor(float _alpha)
    {
>>>>>>> main
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
<<<<<<< HEAD
    public void Additem(Item _item, int _count = 1){
=======

    public void Additem(Item _item, int _count = 1)
    {
>>>>>>> main
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

<<<<<<< HEAD
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
=======
        if (item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
>>>>>>> main
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

<<<<<<< HEAD

        text_Count.text = "0";
        go_CountImage.SetActive(false);
        
=======
        text_Count.text = "0";
        go_CountImage.SetActive(false);
>>>>>>> main
    }
}