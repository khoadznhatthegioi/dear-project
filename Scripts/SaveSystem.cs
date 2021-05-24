using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    //public PlayerData playerData1;
    [SerializeField] public PlayerData playerData;
    public GameObject fpsController;
    public FirstPersonController fpsc;
    public bool checkSaving;
    //[ContextMenu("Save")]
    public void Save()
    {
        //string json = JsonUtility.ToJson(playerData);

        //File.WriteAllText($"{Application.persistentDataPath}/save.dchanthavy", json); 
        var bf = new BinaryFormatter();
        FileStream file = File.Create($"{Application.persistentDataPath}/save.dchanthavy");
        bf.Serialize(file, playerData);
        file.Close();
    }
    
    public void Load()
    {
        if (!File.Exists($"{Application.persistentDataPath}/save.dchanthavy")) { return; }
        //string json = File.ReadAllText($"{Application.persistentDataPath}/save.dchanthavy");
        //playerData = JsonUtility.FromJson<PlayerData>(json);
        var bf = new BinaryFormatter();
        FileStream file = File.Open($"{Application.persistentDataPath}/save.dchanthavy", FileMode.Open);
        playerData = (PlayerData)bf.Deserialize(file);
        file.Close();
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (PlayerData.usedAmulet == true)
            playerData.usedAmuletInt = 1;
        if (playerData.usedAmuletInt == 1)
            PlayerData.usedAmulet = true;
        if (PlayerData.firstSaved == true)
            playerData.firstSavedInt = 1;
        if (playerData.firstSavedInt == 1)
            PlayerData.firstSaved = true;
        if (PlayerData.wasntAbleToEscapeFromQuaiVat == true)
            playerData.wasntAbleToEscapeFromQuaiVatInt = 1;
        if (playerData.wasntAbleToEscapeFromQuaiVatInt == 1)
            PlayerData.wasntAbleToEscapeFromQuaiVat = true;
        if(PlayerData.secondSaved == true)
        {
            playerData.secondSavedInt = 1; 
        }

        if(checkSaving == false)
        {
            if (PlayerData.firstSaved == true && PlayerData.secondSaved == false)
            {
                fpsc.enabled = false;
                fpsController.transform.position = new Vector3(3, 1, -3);
                StartCoroutine(Waiter1());
                IEnumerator Waiter1()
                {
                    yield return new WaitForSeconds(0.1f);
                    fpsc.enabled = true;
                }
                checkSaving = true;
            }
        }
        
        if(PlayerData.secondSaved == true)
        {
            fpsController.transform.position = new Vector3(2, 1, 10);
        }

    }
}

[Serializable]
public class PlayerData
{
    public static bool usedAmulet;
    public static bool wasntAbleToEscapeFromQuaiVat;
    public static bool moTuDien;
    public static bool nhinChaiBia = false;
    public static bool nhinViolinStand = false;
    public static bool nhinBoNhang = false;
    public static bool nhinDiary = false;
    public static bool daLayLaBua = false;
    public static bool isVideoPlayed = false;
    public static bool daSua = false;
    public static bool daKhuiChaiBia = false;
    public static bool firstSaved = false;
    public static bool secondSaved = false;
   // public PlayerStats playerStats;

    public int usedAmuletInt = 0;
    public int wasntAbleToEscapeFromQuaiVatInt =0;
    public int moTuDienInt =0 ;
    public int nhinChaiBiaInt = 0;
    public int nhinViolinStandInt = 0;
    public int nhinBoNhangInt = 0;
    public int nhinDiaryInt = 0;
    public int daLayLaBuaInt = 0;
    public int isVideoPlayedInt = 0;
    public int daSuaInt = 0;
    public int daKhuiChaiBiaInt = 0;
    public int firstSavedInt = 0;
    public int secondSavedInt = 0;

    public float[] position;

    public PlayerData(PlayerStats playerStats)
    {
        position = new float[3];
        position[0] = playerStats.transform.position.x;
        position[1] = playerStats.transform.position.y;
        position[2] = playerStats.transform.position.z;
    }

    
}

