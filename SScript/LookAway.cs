using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExamineSystem;
using EPOOutline;

    public class LookAway : MonoBehaviour
    {
        public GameObject fpsController;
        public ZoomInTriggerRaycast thePlayer;
        public GameObject invisibleObject;
        public GameObject buttonOnObject;
        [SerializeField] private Image crosshair = null;
        public GameObject bgz;
        //public GameObject tudien;
        public DisplayInventory displayInventory;
        public ZoomInTriggerRaycast zoom;
        public SimplyABool boolean;
    [SerializeField] ClickingOnObjectTest click;


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
                    zoom.noiDay.SetActive(false);
                        bgz.SetActive(true);
                        zoom.buffing = true;
                        StartCoroutine(waiter());


                        IEnumerator waiter()
                        {
                            yield return new WaitForSeconds(0.5f);

                        zoom.panelFloating.GetComponent<Image>().color = new Color32(255, 255, 255, 26);
                        click.gameObject.GetComponent<Outlinable>().enabled = false;
                            zoom.zoomInTuDienCamera.SetActive(false);
                            //Debug.Log("ratok");
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            crosshair.enabled = true;
                            //(fpsCam.GetComponent(zoomInRay) as MonoBehaviour).enabled = false;
                            fpsController.SetActive(true);
                            thePlayer.isInteracting = false;
                            if (invisibleObject)
                                invisibleObject.SetActive(true);
                            buttonOnObject.SetActive(false);
                            //tudien.SetActive(false);
                            PlayerData.moTuDien = false;
                            zoom.tuDienLight.SetActive(false);
                            //yield return StartCoroutine(waiter1());
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

