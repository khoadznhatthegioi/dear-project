using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExamineSystem
{
    public class ViolinBieuDienRaycast : MonoBehaviour
    {
        [Header("Raycast Features")]
        [SerializeField] private float rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string layerToExclude = null;
        public string zoomInRay;
        [SerializeField] public bool isInteracting = false;
        public GameObject violinUi; // bao gom ca button
        public static bool isSolvingPasssword;
        public DisplayInventory displayInventory;
        private BasicDoorController raycasted_obj;
        [Header("Key Codes")]
        //[SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        [Header("Crosshair")]
        [SerializeField] private Image uiCrosshair = null;
        [SerializeField] Sprite uiCrosshairUnclicked = null;
        [SerializeField] Sprite uiCrosshairClicked;
        [HideInInspector] public bool interacting = false;
        private bool isCrosshairActive;
        private bool doOnce;
        private const string violinTag = "Violin";
        public InventoryDisappear inventoryDisappear;
        [SerializeField] RectTransform rectTransform;
        [Header("Floating Icons")]
        [SerializeField] string nameFloatingIcons;
        [SerializeField] string namePanelFloatingIcons;
        public GameObject floatingIcon;
        public GameObject panelFloating;

        // Start is called before the first frame update
        void Awake()
        {
            violinUi.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int Mask = 1 << LayerMask.NameToLayer(layerToExclude) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, Mask))
            {
                if (hit.collider.CompareTag(violinTag))
                {
                    if (!interacting)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        //raycasted_obj.MainHighlight(true);
                        nameFloatingIcons = "FloatingIcon" + raycasted_obj.name;
                        namePanelFloatingIcons = "PanelFloating" + raycasted_obj.name;
                        floatingIcon = GameObject.Find(nameFloatingIcons);
                        panelFloating = GameObject.Find(namePanelFloatingIcons);
                        if (panelFloating)
                        {
                            //panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                            panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        }
                        if (floatingIcon)
                            floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (panelFloating)
                            panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                    }

                    if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                    {
                        if (panelFloating)
                            panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        isSolvingPasssword = true;
                        inventoryDisappear.crosshair.enabled = false;
                        inventoryDisappear.player.enabled = false;
                        if (panelFloating)
                            panelFloating.SetActive(false);
                        if (floatingIcon)
                            floatingIcon.SetActive(false);
                        Time.timeScale = 0;
                        violinUi.SetActive(true);
                        inventoryDisappear.bgi.SetActive(true);
                        inventoryDisappear.blurOut.SetActive(true);
                        (inventoryDisappear.mainCam.GetComponent(inventoryDisappear.examineRay) as MonoBehaviour).enabled = false;
                        violinUi.SetActive(true);
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
                uiCrosshair.sprite = uiCrosshairClicked;
                //uiHandLookAt.SetActive(true);
            }
            else
            {
                //uiHandLookAt.SetActive(false);
                if (panelFloating)
                {
                    //panelFloating.GetComponent<Animator>().Play("FloatingPanelExit");
                    panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
                }

                if (floatingIcon)
                    floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                uiCrosshair.sprite = uiCrosshairUnclicked;
                isCrosshairActive = false;
            }
        }
    }
}
