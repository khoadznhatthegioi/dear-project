using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;
using EPOOutline;

public class ClickingOnObjectTest : MonoBehaviour
{
    public static bool i;
    public static bool c;
    [SerializeField] InventoryDisappear inventoryDisappear;
    //public GameObject noiDay;
    
    private void OnMouseOver()
    {
        //lights up
        if(!i && !DocumentsListDisappear.isListAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !PauseMenuu.isPauseMenuAlreadyOn && !DisplayInventory.isFixing && !PlayerData.daSua)
        gameObject.GetComponent<Outlinable>().enabled = true;
        c = true;
    }
    private void OnMouseExit()
    {
        //lights out
        if(!i && !DocumentsListDisappear.isListAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !PauseMenuu.isPauseMenuAlreadyOn)
        gameObject.GetComponent<Outlinable>().enabled = false;
    }
    private void OnMouseDown()
    {   
        if(!DocumentsListDisappear.isListAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !PauseMenuu.isPauseMenuAlreadyOn && !DisplayInventory.isFixing && !PlayerData.daSua)
        {
            inventoryDisappear.TurnOnInventory();
            gameObject.GetComponent<Outlinable>().enabled = true;
            i = true;
        }
        
    }
}
