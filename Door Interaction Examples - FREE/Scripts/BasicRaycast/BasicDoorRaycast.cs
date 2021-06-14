using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class BasicDoorRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;
    [SerializeField] GameObject nha;
    [SerializeField] FirstPersonController player;
    [SerializeField] GameObject ban;
    [SerializeField] GameObject cua;
    [SerializeField] TriggerCua triggerCua;
    public bool isLoaded2;
    public bool isLoaded;
    public GameObject nhungThuBenKia;
    public static bool sceneLoaded1;
    public static bool sceneLoaded2;
    //public GameObject uiHandLookAt;

    private BasicDoorController raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("UI Parameters")]
    [SerializeField] private Image crosshair = null;
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
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                   raycasted_obj.PlayAnimation();
                }
             }

            if (hit.collider.CompareTag(cuaLoadZoo))
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
                    if (!isLoaded)
                    {
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
                            Debug.Log("CUALOADNHA");
                            raycasted_obj.PlayAnimation();
                            LoadNhaScene();
                        isLoaded2 = true;

                            StartCoroutine(Waiter1());

                            IEnumerator Waiter1()
                            {
                                yield return new WaitForSeconds(1f);
                                nhungThuBenKia.SetActive(false);
                                sceneLoaded2 = true;
                                PlayerData.seventhSaved = true;
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
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
            //uiHandLookAt.SetActive(true);
        }
        else
        {
            //uiHandLookAt.SetActive(false);
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
    
    void LoadZooScene()
    {
        SceneManager.LoadSceneAsync("Zoo", LoadSceneMode.Additive);
    }

    void LoadNhaScene()
    {
        SceneManager.LoadSceneAsync("level4", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Zoo", UnloadSceneOptions.None);
        //SceneManager.UnloadSceneAsync("level3", UnloadSceneOptions.None);
    }
}