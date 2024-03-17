using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionController : MonoBehaviour
{

    [SerializeField]
    private float range;
    
    private bool pickupActivated = false;


    private RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;
 
    [SerializeField]
    private Text actionText;

    [SerializeField]
    private Inventory theInventory;

    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();

    }
    private void TryAction(){
        if (Input.GetKeyDown(KeyCode.Z)){
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp(){
        if (pickupActivated){
            if(hitInfo.transform != null){
                Debug.Log("I got " + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName);
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    private void CheckItem(){
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range,layerMask)){
            if(hitInfo.transform.tag == "Item"){
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear(){
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;
    }

    private void InfoDisappear(){
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
