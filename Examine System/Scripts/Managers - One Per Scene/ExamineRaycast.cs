using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EPOOutline;

namespace ExamineSystem
{
    public class ExamineRaycast : MonoBehaviour
    {
        //[Header("PanelFloating")]
        //public GameObject panelFloating;
        //public GameObject panelFloatingChaiBia;
        //public GameObject panelFloatingDiary;

        //[Header("FloatingIcons")]
        //public GameObject floatingIconTuDien;
        //public GameObject floatingIconChaiBia;
        //public GameObject floatingIconDiary;

        public LightLayerChange lightLayerChange;
        public static bool isExamining;
        public InventoryObject inventory;

        [Header("Raycast Features")]
        [SerializeField] private float rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string layerToExclude = null;
        //public GameObject uiHandLookAt;
        [HideInInspector] public ExamineItemController raycastedObj;
        public ExamineItemController crayon;
        public GameObject diary0UI;

        public GameObject giongDocLaThu;
        public bool daLayBatLua;
        public bool daLayBoNhang;

        public GameObject testGiayButton;
        [SerializeField] public GameObject cua;
        [SerializeField] GameObject[] flashLightChildren;


        [Header("Crosshair")]
        [SerializeField] private Image uiCrosshair = null;
        [SerializeField] private Sprite uiCrosshairUnclicked = null;
        [SerializeField] Sprite uiCrosshairClicked = null;
        [HideInInspector] public bool interacting = false;

        private bool isCrosshairActive;

        private const string pickupTag = "Pickup";
        private const string showNameTag = "ShowName";

        [Header("Floating Icons")]
        [SerializeField] string nameFloatingIcons;
        [SerializeField] string namePanelFloatingIcons;
        public GameObject floatingIcon;
        public GameObject panelFloating;
        
