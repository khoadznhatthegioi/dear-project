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
        public string examineRay;// your secound script name
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

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        // Update is called once per frame
        void Update()
        {
            if (video)
            {
                if (isInventoryAlreadyOn == false && video.activeInHierarchy == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
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
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = false;
                        isInventoryAlreadyOn = true;
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
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
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = true;
                        isInventoryAlreadyOn = false;
                        PlayerData.nhinViolinStand = false;
                        PlayerData.nhinBoNhang = false;
                    }

                }
            }

            if (!video)
            {
                if (isInventoryAlreadyOn == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false && imageSaving.activeInHierarchy == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                       // Debug.Log("haha");
                        var position = rectTransform.position;
                        position.x = 0;
                        rectTransform.position = position;
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
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = false;
                        isInventoryAlreadyOn = true;
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
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
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = true;
                        isInventoryAlreadyOn = false;
                        PlayerData.nhinViolinStand = false;
                        PlayerData.nhinBoNhang = false;
                    }

                }
            }
        }
       
    }
}
