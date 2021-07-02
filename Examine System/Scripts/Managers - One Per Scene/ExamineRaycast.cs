using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExamineSystem
{
    public class ExamineRaycast : MonoBehaviour
    {
        public LightLayerChange lightLayerChange;
        public static bool isExamining;

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


        [Header("Crosshair")]
        [SerializeField] private Image uiCrosshair = null;
        [HideInInspector] public bool interacting = false;

        private bool isCrosshairActive;

        private const string pickupTag = "Pickup";
        private const string showNameTag = "ShowName";

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
                        raycastedObj.MainHighlight(true);

                        //var initialMeshRenderer = raycastedObj.GetComponent<MeshRenderer>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                    {
                        isExamining = true;
                        lightLayerChange.ChangeLayerExamine(raycastedObj.GetComponent<MeshRenderer>());
                        raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        raycastedObj.ExamineObject();
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
                        raycastedObj.MainHighlight(true);
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                    {
                        raycastedObj.ExamineObject();
                        isExamining = true;
                        lightLayerChange.ChangeLayerExamine(raycastedObj.GetComponent<MeshRenderer>());
                        raycastedObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        if (raycastedObj.name == "giayTest")
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
                        raycastedObj.MainHighlight(true);
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    interacting = true;

                    if (Input.GetKeyDown(ExamineInputManager.instance.interactKey))
                    {
                        isExamining = true;
                        raycastedObj.ExamineObject();
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

        public void CloseButtonExamine()
        {
            raycastedObj.StopInteractingObject();
        }
    }
}