        void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int Mask = 1 << LayerMask.NameToLayer(layerToExclude) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, Mask))
            {
                //if (hit.collider.CompareTag(showNameTag))
                //{
                //    Debug.Log(hit.collider.gameObject.name);
                //    if (!interacting)
                //    {
                //        raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                //        raycastedObj.MainHighlight(true);
                //        CrosshairChange(true);
                //    }

                //    isCrosshairActive = true;
                //    interacting = true;

                //    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                //    {
                //        raycastedObj.ExamineObject();
                //    }
                //}

                if (hit.collider.CompareTag(pickupTag))
                {


                    if (!interacting)
                    {
                        raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                        nameFloatingIcons = "FloatingIcon" + raycastedObj.name;
                        namePanelFloatingIcons = "PanelFloating" + raycastedObj.name;
                        floatingIcon = GameObject.Find(nameFloatingIcons);
                        panelFloating = GameObject.Find(namePanelFloatingIcons);
                        if (panelFloating)
                        {
                            panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                            panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        }
                        if (floatingIcon)
                            floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
                        raycastedObj.MainHighlight(true);

                        //var initialMeshRenderer = raycastedObj.GetComponent<MeshRenderer>();
                        CrosshairChange(true);
                    }


                    //floatingIcon = GameObject.Find(nameFloatingIcons);
                    //panelFloating = GameObject.Find("/"+nameFloatingIcons+"/" +namePanelFloatingIcons);
                    //panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                    //panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    //floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);

                    isCrosshairActive = true;
                    interacting = true;
                    //raycastedObj.GetComponent<Outlinable>().enabled = true;
                    //if(raycastedObj.GetComponent<ExamineItemController>().isFlashlight == true)
                    //{
                    //   for(int i =0; i < flashLightChildren.Length; i++)
                    //    {
                    //        flashLightChildren[i].GetComponent<Outlinable>().enabled = true;
                    //    }
                    //}
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (panelFloating)
                            panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                    }

                    if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                    {
                        if (panelFloating)
                            panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                        ////raycastedObj.GetComponent<Outlinable>().enabled = false;
                        //if (raycastedObj.GetComponent<ExamineItemController>().isFlashlight == true)
                        //{
                        //    for (int i = 0; i < flashLightChildren.Length; i++)
                        //    {
                        //        flashLightChildren[i].GetComponent<Outlinable>().enabled = false;
                        //    }
                        //}


                        var item = raycastedObj.GetComponent<GroundItem>();
                        if (item)
                        {
                            isExamining = true;
                            if (raycastedObj.name == "LaBua")
                            {
                                PlayerData.daLayLaBua = true;
                            }
                            inventory.AddItem(new Item(item.item), 1);

                        }
                        lightLayerChange.ChangeLayerExamine(raycastedObj.GetComponent<MeshRenderer>());
                        raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        raycastedObj.ExamineObject();
                        if (panelFloating)
                            panelFloating.SetActive(false);
                        if (floatingIcon)
                            floatingIcon.SetActive(false);
                        if (raycastedObj.isBatLua == true)
                        {
                            daLayBatLua = true;
                        }
                        if (raycastedObj.isBoNhang == true)
                            daLayBoNhang = true;
                    }
                }

                //if (hit.collider.CompareTag("PhieuDiem"))
                //{
                //    if (!interacting)
                //    {
                //        raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                //        raycastedObj.MainHighlight(true);
                //        CrosshairChange(true);
                //    }

                //    isCrosshairActive = true;
                //    interacting = true;

                //    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                //    {
                //        raycastedObj.ExamineObject();
                //        giongDocLaThu.SetActive(true);
                //        StartCoroutine(Waiter());
                //        IEnumerator Waiter()
                //        {
                //            yield return new WaitForSeconds(35f);
                //            cua.tag = "CuaLoadNha";
                //        }
                //    }
                //}

                if (hit.collider.CompareTag("Document"))
                {
                    if (!interacting)
                    {
                        raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                        nameFloatingIcons = "FloatingIcon" + raycastedObj.name;
                        namePanelFloatingIcons = "PanelFloating" + raycastedObj.name;
                        floatingIcon = GameObject.Find(nameFloatingIcons);
                        panelFloating = GameObject.Find(namePanelFloatingIcons);
                        if (panelFloating)
                        {
                            panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                            panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        }
                        if (floatingIcon)
                            floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
                        raycastedObj.MainHighlight(true);
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
                        raycastedObj.ExamineObject();
                        if (panelFloating)
                            panelFloating.SetActive(false);
                        if (floatingIcon)
                            floatingIcon.SetActive(false);
                        isExamining = true;
                        lightLayerChange.ChangeLayerExamine(raycastedObj.GetComponent<MeshRenderer>());
                        raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        if (raycastedObj.name == "GiayTest")
                        {
                            if (testGiayButton)
                                testGiayButton.SetActive(true);
                            PlayerData.document1 = true;
                        }
                    }
                }
                if (hit.collider.CompareTag("PhieuDiem"))
                {
                    if (!interacting)
                    {
                        raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                        nameFloatingIcons = "FloatingIcon" + raycastedObj.name;
                        namePanelFloatingIcons = "PanelFloating" + raycastedObj.name;
                        floatingIcon = GameObject.Find(nameFloatingIcons);
                        panelFloating = GameObject.Find(namePanelFloatingIcons);
                        if (panelFloating)
                        {
                            panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                            panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        }
                        if (floatingIcon)
                            floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
                        raycastedObj.MainHighlight(true);
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
                        isExamining = true;
                        raycastedObj.ExamineObject();
                        if (panelFloating)
                            panelFloating.SetActive(false);
                        if (floatingIcon)
                            floatingIcon.SetActive(false);
                        raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        lightLayerChange.ChangeLayerExamine(raycastedObj.GetComponent<MeshRenderer>());
                        giongDocLaThu.SetActive(true);
                        StartCoroutine(Waiter());
                        IEnumerator Waiter()
                        {
                            yield return new WaitForSeconds(35f);
                            cua.tag = "CuaLoadNha";
                        }
                    }
                }


            }

            else
            {
                if (isCrosshairActive)
                {
                    raycastedObj.MainHighlight(false);
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
                    panelFloating.GetComponent<Animator>().Play("FloatingPanelExit");
                    panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
                }

                if (floatingIcon)
                    floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                uiCrosshair.sprite = uiCrosshairUnclicked;
                isCrosshairActive = false;
                //raycastedObj.GetComponent<Outlinable>().enabled = false;
                //if (raycastedObj.GetComponent<ExamineItemController>().isFlashlight == true)
                //{
                //    for (int i = 0; i < flashLightChildren.Length; i++)
                //    {
                //        flashLightChildren[i].GetComponent<Outlinable>().enabled = false;
                //    }
                //}
            }
        }

        public void CloseButtonExamine()
        {
            raycastedObj.StopInteractingObject();
        }
    }
}
