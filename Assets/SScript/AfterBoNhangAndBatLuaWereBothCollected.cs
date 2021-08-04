using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExamineSystem
{
    public class AfterBoNhangAndBatLuaWereBothCollected : MonoBehaviour
    {
        public ExamineRaycast bothBools;
        public InventoryObject inventoryObject;
        public DisplayInventory displayInventory;
        public InventorySlot item1;
        public InventorySlot item2;
        public InventorySlot item3;
        public InventorySlot item4;
        public InventorySlot item5;
        public InventorySlot item6;
        public OthersObject batLua;
        public OthersObject boNhang;
     //   public GameObject batLua1;
      //  public GameObject boNhang1;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (bothBools.daLayBatLua && bothBools.daLayBoNhang == true)
            {
                Debug.Log("aloalo");
               // displayInventory.UpdateAfterThapNhang(batLua1);
               // displayInventory.UpdateAfterThapNhang(boNhang1);
                //batLua.uiDisplay = null;
                //boNhang.uiDisplay = null;
                inventoryObject.RemoveBoNhangAndBatLua(item1, item2, item3, item4, item5, item6);
            }
        }
    }

}
