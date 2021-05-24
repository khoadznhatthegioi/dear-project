using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExamineSystem;

public class GiayRaycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string layerToExclude = null;
    //public GameObject uiHandLookAt;
    private ExamineItemController raycastedObj;
    public ExamineItemController crayon;
    public bool daLayBatLua;
    public bool daLayBoNhang;


    [Header("Crosshair")]
    [SerializeField] private Image uiCrosshair = null;
    [HideInInspector] public bool interacting = false;

    private bool isCrosshairActive;

    private const string pickupTag = "Pickup";
    private const string showNameTag = "ShowName";

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
            /*if(hit.collider.CompareTag(showNameTag))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (!interacting)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                    raycastedObj.MainHighlight(true);
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                interacting = true;

                if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                {
                    raycastedObj.ExamineObject();
                }
            }*/

            if (hit.collider.CompareTag(pickupTag))
            {
                if (!interacting)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ExamineItemController>();
                    raycastedObj.MainHighlight(true);
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                interacting = true;

                if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                {
                    raycastedObj.ExamineObject();
                    if (raycastedObj.isBatLua == true)
                    {
                        daLayBatLua = true;
                    }
                    if (raycastedObj.isBoNhang == true)
                        daLayBoNhang = true;
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

