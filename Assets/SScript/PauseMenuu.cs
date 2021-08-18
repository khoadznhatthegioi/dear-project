using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;
using System.Collections;

public class PauseMenuu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject bgi;
    public GameObject mainCam;//your other object 
    public string examineRay = "ExamineRaycast";// your secound script name
    public string putOnRay = "PutOnRaycast";
    public string doorRaycast = "BasicDoorRaycast";
    public string violinRaycast;
    public string zoomInRay;
    RectTransform rectTransform;
    public GameObject blurOut;
    [SerializeField] public Image crosshair = null;
    [SerializeField] public FirstPersonController player = null;
    //[SerializeField] public BlurOptimized blur = null;
    public static bool isPauseMenuAlreadyOn;
    public DisplayInventory displayInventory;
    public InventoryDisappear inventoryDisappear;
    public GameObject violinUi;
    public BoxCollider violinBdCollider;
    public GameObject video;
    public GameObject[] documentsUI;
    [SerializeField] GameObject imageSaving;
    public DocumentsListDisappear documentsList;
    public GameObject subPlayer;
    public GameObject subCam;
    public GameObject lolUSure;
    public bool lolUSuring;

    [Header("For Settings")]
    [SerializeField] RHC_BobController RHC_Bob;
    [SerializeField] GameObject gameplayOptions;
    [SerializeField] GameObject settingsCanvas;
    public bool isHeadbobOn= true;

    void Update()
    {
        if (player.gameObject.activeInHierarchy == false)
        {

            subPlayer = GameObject.Find("FPSController_Prefab (2)");
            subCam = GameObject.Find("/FPSController_Prefab (2)/MainCamera");
            if (subPlayer)
            {
                player = subPlayer.GetComponent<FirstPersonController>();
                mainCam = subCam;
            }
        }
        if (video)
        {
            if (!DisplayInventory.isFixing && video.activeInHierarchy == false && InventoryDisappear.isInventoryAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && DocumentsListDisappear.isListAlreadyOn == false && isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }

            }
            else if (isPauseMenuAlreadyOn == true && lolUSuring == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Resume();
                    //if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                    //{
                    //    crosshair.enabled = false;
                    //    Cursor.lockState = CursorLockMode.None;
                    //    Cursor.visible = true;
                    //}
                }

            }
        }
        if (!video)
        {
            if (!DisplayInventory.isFixing && InventoryDisappear.isInventoryAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && DocumentsListDisappear.isListAlreadyOn == false && isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }

            }
            else if (isPauseMenuAlreadyOn == true && lolUSuring == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Resume();
                    //if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                    //{
                    //    crosshair.enabled = false;
                    //    Cursor.lockState = CursorLockMode.None;
                    //    Cursor.visible = true;
                    //}
                }

            }
        }
    }

    public void Pause()
    {
        //Debug.Log("haha");
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //blur.enabled = true;
        bgi.SetActive(true);
        crosshair.enabled = false;
        player.enabled = false;
        Time.timeScale = 0f;
        for (int i = 0; i < documentsList.giongNoiChuyen.Length; i++)
        {
            if (documentsList.giongNoiChuyen[i].isPlaying)
            {
                documentsList.alreadyPlayed[i] = true;
            }
            documentsList.giongNoiChuyen[i].Pause();
        }
        blurOut.SetActive(true);
        if(violinRaycast != "")
        {
            (mainCam.GetComponent(violinRaycast) as MonoBehaviour).enabled = false;
        }
        if (zoomInRay != "")
        {
            (mainCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
        }
        mainCam.GetComponent<ExamineSystem.ExamineRaycast>().enabled = false;
        (mainCam.GetComponent(putOnRay) as MonoBehaviour).enabled = false;
        (mainCam.GetComponent(doorRaycast) as MonoBehaviour).enabled = false;
        isPauseMenuAlreadyOn = true;
    }
    public void Resume()
    {
        if (!PlayerData.moTuDien && !PlayerData.nhinDiary )
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            settingsCanvas.SetActive(false);
            for (int i = 0; i < documentsUI.Length; i++)
            {
                documentsUI[i].SetActive(false);
            }
            //blur.enabled = false;
            bgi.SetActive(false);
            crosshair.enabled = true;
            player.enabled = true;
            Time.timeScale = 1f;
            for (int i = 0; i < documentsList.giongNoiChuyen.Length; i++)
            {
                if (documentsList.alreadyPlayed[i] == true)
                    documentsList.giongNoiChuyen[i].Play();
            }
            blurOut.SetActive(false);
            if (zoomInRay != "")
            {
                (mainCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = true;
            }
            if (violinRaycast != "")
            {
                (mainCam.GetComponent(violinRaycast) as MonoBehaviour).enabled = true;
            }
            mainCam.GetComponent<ExamineSystem.ExamineRaycast>().enabled = true;
            (mainCam.GetComponent(putOnRay) as MonoBehaviour).enabled = true;
            (mainCam.GetComponent(doorRaycast) as MonoBehaviour).enabled = true;
            isPauseMenuAlreadyOn = false;
            //if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
            //{
            //    crosshair.enabled = false;
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //}
        }
        else if (PlayerData.moTuDien || PlayerData.nhinDiary)
        {
            pauseMenu.SetActive(false);
           
            Time.timeScale = 1f;
            //blur.enabled = false;
            bgi.SetActive(false);
            settingsCanvas.SetActive(false);
            blurOut.SetActive(false);
            for (int i = 0; i < documentsList.giongNoiChuyen.Length; i++)
            {
                if (documentsList.alreadyPlayed[i] == true)
                    documentsList.giongNoiChuyen[i].Play();
            }
            blurOut.SetActive(false);
            if (zoomInRay != "")
            {
                //(mainCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = true;
            }
            if (violinRaycast != "")
            {
                (mainCam.GetComponent(violinRaycast) as MonoBehaviour).enabled = true;
            }
            mainCam.GetComponent<ExamineSystem.ExamineRaycast>().enabled = true;
            (mainCam.GetComponent(putOnRay) as MonoBehaviour).enabled = true;
            (mainCam.GetComponent(doorRaycast) as MonoBehaviour).enabled = true;
            isPauseMenuAlreadyOn = false;
        }
        //Debug.Log("hoho");
       
    }

    public void Quit()
    {
        isPauseMenuAlreadyOn = false;
        SceneManager.LoadScene("mainmenu");
        //PlayerData.firstSaved = false;
        //PlayerData.secondSaved = false;
        //PlayerData.thirdSaved = false;
        //PlayerData.fourthSaved = false;
        //PlayerData.fifthSaved = false;
        //PlayerData.sixthSaved = false;
        //PlayerData.seventhSaved = false;
        //PlayerData.eighthSaved = false;
        //PlayerData.document1 = false;
        //PlayerData.document2 = false;
        //PlayerData.document3 = false;
        //PlayerData.document4 = false;
        //PlayerData.document5 = false;
        //PlayerData.document6 = false;
        //PlayerData.document7 = false;
        //PlayerData.document8 = false;
        //PlayerData.document8 = false;
        //PlayerData.document9 = false;
        //PlayerData.document10 = false;
        //PlayerData.document11 = false;
        //PlayerData.document12 = false;
        //PlayerData.usedAmulet = false;
        //PlayerData.wasntAbleToEscapeFromQuaiVat = false;
        //PlayerData.moTuDien = false;
        //PlayerData.nhinChaiBia = false;
        //PlayerData.nhinViolinStand = false;
        //PlayerData.nhinBoNhang = false;
        //PlayerData.nhinDiary = false;
        //PlayerData.daLayLaBua = false;
        //PlayerData.isVideoPlayed = false;
        //PlayerData.daSua = false;
        //PlayerData.daKhuiChaiBia = false;
        //playerData.firstSavedInt = 0;
        //playerData.secondSavedInt = 0;
        //playerData.thirdSavedInt = 0;
        //playerData.fourthSavedInt = 0;
        //playerData.fifthSavedInt = 0;
        //playerData.sixthSavedInt = 0;
        //playerData.seventhSavedInt = 0;
        //playerData.eighthSavedInt = 0;
        //playerData.document1Int = 0;
        //playerData.document2Int = 0;
        //playerData.document3Int = 0;
        //playerData.document4Int = 0;
        //playerData.document5Int = 0;
        //playerData.document6Int = 0;
        //playerData.document7Int = 0;
        //playerData.document8Int = 0;
        //playerData.document8Int = 0;
        //playerData.document9Int = 0;
        //playerData.document10Int = 0;
        //playerData.document11Int = 0;
        //playerData.document12Int = 0;
        //playerData.usedAmuletInt = 0;
        //playerData.wasntAbleToEscapeFromQuaiVatInt = 0;
        //playerData.moTuDienInt = 0;
        //playerData.nhinChaiBiaInt = 0;
        //playerData.nhinViolinStandInt = 0;
        //playerData.nhinBoNhangInt = 0;
        //playerData.nhinDiaryInt = 0;
        //playerData.daLayLaBuaInt = 0;
        //playerData.isVideoPlayedInt = 0;
        //playerData.daSuaInt = 0;
        //playerData.daKhuiChaiBiaInt = 0;

    }
    public void CancelQuitting()
    {
        lolUSuring = false;
        lolUSure.SetActive(false);
    }

    public void QuitButton()
    {
        lolUSuring = true;
        lolUSure.SetActive(true);
    }

    public void SettingsButton()
    {
        pauseMenu.SetActive(false);
        settingsCanvas.SetActive(true);
        //go back set active true;
    }
    public void GraphicsButton()
    {

    }

    public void AudioButton()
    {

    }

    public void GameplayButon() 
    {
        gameplayOptions.SetActive(true);
    }

    //? INSIDE GAMEPLAY OPTIONS
    public void HeadbobOnOff()
    {
        if (isHeadbobOn)
        {
            RHC_Bob.enabled = false;
            isHeadbobOn = false;
        }
        else
        {
            RHC_Bob.enabled = true;
            isHeadbobOn = true;
        }
            
    }
}
