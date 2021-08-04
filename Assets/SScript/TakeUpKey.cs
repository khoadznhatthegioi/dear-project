using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeUpKey : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject seenObject;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
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
}
