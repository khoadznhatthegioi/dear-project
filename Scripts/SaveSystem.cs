using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityStandardAssets.Characters.FirstPerson; 
using ExamineSystem;

public class SaveSystem : MonoBehaviour
{
    //public PlayerData playerData1;
    [SerializeField] public PlayerData playerData;
    public GameObject video;
    public GameObject violin;
    public GameObject fpsController;
    public GameObject playerCamera;
    public FirstPersonController fpsc;
    public InventoryObject inventoryObject;
    public bool checkSaving;
    public static bool isNewGame =true;
    public GameObject imageSave;
    //[ContextMenu("Save")]
    public void Save()
    {
        //string json = JsonUtility.ToJson(playerData);
        //Debug.Log("sth");
        //File.WriteAllText($"{Application.persistentDataPath}/save.dchanthavy", json); 
        if(DisplayInventory.sceneLoaded == true || DisplayInventory.sceneLoaded1 == true || DisplayInventory.sceneLoaded2 || DisplayInventory.sceneLoaded3 || BasicDoorRaycast.sceneLoaded1 || BasicDoorRaycast.sceneLoaded2)
            imageSave.SetActive(true);
        var bf = new BinaryFormatter();
        FileStream file = File.Create($"{Application.persistentDataPath}/save.dchanthavy");
        bf.Serialize(file, playerData);
        file.Close();
    }
    
