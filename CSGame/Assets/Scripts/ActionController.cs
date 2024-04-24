<<<<<<< HEAD
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
=======
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

>>>>>>> main
    void Update()
    {
        CheckItem();
        TryAction();
<<<<<<< HEAD

    }
    private void TryAction(){
        if (Input.GetKeyDown(KeyCode.Z)){
=======
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            range += 5F;
>>>>>>> main
            CheckItem();
            CanPickUp();
        }
    }

<<<<<<< HEAD
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
=======
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
>>>>>>> main
                ItemInfoAppear();
            }
        }
        else
<<<<<<< HEAD
            InfoDisappear();
    }

    private void ItemInfoAppear(){
=======
        {
            InfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
>>>>>>> main
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;
    }

<<<<<<< HEAD
    private void InfoDisappear(){
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
=======
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
>>>>>>> main
