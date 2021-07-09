using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
//using UnityStandardAssets.ImageEffects;

namespace ExamineSystem
{
    public class InventoryDisappear : MonoBehaviour
    {
        public GameObject bgi;
        public GameObject mainCam;//your other object
        public string examineRay = "ExamineRaycast";// your secound script name
        public string putOnRay = "PutOnRaycast";
        public string doorRay = "BasicDoorRaycast";
        public string zoomInRay;
        public RectTransform rectTransform;
        public GameObject blurOut;
        [SerializeField] public Image crosshair = null;
        [SerializeField] public FirstPersonController player = null;
//[SerializeField] public BlurOptimized blur = null;
        public bool isInventoryAlreadyOn;
        public DisplayInventory displayInventory;
        public GameObject violinUi;
        public BoxCollider violinBdCollider;
        public GameObject video;
        public DocumentsListDisappear documentsList;
        [SerializeField] GameObject imageSaving;
        public PauseMenuu pauseMenu;
        public GameObject subPlayer;
        public GameObject subCam;
        public string violinRaycast;
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        // Update is called once per frame
        void Update()
        {

            subPlayer = GameObject.Find("FPSController_Prefab (2)");
            subCam = GameObject.Find("/FPSController_Prefab (2)/MainCamera");
            if (player.gameObject.activeInHierarchy == false)
            {
                if (subPlayer)
                {
                    player = subPlayer.GetComponent<FirstPersonController>();
                    mainCam = subCam;
                }
            }
            if (video)
            {
                if (isInventoryAlreadyOn == false && video.activeInHierarchy == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && pauseMenu.isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        TurnOnInventory();
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        TurnOffInventory();

                        if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                        {
                            crosshair.enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }

                        if((mainCam.GetComponent(putOnRay) as PutOnRaycast).raycasted_obj != null)
                        {
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).panelFloating.SetActive(true);
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).panelFloating.GetComponent<Image>().color = new Color32(255, 255, 255, 26);
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).floatingIcon.SetActive(true);
                        }
                        ClickingOnObjectTest.i = false;
                    }

                }
            }

            if (!video)
            {
                if (isInventoryAlreadyOn == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false && pauseMenu.isPauseMenuAlreadyOn == false && !ViolinBieuDienRaycast.isSolvingPasssword)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        TurnOnInventory();
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        TurnOffInventory();

                        if (PlayerData.nhinChaiBia || PlayerData.moTuDien || PlayerData.nhinDiary)
                        {
                            crosshair.enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }
                        if ((mainCam.GetComponent(putOnRay) as PutOnRaycast).raycasted_obj != null)
                        {
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).panelFloating.SetActive(true);
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).panelFloating.GetComponent<Image>().color = new Color32(255,255,255,26);
                            (mainCam.GetComponent(putOnRay) as PutOnRaycast).floatingIcon.SetActive(true);
                        }
                        ClickingOnObjectTest.i = false;
                    }

                }
            }
        }

        public void TurnOnInventory()
        {
            //Debug.Log("haha");
            var position = rectTransform.position;
            position.x = 0;
            rectTransform.position = position;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // blur.enabled = true;
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
            if(zoomInRay != "")
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
            isInventoryAlreadyOn = true;
        }

        public void TurnOffInventory()
        {
            //Debug.Log("hoho");
            var position = rectTransform.position;
            position.x = 6666;
            rectTransform.position = position;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
            (mainCam.GetComponent(doorRay) as MonoBehaviour).enabled = true;
            isInventoryAlreadyOn = false;
            PlayerData.nhinViolinStand = false;
            PlayerData.nhinBoNhang = false;
        }
       
    }
}