    public void Load()
    {

        isNewGame = false;
        //if (!File.Exists($"{Application.persistentDataPath}/save.dchanthavy")) { return; }
        //string json = File.ReadAllText($"{Application.persistentDataPath}/save.dchanthavy");
        //playerData = JsonUtility.FromJson<PlayerData>(json);
        var bf = new BinaryFormatter();
        FileStream file = File.Open($"{Application.persistentDataPath}/save.dchanthavy", FileMode.Open);
        playerData = (PlayerData)bf.Deserialize(file);
        file.Close();
        inventoryObject.Load();
        //if (checkSaving == false)
        //{
        //    StartCoroutine(Waiter());
        //    IEnumerator Waiter()
        //    {
        //        yield return new WaitForSeconds(2f);
        //        if (PlayerData.firstSaved == true && PlayerData.secondSaved == false && PlayerData.thirdSaved == false && PlayerData.fourthSaved == false && PlayerData.fifthSaved == false && PlayerData.sixthSaved == false)
        //        {
        //            Debug.Log("asdasd");
        //            fpsc.enabled = false;
        //            GameObject.Find("FPSController_Prefab").transform.position = new Vector3(1, 1, -2);
        //            fpsController.transform.eulerAngles = new Vector3(0, 75, 0);
        //            //   playerCamera.transform.eulerAngles = new Vector3(14, 0, 0);
        //            StartCoroutine(Waiter1());
        //            IEnumerator Waiter1()
        //            {
        //                yield return new WaitForSeconds(0.1f);
        //                //fpsc.enabled = true;
        //            }
        //            checkSaving = true;
        //        }
        //        if (PlayerData.secondSaved == true && PlayerData.thirdSaved == false && PlayerData.fourthSaved == false && PlayerData.fifthSaved == false && PlayerData.sixthSaved == false)
        //        {

        //            Debug.Log("asdasdsadsadsadsadsadsadsadsadsadsadsadsadsadsdsadsadasdsadas");
        //            fpsc.enabled = false;
        //            fpsController.transform.position = new Vector3(3, 1, 3);
        //            //fpsController.transform.eulerAngles = new Vector3(0, 75, 0);
        //            //playerCamera.transform.eulerAngles = new Vector3(14, 0, 0);
        //            StartCoroutine(Waiter2());
        //            IEnumerator Waiter2()
        //            {
        //                yield return new WaitForSeconds(0.1f);
        //                fpsc.enabled = true;
        //            }
        //        }

        //        if (PlayerData.thirdSaved == true && PlayerData.fourthSaved == false && PlayerData.fifthSaved == false && PlayerData.sixthSaved == false)
        //        {
        //            fpsc.enabled = false;
        //            video.SetActive(true);
        //            violin.SetActive(true);
        //            fpsController.transform.position = new Vector3(1, 1, -2);
        //            fpsController.transform.eulerAngles = new Vector3(0, 75, 0);
        //            playerCamera.transform.eulerAngles = new Vector3(14, 0, 0);
        //            StartCoroutine(Waiter3());
        //            IEnumerator Waiter3()
        //            {
        //                yield return new WaitForSeconds(0.1f);
        //                fpsc.enabled = true;
        //            }
        //        }
        //        if (PlayerData.fifthSaved == true && PlayerData.sixthSaved == false && PlayerData.seventhSaved == false)
        //        {
        //            fpsc.enabled = false;
        //            fpsController.transform.position = new Vector3(-5, 1, -1);
        //            //fpsController.transform.eulerAngles = new Vector3(0, 75, 0);
        //            //p/layerCamera.transform.eulerAngles = new Vector3(14, 0, 0);
        //            StartCoroutine(Waiter5());
        //            IEnumerator Waiter5()
        //            {
        //                yield return new WaitForSeconds(0.1f);
        //                fpsc.enabled = true;
        //            }
        //        }
        //        if (PlayerData.sixthSaved == true && PlayerData.seventhSaved == false)
        //        {
        //            Debug.Log("asdhasjdhjkashdjskahdjksahdjkashdjkahd");
        //            fpsc.enabled = false;
        //            fpsController.transform.position = new Vector3(1, 1, 6);
        //            //            StartCoroutine(Waiter4());
        //            IEnumerator Waiter4()
        //            {
        //                yield return new WaitForSeconds(0.1f);
        //                fpsc.enabled = true;
        //            }
        //        }
        //    }

        //}
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
        if (playerData.secondSavedInt == 1)
            PlayerData.secondSaved = true;
        if (PlayerData.thirdSaved == true)
            playerData.thirdSavedInt = 1;
        if (playerData.thirdSavedInt == 1)
            PlayerData.thirdSaved = true;
        if (PlayerData.fourthSaved == true)
            playerData.fourthSavedInt = 1;
        if (playerData.fourthSavedInt == 1)
            PlayerData.fourthSaved = true;
        if (PlayerData.fifthSaved == true)
            playerData.fifthSavedInt = 1;
        if (playerData.fifthSavedInt == 1)
            PlayerData.fifthSaved = true;
        if (PlayerData.sixthSaved == true)
            playerData.sixthSavedInt = 1;
        if (playerData.sixthSavedInt == 1)
            PlayerData.sixthSaved = true;
        if (PlayerData.seventhSaved == true)
            playerData.seventhSavedInt = 1;
        if (playerData.seventhSavedInt == 1)
            PlayerData.seventhSaved = true;
        if (PlayerData.eighthSaved == true)
            playerData.eighthSavedInt = 1;
        if (playerData.eighthSavedInt == 1)
            PlayerData.eighthSaved = true;

        if (PlayerData.document1 == true)
            playerData.document1Int = 1;
        if (playerData.document1Int == 1)
            PlayerData.document1 = true;
        if (PlayerData.document2 == true)
            playerData.document2Int = 1;
        if (playerData.document2Int == 1)
            PlayerData.document2 = true;

        



        //if (PlayerData.secondSaved == true)
        //{
        //    fpsController.transform.position = new Vector3(2, 1, 10);
        //}

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
    public static bool thirdSaved = false;
    public static bool fourthSaved = false;
    public static bool fifthSaved = false;
    public static bool sixthSaved = false;
    public static bool seventhSaved = false;
    public static bool eighthSaved = false;

    public static bool document1 = false;
    public static bool document2 = false;
    public static bool document3 = false;
    public static bool document4 = false;
    public static bool document5 = false;
    public static bool document6 = false;
    public static bool document7 = false;
    public static bool document8 = false;
    public static bool document9 = false;
    public static bool document10 = false;
    public static bool document11 = false;
    public static bool document12 = false;
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
    public int thirdSavedInt = 0;
    public int fourthSavedInt = 0;
    public int fifthSavedInt = 0;
    public int sixthSavedInt = 0;
    public int seventhSavedInt = 0;
    public int eighthSavedInt = 0;

    public int document1Int = 0;
    public int document2Int = 0;
    public int document3Int = 0;
    public int document4Int = 0;
    public int document5Int = 0;
    public int document6Int = 0;
    public int document7Int = 0;
    public int document8Int = 0;
    public int document9Int = 0;
    public int document10Int = 0;
    public int document11Int = 0;
    public int document12Int = 0;


    public float[] position;

    public PlayerData(PlayerStats playerStats)
    {
        position = new float[3];
        position[0] = playerStats.transform.position.x;
        position[1] = playerStats.transform.position.y;
        position[2] = playerStats.transform.position.z;
    }

    
}

