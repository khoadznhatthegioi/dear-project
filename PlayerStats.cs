using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject firstSavedObject;
    public InventoryObject inventoryObject;
    public SaveSystem saveSystem;

    PlayerData data;
    // [SerializeField] public PlayerData playerData;

    private void Update()
    {
        if (PlayerData.firstSaved == true)
        {
            firstSavedObject.SetActive(false);
            inventoryObject.Save();
            saveSystem.Save();
        }

        if(PlayerData.secondSaved == true)
        {
            inventoryObject.Save();
            saveSystem.Save();
        }

    }
    public void SavePlayer()
    {
        Debug.Log("saysth");
        
        
    }

    public void LoadPlayer()
    {
        //SaveSystem.Load();
        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;
        saveSystem.Load();
        inventoryObject.Load();
    }
}
