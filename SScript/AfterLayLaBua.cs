using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;

public class AfterLayLaBua : MonoBehaviour
{
    [SerializeField] DisplayInventory displayInventory;
    public GameObject triggerGiongNoi;

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.daLayLaBua == true)
        {
            //cuamoduoc
            triggerGiongNoi.SetActive(true);
        }  
    }
}
