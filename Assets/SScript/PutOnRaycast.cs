using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExamineSystem;
using TMPro;

public class PutOnRaycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string layerToExclude = null;
    public string zoomInRay;
    [SerializeField] public bool isInteracting = false;
    public DisplayInventory displayInventory;
    public PutOn raycasted_obj;
    [Header("Key Codes")]
   // [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("Crosshair")]
    [SerializeField] private Image uiCrosshair = null;
    [SerializeField] Sprite uiCrosshairUnclicked;
    [SerializeField] Sprite uiCrosshairClicked;
    [HideInInspector] public bool interacting = false;
    public bool isCrosshairActive;
    private bool doOnce;
    const string showNameTag = "ShowName";
    public InventoryDisappear inventoryDisappear;
    [SerializeField] RectTransform rectTransform;
    public AudioSource alarmSound;
    public GameObject objectName;
    [SerializeField] Animator animatorText;

    [Header("Floating Icons")]
    [SerializeField] string nameFloatingIcons;
    [SerializeField] string namePanelFloatingIcons;
    public GameObject floatingIcon;
    public GameObject panelFloating;

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
                //Debug.Log(hit.collider.gameObject.name);
                objectName.GetComponent<TextMeshProUGUI>().text = hit.collider.gameObject.name;
                animatorText.enabled = false;
                objectName.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
                objectName.SetActive(true);
                if (!interacting)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<PutOn>();
                    //raycasted_obj.MainHighlight(true);
                    //objectName.GetComponent<Text>().text =  
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
                        floatingIcon.GetComponent<Animator>().Play("ExpandFloating");
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
                    //if (panelFloating)
                    //    panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    if (InventoryDisappear.isInventoryAlreadyOn == false)
                    {
                        inventoryDisappear.TurnOnInventory();
                        if (raycasted_obj.gameObject.name == "Violin Stand")
                        {
                            PlayerData.nhinViolinStand = true;
                        }
                        if (raycasted_obj.name == "Incense Sticks")
                            PlayerData.nhinBoNhang = true;
                        //objectName.SetActive(false);
                        //interacting = false;
                    }
                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);

                }
            }
            if (hit.collider.CompareTag("AlarmClock"))
            {
                if (!interacting)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<PutOn>();
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

            if (hit.collider.CompareTag("PutOnSmall"))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //objectName.GetComponent<TextMeshProUGUI>().text = hit.collider.gameObject.name;
                //animatorText.enabled = false;
                //objectName.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
                //objectName.SetActive(true);
                if (!interacting)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<PutOn>();
                    raycasted_obj.GetComponent<EPOOutline.Outlinable>().enabled = true;
                    ////raycasted_obj.MainHighlight(true);
                    ////objectName.GetComponent<Text>().text =  
                    //nameFloatingIcons = "FloatingIcon" + raycasted_obj.name;
                    //namePanelFloatingIcons = "PanelFloating" + raycasted_obj.name;
                    //floatingIcon = GameObject.Find(nameFloatingIcons);
                    //panelFloating = GameObject.Find(namePanelFloatingIcons);
                    //if (panelFloating)
                    //{
                    //    //panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                    //    panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    //}
                    //if (floatingIcon)
                    //   float
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                interacting = true;

                //if (Input.GetKeyDown(KeyCode.Mouse0))
                //{
                //    if (panelFloating)
                //        panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                //}

                if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                {
                    //if (panelFloating)
                    //    panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    if (InventoryDisappear.isInventoryAlreadyOn == false)
                    {
                        inventoryDisappear.TurnOnInventory();
                       
                        if(raycasted_obj.gameObject.name == "Violin Stand")
                        {
                            PlayerData.nhinViolinStand = true;
                        }
                        if(raycasted_obj.name == "Incense Sticks")
                            PlayerData.nhinBoNhang = true;

                        if (raycasted_obj.gameObject.name == "BeerCap")
                            PlayerData.nhinChaiBia = true;
                        //objectName.SetActive(false);
                        //interacting = false;
                    }
                    //if (panelFloating)
                    //    panelFloating.SetActive(false);
                    //if (floatingIcon)
                    //    floatingIcon.SetActive(false);

                }
            }
            if (hit.collider.CompareTag("PutOn"))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //objectName.GetComponent<TextMeshProUGUI>().text = hit.collider.gameObject.name;
                //animatorText.enabled = false;
                //objectName.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
                //objectName.SetActive(true);
                if (!interacting)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<PutOn>();
                    raycasted_obj.GetComponent<EPOOutline.Outlinable>().enabled = true;
                    //raycasted_obj.MainHighlight(true);
                    //objectName.GetComponent<Text>().text =  
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
                        floatingIcon.GetComponent<Animator>().Play("ExpandFloating");
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
                    //if (panelFloating)
                    //    panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    if (InventoryDisappear.isInventoryAlreadyOn == false)
                    {
                        inventoryDisappear.TurnOnInventory();

                        if (raycasted_obj.gameObject.name == "Violin Stand")
                        {
                            PlayerData.nhinViolinStand = true;
                        }
                        if (raycasted_obj.name == "Incense Sticks")
                            PlayerData.nhinBoNhang = true;

                        if (raycasted_obj.gameObject.name == "BeerCap")
                            PlayerData.nhinChaiBia = true;
                        //objectName.SetActive(false);
                        //interacting = false;
                    }
                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);

                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                //raycasted_obj.MainHighlight(false);
                CrosshairChange(false);

                animatorText.enabled = true;
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

            if(raycasted_obj != null && raycasted_obj.GetComponent<EPOOutline.Outlinable>())
            raycasted_obj.GetComponent<EPOOutline.Outlinable>().enabled = false;

            if (floatingIcon)
                floatingIcon.GetComponent<Animator>().Play("ExpandFloatingReverse");
            uiCrosshair.sprite = uiCrosshairUnclicked;
            isCrosshairActive = false;
        }
    }

}

