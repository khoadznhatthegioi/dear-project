using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeUpCrayon : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject seenObject;
    public void OnTriggerStay(Collider other)
    {

        if (seenObject.activeInHierarchy == true)
        {
            Debug.Log("ok");
            var item = other.GetComponent<NotOnGroundItem>();
            if (item)
            {
                inventory.AddItem(new Item(item.item), 1);
                seenObject.SetActive(false);

            }
        }

    }
}
