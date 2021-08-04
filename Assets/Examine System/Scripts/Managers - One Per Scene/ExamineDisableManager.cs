using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
//using UnityStandardAssets.ImageEffects;

namespace ExamineSystem
{
    public class ExamineDisableManager : MonoBehaviour
    {
        [SerializeField] LightLayerChange lightLayerChange;
        public static ExamineDisableManager instance;

        [SerializeField] private Image crosshair = null;
        [SerializeField] private FirstPersonController player = null;
        [SerializeField] private ExamineRaycast raycastManager = null;
        //[SerializeField] private BlurOptimized blur = null;
        //public GameObject pickUpHand;
        public GameObject examineVolume;
        public GameObject inventoryIsOn;
        public GameObject iScr;//your other object
        public string inventoryOnScr;// your secound script name
        [SerializeField] GameObject flashlightOnHand;
        [SerializeField] GameObject flashlightLight;
        [SerializeField] GameObject lightExamine;
        bool isflashlightTurnedOn;
        public DocumentsListDisappear documentsListDisappear;
        public PauseMenuu pauseMenu;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void DisablePlayer(bool disable)
        {
            if (disable)
            {
                //if(flashlightLight.activeInHierarchy == true)
                //{
                //    isflashlightTurnedOn = true;
                //}
                if (lightExamine)
                    lightExamine.SetActive(true);
                raycastManager.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //blur.enabled = true;
                crosshair.enabled = false;
                player.enabled = false;
                //pickUpHand.SetActive(false);
                examineVolume.SetActive(true);
                (iScr.GetComponent(inventoryOnScr) as MonoBehaviour).enabled = false;
                documentsListDisappear.enabled = false;
                pauseMenu.enabled = false;
                //if(flashlightOnHand)
                //    flashlightOnHand.SetActive(false);
            }

            else 
            {
                raycastManager.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //blur.enabled = false;
                crosshair.enabled = true;
                player.enabled = true;
                examineVolume.SetActive(false);
                (iScr.GetComponent(inventoryOnScr) as MonoBehaviour).enabled = true;
                documentsListDisappear.enabled = true;
                pauseMenu.enabled = true;
                if (lightExamine)
                {
                    lightExamine.SetActive(false);
                }
                if(lightLayerChange.isDark)
                    raycastManager.raycastedObj.GetComponent<MeshRenderer>().renderingLayerMask = 259;
                if (raycastManager.raycastedObj)
                {
                    raycastManager.raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
                ExamineRaycast.isExamining = false;
                //GiayTestRaycast.isExamining = false;
                //if (flashlightOnHand)
                //    flashlightOnHand.SetActive(true);
                //if (flashlightLight && isflashlightTurnedOn == true)
                //{
                //    flashlightLight.SetActive(true);
                //    isflashlightTurnedOn = false;
                //}
                if(raycastManager.raycastedObj.tag == "Document")
                {
                    raycastManager.panelFloating.SetActive(true);
                    raycastManager.floatingIcon.SetActive(true);
                }
            }
        }
    }
}
