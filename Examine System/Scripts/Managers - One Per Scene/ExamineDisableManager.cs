using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

namespace ExamineSystem
{
    public class ExamineDisableManager : MonoBehaviour
    {
        public static ExamineDisableManager instance;

        [SerializeField] private Image crosshair = null;
        [SerializeField] private FirstPersonController player = null;
        [SerializeField] private ExamineRaycast raycastManager = null;
        [SerializeField] private BlurOptimized blur = null;
        //public GameObject pickUpHand;
        public GameObject examineVolume;
        public GameObject inventoryIsOn;
        public GameObject iScr;//your other object
        public string inventoryOnScr;// your secound script name
        public DocumentsListDisappear documentsListDisappear;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void DisablePlayer(bool disable)
        {
            if (disable)
            {
                raycastManager.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                blur.enabled = true;
                crosshair.enabled = false;
                player.enabled = false;
                //pickUpHand.SetActive(false);
                examineVolume.SetActive(true);
                (iScr.GetComponent(inventoryOnScr) as MonoBehaviour).enabled = false;
                documentsListDisappear.enabled = false;
            }

            else 
            {
                raycastManager.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                blur.enabled = false;
                crosshair.enabled = true;
                player.enabled = true;
                examineVolume.SetActive(false);
                (iScr.GetComponent(inventoryOnScr) as MonoBehaviour).enabled = true;
                documentsListDisappear.enabled = true;
            }
        }
    }
}
