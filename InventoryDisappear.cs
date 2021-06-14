using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

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
        [SerializeField] public BlurOptimized blur = null;
        public bool isInventoryAlreadyOn;
        public DisplayInventory displayInventory;
        public GameObject violinUi;
        public BoxCollider violinBdCollider;
        public GameObject video;
        public DocumentsListDisappear documentsList;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        // Update is called once per frame
        void Update()
        {
            if (video)
            {
                if (isInventoryAlreadyOn == false && video.activeInHierarchy == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Debug.Log("haha");
                        var position = rectTransform.position;
                        position.x = 0;
                        rectTransform.position = position;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        blur.enabled = true;
                        bgi.SetActive(true);
                        crosshair.enabled = false;
                        player.enabled = false;
                        Time.timeScale = 0f;
                        blurOut.SetActive(true);
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = false;
                        isInventoryAlreadyOn = true;
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Debug.Log("hoho");
                        var position = rectTransform.position;
                        position.x = 6666;
                        rectTransform.position = position;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        blur.enabled = false;
                        bgi.SetActive(false);
                        crosshair.enabled = true;
                        player.enabled = true;
                        Time.timeScale = 1f;
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
                if (isInventoryAlreadyOn == false && documentsList.isListAlreadyOn == false && CheckBool.isBuffering == false)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Debug.Log("haha");
                        var position = rectTransform.position;
                        position.x = 0;
                        rectTransform.position = position;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        blur.enabled = true;
                        bgi.SetActive(true);
                        crosshair.enabled = false;
                        player.enabled = false;
                        Time.timeScale = 0f;
                        blurOut.SetActive(true);
                        (mainCam.GetComponent(examineRay) as MonoBehaviour).enabled = false;
                        isInventoryAlreadyOn = true;
                    }

                }
                else if (isInventoryAlreadyOn == true)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Debug.Log("hoho");
                        var position = rectTransform.position;
                        position.x = 6666;
                        rectTransform.position = position;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        blur.enabled = false;
                        bgi.SetActive(false);
                        crosshair.enabled = true;
                        player.enabled = true;
                        Time.timeScale = 1f;
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
