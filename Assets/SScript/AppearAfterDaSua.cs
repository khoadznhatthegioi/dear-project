using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;
public class AppearAfterDaSua : MonoBehaviour
{
    public GameObject doKhui;
    public DisplayInventory displayInventory;
    private void Awake()
    {
        doKhui.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerData.daSua == true)
        {
            doKhui.SetActive(true);
            //bat tv
            this.enabled = false;
        }
    }
}
