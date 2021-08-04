using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;
using UnityStandardAssets.CrossPlatformInput;

public class BasicDoorRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    //[SerializeField] GiayTestRaycast giayTestRaycast;
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;
    [SerializeField] GameObject nha;
    [SerializeField] public FirstPersonController player;
    [SerializeField] GameObject ban;
    //[SerializeField] GameObject chan;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject cua;
    [SerializeField] TriggerCua triggerCua;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject playerObject1;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera examineCamera;
    public bool isLoaded2;
    public bool isLoaded;
    public GameObject nhungThuBenKia;
    public static bool sceneLoaded1;
    public static bool sceneLoaded2;
    [Header("Floating Icons")]
    [SerializeField] string nameFloatingIcons;
    [SerializeField] string namePanelFloatingIcons;
    public GameObject floatingIcon;
    public GameObject panelFloating;
    bool contactedDoor;
    public bool openedDoor;
    float y;

    [SerializeField] PlayerStats playerStats;
    //public GameObject uiHandLookAt;

    [SerializeField] private BasicDoorController raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("UI Parameters")]
    [SerializeField] private Image crosshair = null;
    [SerializeField] public Sprite crosshairUnclicked;
    [SerializeField] private Sprite crosshairClicked;
    private bool isCrosshairActive;
    public bool doOnce;

    //MOVE MVOE MOVEMSADHKLSADKLSJAKLDJSAKLJDLKSAJDKLASJDKLSJDKSJDLKJD
    [Header("Smooth Transition")]
    public bool doOnceTwo;
    float startRotationPlayer;
    [SerializeField] float endRotationPlayer;
    float startRotationCamera;
    [SerializeField] float endRotationCamera;

    [SerializeField] float duration;
    float startTime; 
    float startX;
    float startY;
    float startZ;
    public float[] targetPosition;
    float mouseX;
    float mouseY;
    //KASKLDJLASJDKLSAJDLKASJDKLJASKLDJSKLDJSKALJDKLSJDKLSJDKLSJDKALSJDK

    private const string interactableTag = "InteractiveObject";
    const string cuaLoadZoo = "CuaLoadZoo";

    //private void Start()
    //{
        
    //}
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                    nameFloatingIcons = "FloatingIcon" + raycasted_obj.name;
                    namePanelFloatingIcons = "PanelFloating" + raycasted_obj.name;
                    floatingIcon = GameObject.Find(nameFloatingIcons);
                    panelFloating = GameObject.Find(namePanelFloatingIcons);
                    if (panelFloating)
                    {
                       // panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                        panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    }
                    if (floatingIcon)
                        floatingIcon.GetComponent<Animator>().Play("ExpandFloating");
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                }

                if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    raycasted_obj.PlayAnimation();
                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);
                }
            }

            if (hit.collider.CompareTag(cuaLoadZoo))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
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
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                }

                if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    raycasted_obj.PlayAnimation();
                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);
                    if (!isLoaded)
                    {
                        raycasted_obj.tag = "Untagged";
                        raycasted_obj.PlayAnimation();
                        LoadZooScene();
                        //player.enabled = false;
                        StartCoroutine(waiter());

                        IEnumerator waiter()
                        {
                            yield return new WaitForSeconds(1f);
                            isLoaded = true;
                            nha.SetActive(false);
                            cua.SetActive(false);
                            sceneLoaded1 = true;
                            PlayerData.sixthSaved = true;
                        }
                    }

                }
            }

            if (hit.collider.CompareTag("CuaSauKhiBiRuot"))
            {
                if (triggerCua.isInFrontOfDoor)
                {
                    if (!doOnce)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        ban.SetActive(true);
                        //chan.SetActive(true);
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        if (!isLoaded)
                        {


                        }

                    }
                }

            }

            if (hit.collider.CompareTag("CuaLoadNha"))
            {
                if (triggerCua.isInFrontOfDoor)
                {
                    if (!doOnce)
                    {
                        raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        if (!isLoaded2)
                        {
                            //Debug.Log("CUALOADNHA");
                            raycasted_obj.tag = "Untagged";
                            player.enabled = false;
                            panel.SetActive(true);

                            StartCoroutine(Waiter1());


                            //chan.SetActive(false);
                            isLoaded2 = true;

                            

                            IEnumerator Waiter1()
                            {
                                yield return new WaitForSeconds(0.5f);
                                //playerObject.transform.position = new Vector3(0.7f, 0.88f, 6f);
                                //playerObject.transform.eulerAngles = new Vector3(0f, 270f, 0f);
                                //playerObject.SetActive(false);
                                playerObject1.SetActive(true);
                                mainCamera.enabled = false;
                                examineCamera.enabled = false;
                                //mainCamera.transform.eulerAngles = new Vector3(7f, 0f, 0f);
                                yield return new WaitForSeconds(0.5f);
                                raycasted_obj.PlayAnimation();
                                //player.enabled = true;
                                LoadNhaScene();
                                yield return new WaitForSeconds(1f);
                                nhungThuBenKia.SetActive(false);
                                sceneLoaded2 = true;
                                PlayerData.seventhSaved = true;

                                playerObject.SetActive(false);
                            }
                        }

                    }
                }
            }

            if (hit.collider.CompareTag("DoorTest"))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {

                    //Debug.Log("CUALOADNHA");
                    //raycasted_obj.PlayAnimation();
                    //LoadNhaScene();
                    //chan.SetActive(false);
                    //isLoaded2 = true;

                    //StartCoroutine(Waiter1());

                    //IEnumerator Waiter1()
                    //{
                    //    yield return new WaitForSeconds(1f);
                    //    nhungThuBenKia.SetActive(false);
                    //    sceneLoaded2 = true;
                    //    PlayerData.seventhSaved = true;
                    //}
                    player.enabled = false;
                    contactedDoor = true;


                }

            }

            if (hit.collider.CompareTag("DoorHinge"))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                    //nameFloatingIcons = "FloatingIcon" + raycasted_obj.name;
                    //namePanelFloatingIcons = "PanelFloating" + raycasted_obj.name;
                    //floatingIcon = GameObject.Find(nameFloatingIcons);
                    //panelFloating = GameObject.Find(namePanelFloatingIcons);
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
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                }

                if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    //raycasted_obj.PlayAnimation();
                    raycasted_obj.GetComponent<Rigidbody>().isKinematic = false;
                    openedDoor = true;
                    
                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);
                }
            }

            if (hit.collider.CompareTag("DoorTest1"))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BasicDoorController>();
                    if (panelFloating)
                    {
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                        panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    }
                    if (floatingIcon)
                        floatingIcon.GetComponent<Animator>().Play("ExpandFloating");
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanel");
                }

                if (Input.GetKeyUp(ExamineInputManager.instance.interactKey))
                {
                    if (panelFloating)
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelReverse");
                    //raycasted_obj.PlayAnimation();
                    //raycasted_obj.GetComponent<Rigidbody>().isKinematic = false;
                    //openedDoor = true;

                    if (panelFloating)
                        panelFloating.SetActive(false);
                    if (floatingIcon)
                        floatingIcon.SetActive(false);
                    player.enabled = false;
                    raycasted_obj.gameObject.layer= 0;
                    raycasted_obj.GetComponent<BoxCollider>().enabled = false;
                    //if (endRotationPlayer > 180)
                    //{
                    //    endRotationPlayer -= 360;
                    //}
                    //if(endRotationCamera > 180) {
                    //    endRotationCamera -= 360;
                    //}
                    startRotationPlayer = player.gameObject.transform.eulerAngles.y;
                    startRotationCamera = gameObject.transform.eulerAngles.x;
                    startTime = Time.time;
                    mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
                    mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
                    startX = player.transform.position.x;
                    startY = player.transform.position.y;
                    startZ = player.transform.position.z;
                    doOnceTwo = true;
                    
                    
                    



                    //player.gameObject.transform.position = new Vector3(Mathf.SmoothStep(10f, 20f, 5), 0, 0);

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
        if (contactedDoor == true)
        {
            playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, new Vector3(-24f, playerObject.transform.position.y, 1f), Time.deltaTime * 5);
            playerObject.transform.eulerAngles = Vector3.RotateTowards(playerObject.transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 5, 1f);
        }

        if(doOnceTwo == true)
        {
            // float t = (Time.time - startTime) / duration;
            //player.gameObject.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Mathf.SmoothStep(startPoint, endPoint, t), player.transform.eulerAngles.z);

            //p = playerrotation
            //x 
            //t = target
            // p + x = t
            //var t = new Vector3(0, endPoint, 
            //var x = endPoint-player.transform.eulerAngles.y;
            float t = (Time.time - startTime) / duration;
            playerStats.RotatePlayer(startRotationPlayer, endRotationPlayer, duration, player.gameObject,startRotationCamera, endRotationCamera, gameObject, startTime, this);
            player.transform.position = new Vector3(Mathf.SmoothStep(startX, targetPosition[0], t), Mathf.SmoothStep(startY, targetPosition[1], t), Mathf.SmoothStep(startZ, targetPosition[2], t));
            //playerStats.RotateCamera(startRotationCamera, endRotationCamera, duration, gameObject, startTime);
            bool sst = false;
            StartCoroutine(wait());
            IEnumerator wait()
            {
                yield return new WaitForSeconds(duration);
                //Debug.Log("Fuck");
                raycasted_obj.gameObject.layer= 9;
                //raycasted_obj.GetComponent<BoxCollider>().enabled = true;
                //player.GetComponent<Animator>().enabled = true;
                //if (!sst)
                //{
                //    player.GetComponent<Animator>().Play("xuyen cua",-1);
                //    sst = true;
                //}
                //yield return new WaitForSeconds(1.5f);
                //player.GetComponent<Animator>().enabled = false;
                player.m_MouseLook.Init(player.transform, transform);
                player.enabled = true;
                 
                doOnceTwo = false;
                 

                //player.m_MouseLook.yRot = mouseX;
                //player.m_MouseLook.xRot = mouseY;
                //player.enabled = true;
                //player.m_MouseLook.Init(player.transform, transform);
                //doOnceTwo = false;
            }
            
        }
        //Debug.Log(CrossPlatformInputManager.GetAxis("Mouse X") + ", " + CrossPlatformInputManager.GetAxis("Mouse Y"));
        
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.sprite = crosshairClicked;
            //uiHandLookAt.SetActive(true);
        }
        else
        {
            //uiHandLookAt.SetActive(false);
            //Debug.Log("ÁDSAD");
            if (panelFloating)
            {
                //panelFloating.GetComponent<Animator>().Play("FloatingPanelExit");
                panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
            }

            if (floatingIcon)
                floatingIcon.GetComponent<Animator>().Play("ExpandFloatingReverse");
            crosshair.sprite = crosshairUnclicked;
            isCrosshairActive = false;
        }
    }

    void LoadZooScene()
    {
        //SceneManager.LoadSceneAsync("Zoo", LoadSceneMode.Additive);
        StartCoroutine(playerStats.LoadAsynchronouslyAdditive("Zoo"));
    }

    void LoadNhaScene()
    {
        //SceneManager.LoadSceneAsync("level4", LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync("Zoo", UnloadSceneOptions.None);

        StartCoroutine(playerStats.LoadUnloadAsynchronously("level4", "Zoo"));
        //giayTestRaycast.enabled = false;
        //SceneManager.UnloadSceneAsync("level3", UnloadSceneOptions.None);
    }
    
}