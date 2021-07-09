using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;
using EPOOutline;

public class ClickingOnObjectTest : MonoBehaviour
{
    public static bool i;
    [SerializeField] InventoryDisappear inventoryDisappear;
    //public GameObject noiDay;
    
    private void OnMouseOver()
    {
        //lights up
        if(!i)
        gameObject.GetComponent<Outlinable>().enabled = true;
    }
    private void OnMouseExit()
    {
        //lights out
        if(!i)
        gameObject.GetComponent<Outlinable>().enabled = false;
    }
    private void OnMouseDown()
    {
        inventoryDisappear.TurnOnInventory();
        gameObject.GetComponent<Outlinable>().enabled = true;
        i = true;
    }
}
