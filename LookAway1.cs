using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExamineSystem;


    public class LookAway1 : MonoBehaviour
    {
        public GameObject fpsController;
        public ZoomInTriggerRaycast thePlayer;
        public GameObject invisibleObject;
        //public GameObject buttonOnObject;
        [SerializeField] private Image crosshair = null;
        public GameObject bgz;
        //public GameObject tudien;
        public DisplayInventory displayInventory;
        public ZoomInTriggerRaycast zoom;
        public SimplyABool boolean;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (thePlayer.isInteracting)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (boolean.waitForAnimationEnd == false)
                    {
                        bgz.SetActive(true);
                        zoom.buffing = true;
                        StartCoroutine(waiter());


                        IEnumerator waiter()
                        {
                            yield return new WaitForSeconds(0.5f);


                            zoom.zoomInChaiBiaCamera.SetActive(false);
                            //Debug.Log("ratok");
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            crosshair.enabled = true;
                            //(fpsCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
                            fpsController.SetActive(true);
                            thePlayer.isInteracting = false;
                            if (invisibleObject)
                                invisibleObject.SetActive(true);
                            //buttonOnObject.SetActive(false);
                            //tudien.SetActive(false);
                            PlayerData.nhinChaiBia = false;
                            //IEnumerator waiter1()
                            //{
                            //yield return new WaitForSeconds(0.5f);
                            zoom.buffing = false;
                            //}

                        }

                    }
                }

            }
        }
    }
