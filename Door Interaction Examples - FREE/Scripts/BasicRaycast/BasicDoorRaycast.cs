using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;

public class BasicDoorRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    //[SerializeField] GiayTestRaycast giayTestRaycast;
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;
    [SerializeField] GameObject nha;
    [SerializeField] FirstPersonController player;
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

    [SerializeField] PlayerStats playerStats;
    //public GameObject uiHandLookAt;

    private BasicDoorController raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("UI Parameters")]
    [SerializeField] private Image crosshair = null;
    [SerializeField] private Sprite crosshairUnclicked;
    [SerializeField] private Sprite crosshairClicked;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";
    const string cuaLoadZoo = "CuaLoadZoo";

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
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                        panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    }
                    if (floatingIcon)
                        floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
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
                        panelFloating.GetComponent<Animator>().Play("FloatingPanelEnter");
                        panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 86);
                    }
                    if (floatingIcon)
                        floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
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

        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
        if(contactedDoor == true)
        {
            playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, new Vector3(-24f, playerObject.transform.position.y, 1f), Time.deltaTime * 5);
            playerObject.transform.eulerAngles = Vector3.RotateTowards(playerObject.transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 5, 1f);
        }
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
            if (panelFloating)
            {
                panelFloating.GetComponent<Animator>().Play("FloatingPanelExit");
                panelFloating.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 58);
            }

            if (floatingIcon)
                floatingIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
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