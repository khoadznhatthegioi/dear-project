using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExamineSystem;

    public class PutOnRaycast : MonoBehaviour
    {
        [Header("Raycast Features")]
        [SerializeField] private float rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string layerToExclude = null;
        public string zoomInRay;
        [SerializeField] public bool isInteracting = false;
        public DisplayInventory displayInventory;
        private BasicDoorController raycasted_obj;
        [Header("Key Codes")]
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        [Header("Crosshair")]
        [SerializeField] private Image uiCrosshair = null;
        [HideInInspector] public bool interacting = false;
        private bool isCrosshairActive;
        private bool doOnce;
        private const string showNameTag = "ShowName";
        public InventoryDisappear inventoryDisappear;
        [SerializeField] RectTransform rectTransform;
        public AudioSource alarmSound;

        // Start is called before the first frame update
        void Start()
        {
 
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int Mask = 1 << LayerMask.NameToLayer(layerToExclude) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, Mask))
            {
                if (hit.collider.CompareTag(showNameTag))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (!interacting)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        //raycasted_obj.MainHighlight(true);
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                    {
                        if (inventoryDisappear.isInventoryAlreadyOn == false)
                        {
                            Debug.Log("haha");
                            var position = rectTransform.position;
                            position.x = 0;
                            rectTransform.position = position;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            inventoryDisappear.blur.enabled = true;
                            inventoryDisappear.bgi.SetActive(true);
                            inventoryDisappear.crosshair.enabled = false;
                            inventoryDisappear.player.enabled = false;
                            Time.timeScale = 0f;
                            inventoryDisappear.blurOut.SetActive(true);
                            (inventoryDisappear.mainCam.GetComponent(inventoryDisappear.examineRay) as MonoBehaviour).enabled = false;
                            inventoryDisappear.isInventoryAlreadyOn = true;
                            PlayerData.nhinViolinStand = true;
                       PlayerData.nhinBoNhang = true;
                        }

                    }
                }
                if (hit.collider.CompareTag("AlarmClock"))
                {
                    if (!interacting)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        //raycasted_obj.MainHighlight(true);
                        CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                    {

                    PlayerStats.isAlarmTurnedOff = true;

                    }
                }
            }

            else
            {
                if (isCrosshairActive)
                {
                    //raycasted_obj.MainHighlight(false);
                    CrosshairChange(false);
                    interacting = false;
                }
            }
        }
        void CrosshairChange(bool on)
        {
            if (on && !interacting)
            {
                uiCrosshair.color = Color.red;
                //uiHandLookAt.SetActive(true);
            }
            else
            {
                //uiHandLookAt.SetActive(false);
                uiCrosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }

