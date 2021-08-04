using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExamineSystem;
using UnityStandardAssets.Characters.FirstPerson;



public class ZoomInTriggerRaycast: MonoBehaviour
{
    [Header("PanelFloating")]
    public GameObject panelFloating;
    public GameObject panelFloatingChaiBia;
    public GameObject panelFloatingDiary;

    [Header("FloatingIcons")]
    public GameObject floatingIconTuDien;
    public GameObject floatingIconChaiBia;
    public GameObject floatingIconDiary;

    [Header("Raycast Parameters")]
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;
    public GameObject fpsController;
    public GameObject buttonOnObject;
    public GameObject bgz;
    //public GameObject fpsCam;
    public string zoomInRay;
    [SerializeField] public bool isInteracting = false;
    //public GameObject uiHandLookAt;
    //public GameObject tudien;
    public DisplayInventory displayInventory;
    public GameObject zoomInTuDienCamera;
    public GameObject zoomInChaiBiaCamera;
    public GameObject zoomInDiaryCamera;
    public GameObject tuDienLight;
    public GameObject noiDay;
    public bool laTuDien;
    public bool laChaiBia;
    public bool laDiary;
    public ZoomInController raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("UI Parameters")]
    [SerializeField] public Image crosshair = null;
    [SerializeField] public Sprite crosshairUnclicked;
    [SerializeField] Sprite crosshairClicked;
    public bool isCrosshairActive;
    [SerializeField] public bool doOnce;
    public GameObject invisibleObject; //fortudien
    public GameObject invisibleObject1; //forchaibia
    public GameObject invisibleObject2; //forDiary
    public bool buffing = false;
    public SimplyABool boolean;

    [Header("Smooth Transition")]
    public FirstPersonController player;
    [SerializeField] PlayerStats playerStats;
    public bool doOnceTwo;
    public float startRotationPlayer;
    public float endRotationPlayer;
    public float startRotationCamera;
    public float endRotationCamera;

    [SerializeField] public  float duration;
    public float startTime; 
    public float startX;
    public float startY;
    public float startZ;
    public float[] targetPosition;
    float mouseX;
    float mouseY;

    private const string interactableTag = "ZoomInObject";
    private void Awake()
    {
        noiDay.SetActive(false);
        //zoomInTuDienCamera.SetActive(false);
        //zoomInChaiBiaCamera.SetActive(false);
        //tuDienLight.SetActive(false);
    }
    private void Update()
    {

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (laTuDien)
                {
                    if (!doOnce)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<ZoomInController>();
                       
                        panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        floatingIconTuDien.GetComponent<Animator>().Play("ExpandFloating");
                        
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;
                    if (!isInteracting && !raycasted_obj.doOnceThree )
                    {
                        if (Input.GetKeyDown(openDoorKey))
                        {

                            panelFloating.GetComponent<Animator>().Play("FloatingPanel");

                        }
                        if (Input.GetKeyUp(openDoorKey))
                        {
                            floatingIconTuDien.SetActive(false);

                            player.enabled = false;
                            //raycasted_obj.gameObject.layer = 0;
                            // //raycasted_obj.GetComponent<BoxCollider>().enabled = false;
                            startRotationPlayer = player.gameObject.transform.eulerAngles.y;
                            startRotationCamera = gameObject.transform.eulerAngles.x;
                            startTime = Time.time;
                            //mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
                            //mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
                            startX = player.transform.position.x;
                            startY = player.transform.position.y;
                            startZ = player.transform.position.z;
                            noiDay.SetActive(true);
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            crosshair.enabled = false;
                            //this.enabled = false;
                            PlayerData.moTuDien = true;
                            doOnceTwo = true;
                            enabled = false;

                        }
                    }

                    
                }
                //if (laChaiBia == true)
                //{

                //    if (!doOnce)
                //    {
                //        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                //        panelFloatingChaiBia.GetComponent<Animator>().Play("FloatingPanelEnter");
                //        panelFloatingChaiBia.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                //        floatingIconChaiBia.GetComponent<Animator>().Play("ExpandFloating");
                //        CrosshairChange(true);
                //    }

                //    isCrosshairActive = true;
                //    doOnce = true;
                //    if (!isInteracting)
                //    {
                //        if (Input.GetKeyDown(openDoorKey))
                //        {

                //            panelFloatingChaiBia.GetComponent<Animator>().Play("FloatingPanel");

                //        }
                //        if (Input.GetKeyUp(openDoorKey))
                //        {
                //            panelFloatingChaiBia.GetComponent<Animator>().Play("FloatingPanelReverse");
                //            if (boolean.waitForAnimationEnd == false)
                //            {

                //                bgz.SetActive(true);
                //                zoomInChaiBiaCamera.SetActive(true);
                //                buffing = true;
                //                StartCoroutine(waiter());


                //                IEnumerator waiter()
                //                {
                //                    yield return new WaitForSeconds(0.5f);
                //                    //SceneManager.LoadScene("testObject");
                //                    Cursor.lockState = CursorLockMode.None;
                //                    Cursor.visible = true;
                //                    crosshair.enabled = false;
                //                    //(fpsCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
                //                    floatingIconChaiBia.SetActive(false);
                //                    fpsController.SetActive(false);
                //                    isInteracting = true;
                //                    if (invisibleObject1)
                //                        invisibleObject1.SetActive(false);
                //                    buttonOnObject.SetActive(true);
                //                    PlayerData.nhinChaiBia = true;
                //                    Debug.Log("addudududu");
                //                    //yield return StartCoroutine(waiter1());
                //                    //IEnumerator waiter1()
                //                    //{
                //                    //yield return new WaitForSeconds(0.5f);
                //                    buffing = false;
                //                    //}
                //                }
                //            }

                //        }
                //    }
                //}

                if (laDiary)
                {
                    if (!doOnce)
                    {
                       // raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        panelFloatingDiary.GetComponent<Animator>().Play("FloatingPanelEnter");
                        panelFloatingDiary.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                        floatingIconDiary.GetComponent<Animator>().Play("ExpandFloating");
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;
                    if (!isInteracting)
                    {
                        if (Input.GetKeyDown(openDoorKey))
                        {

                            panelFloatingDiary.GetComponent<Animator>().Play("FloatingPanel");

                        }

                        if (Input.GetKeyUp(openDoorKey))
                        {
                            panelFloatingDiary.GetComponent<Animator>().Play("FloatingPanelReverse");
                            if (boolean.waitForAnimationEnd == false)
                            {
                                bgz.SetActive(true);
                                zoomInDiaryCamera.SetActive(true);
                                buffing = true;
                                StartCoroutine(waiter());


                                IEnumerator waiter()
                                {
                                    yield return new WaitForSeconds(0.5f);
                                    //SceneManager.LoadScene("testObject");
                                    Cursor.lockState = CursorLockMode.None;
                                    Cursor.visible = true;
                                    crosshair.enabled = false;
                                    floatingIconDiary.SetActive(false);
                                    //(fpsCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
                                    fpsController.SetActive(false);
                                    isInteracting = true;
                                    if (invisibleObject2)
                                        invisibleObject2.SetActive(false);
                                    //buttonOnObject.SetActive(true);
                                    PlayerData.nhinDiary = true;
                                    Debug.Log("addudududu");
                                    //yield return StartCoroutine(waiter1());
                                    //IEnumerator waiter1()
                                    //{
                                    //yield return new WaitForSeconds(0.5f);
                                    buffing = false;
                                    //}
                                }
                            }

                        }
                    }
                }



            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
        if (doOnceTwo)
        {
            
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            //crosshair.color = Color.grey;
            crosshair.sprite = crosshairClicked;
            //uiHandLookAt.SetActive(true);
        }
        else
        {
            //uiHandLookAt.SetActive(false);
            if (laTuDien == true && floatingIconTuDien)
            {
                //panelFloating.GetComponent<Animator>().Play("FloatingPanelExit");
                //panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
                floatingIconTuDien.GetComponent<Animator>().Play("ExpandFloatingReverse");
            }

            if (laChaiBia)
            {
                //panelFloatingChaiBia.GetComponent<Animator>().Play("FloatingPanelExit");
                //panelFloatingChaiBia.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
                floatingIconChaiBia.GetComponent<Animator>().Play("ExpandFloatingReverse");
            }

            if (laDiary)
            {
                //panelFloatingDiary.GetComponent<Animator>().Play("FloatingPanelExit");
                //panelFloatingDiary.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
                floatingIconDiary.GetComponent<Animator>().Play("ExpandFloatingReverse");
            }
            crosshair.sprite = crosshairUnclicked;
            isCrosshairActive = false;
        }
    }
}