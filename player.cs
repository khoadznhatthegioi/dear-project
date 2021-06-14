using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;

public class player : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject seenObject;
    public GameObject seenObject1;
    public GameObject seenObject3;
    public GameObject seenObject4;
    [SerializeField] DisplayInventory displayInventory;

    public void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("Player"))
        {
            if (seenObject)
                if (seenObject.activeInHierarchy == true)
                {
                    Debug.Log("ok");
                    var item = other.GetComponent<GroundItem>();
                    if (item)
                    {
                        inventory.AddItem(new Item(item.item), 1);
                        seenObject.SetActive(false);

                    }
                }
            if (seenObject1)
                if (seenObject1.activeInHierarchy == true)
                {
                    Debug.Log("ok");
                    var item = other.GetComponent<GroundItem>();
                    if (item)
                    {
                        inventory.AddItem(new Item(item.item), 1);
                        seenObject1.SetActive(false);
                    }
                }
            if (seenObject3)
                if (seenObject3.activeInHierarchy == true)
                {
                    Debug.Log("ok");
                    var item = other.GetComponent<GroundItem>();
                    if (item)
                    {
                        inventory.AddItem(new Item(item.item), 1);
                        seenObject3.SetActive(false);
                        if (displayInventory)
                            PlayerData.daLayLaBua = true;
                    }
                }
            if(seenObject4)
            {
                if(seenObject4.activeInHierarchy == true)
                {
                    var item = other.GetComponent<GroundItem>();
                    if (item)
                    {
                        inventory.AddItem(new Item(item.item), 1);
                        seenObject4.SetActive(false);
                    }
                }
            }
        }
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[6];
    }
}
