using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
//using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

namespace ExamineSystem
{
    public class DocumentsListDisappear : MonoBehaviour
    {
        public GameObject bgi;
        public GameObject mainCam;//your other object
        public GameObject documentsList;
        public string examineRay = "ExamineRaycast";// your secound script name
        public string putOnRay = "PutOnRaycast";
        public string doorRay = "BasicDoorRaycast";
        public string zoomInRay;
        public string violinRaycast;
        RectTransform rectTransform;
        public GameObject blurOut;
        [SerializeField] public Image crosshair = null;
        [SerializeField] public FirstPersonController player = null;
        //[SerializeField] public BlurOptimized blur = null;
        public static bool isListAlreadyOn;
        public DisplayInventory displayInventory;
        public InventoryDisappear inventoryDisappear;
        public GameObject violinUi;
        public BoxCollider violinBdCollider;
        public GameObject video;
        public GameObject[] documentsUI;
        [SerializeField] GameObject imageSaving;
        public PauseMenuu pauseMenu;

        [Header("AudioSource")] //dont work with ambient sounds
        
        public AudioSource[] giongNoiChuyen;
        public bool[] alreadyPlayed; //update length throughout coding process
                                     // Update is called once per frame
        public GameObject subPlayer;
        public GameObject subCam; 
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
                if (!DisplayInventory.isFixing && isListAlreadyOn == false && video.activeInHierarchy == false && InventoryDisappear.isInventoryAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && PauseMenuu.isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        TurnOnList();
                    }

                }
                else if (isListAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        TurnOffList();
                        if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                        {
                            crosshair.enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }
                    }

                }
            }

            if (!video)
            {
                if (!DisplayInventory.isFixing && isListAlreadyOn == false && InventoryDisappear.isInventoryAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && PauseMenuu.isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        TurnOnList();
                    }

                }
                else if (isListAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        TurnOffList();
                        if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                        {
                            crosshair.enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }
                    }

                }
            }



        }
        public void TurnOnList()
        {
            //Debug.Log("haha");
            documentsList.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //blur.enabled = true;
            bgi.SetActive(true);
            crosshair.enabled = false;
            player.enabled = false;
            Time.timeScale = 0f;
            for (int i = 0; i < giongNoiChuyen.Length; i++)
            {
                if (giongNoiChuyen[i].isPlaying)
                {
                    alreadyPlayed[i] = true;
                }
                giongNoiChuyen[i].Pause();
            }
            blurOut.SetActive(true);
            if (zoomInRay != "")
            {
                (mainCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
            }
            if (violinRaycast != "")
            {
                (mainCam.GetComponent(violinRaycast) as MonoBehaviour).enabled = false;
            }
            mainCam.GetComponent<ExamineSystem.ExamineRaycast>().enabled = false;
            (mainCam.GetComponent(putOnRay) as MonoBehaviour).enabled = false;
            (mainCam.GetComponent(doorRay) as MonoBehaviour).enabled = false;
            isListAlreadyOn = true;
        }

        public void TurnOffList()
        {
            if (!PlayerData.moTuDien && !PlayerData.nhinDiary)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                documentsList.SetActive(false);
                for (int i = 0; i < documentsUI.Length; i++)
                {
                    documentsUI[i].SetActive(false);
                }
                //blur.enabled = false;
                bgi.SetActive(false);
                crosshair.enabled = true;
                player.enabled = true;
                Time.timeScale = 1f;
                for (int i = 0; i < giongNoiChuyen.Length; i++)
                {
                    if (alreadyPlayed[i] == true)
                        giongNoiChuyen[i].Play();
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
                (mainCam.GetComponent(doorRay) as MonoBehaviour).enabled = true;
                isListAlreadyOn = false;
            }
            else if (PlayerData.moTuDien || PlayerData.nhinDiary)
            {
                documentsList.SetActive(false);
                
                Time.timeScale = 1f;
                //blur.enabled = false;
                bgi.SetActive(false);
                blurOut.SetActive(false);
                for (int i = 0; i < giongNoiChuyen.Length; i++)
                {
                    if (alreadyPlayed[i] == true)
                        giongNoiChuyen[i].Play();
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
                (mainCam.GetComponent(doorRay) as MonoBehaviour).enabled = true;
                isListAlreadyOn = false;
            }
            //Debug.Log("hoho");
           
        }
    }

}

