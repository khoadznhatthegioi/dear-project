using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExamineSystem
{
    public class GiayTestRaycast : MonoBehaviour
    {
        public ExamineRaycast examineRaycast;
        [Header("Raycast Features")]
        [SerializeField] private float rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string layerToExclude = null;
        //public GameObject uiHandLookAt;
        private ExamineItemController raycastedObj;

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
                if (hit.collider.CompareTag("PhieuDiem"))
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
                        examineRaycast.giongDocLaThu.SetActive(true);
                        StartCoroutine(Waiter());
                        IEnumerator Waiter()
                        {
                            yield return new WaitForSeconds(35f);
                            examineRaycast.cua.tag = "CuaLoadNha";
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
}

