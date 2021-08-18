using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using EPOOutline;
using ExamineSystem;
public class ZoomInController : MonoBehaviour
{
    [SerializeField] ZoomInTriggerRaycast ray;
    [SerializeField] PlayerStats player;
    [SerializeField] ClickingOnObjectTest click;
    // Update is called once per frame
    float startRotCam;
    float startRotPlayer;
    public bool doOnceTwo;
    public bool doOnceThree;
    float startTime;
    void Update()
    {
        if (ray.doOnceTwo)
        {
            //Debug.Log(Time.timeScale);
            //ray.enabled = false;
            float t = (Time.time - ray.startTime) / ray.duration;
            player.RotatePlayer(ray.startRotationPlayer, ray.endRotationPlayer, ray.duration, player.gameObject, ray.startRotationCamera, ray.endRotationCamera, ray.gameObject, ray.startTime, ray);
            player.transform.position = new Vector3(Mathf.SmoothStep(ray.startX, ray.targetPosition[0], t), Mathf.SmoothStep(ray.startY, ray.targetPosition[1], t), Mathf.SmoothStep(ray.startZ, ray.targetPosition[2], t));
            
            //playerStats.RotateCamera(startRotationCamera, endRotationCamera, duration, gameObject, startTime);
            // sst = false;
            StartCoroutine(wait());
            IEnumerator wait()
            {
                yield return new WaitForSeconds(ray.duration);
                //Debug.Log("Fuck");
                //raycasted_obj.gameObject.layer = 9;
                //raycasted_obj.GetComponent<BoxCollider>().enabled = true;
                //player.enabled = true;
                //player.m_MouseLook.Init(player.transform, transform);
                ray.doOnceTwo = false;


                //player.m_MouseLook.yRot = mouseX;
                //player.m_MouseLook.xRot = mouseY;
                //player.enabled = true;
                //player.m_MouseLook.Init(player.transform, transform);
                //doOnceTwo = false;
            }
        }

        if ((PlayerData.moTuDien || PlayerData.nhinDiary) && !DocumentsListDisappear.isListAlreadyOn && !PauseMenuu.isPauseMenuAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !ray.doOnceTwo && !doOnceTwo && !DisplayInventory.isFixing)
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                //startX = player.transform.position.x;
                //startY = player.transform.position.y;
                //startZ = player.transform.position.z;
                //player.GetComponent<FirstPersonController>().enabled = false;
                if(ray.panelFloating)
                    ray.panelFloating.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                if (ray.panelFloatingDiary)
                    ray.panelFloatingDiary.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                if(click)
                    click.gameObject.GetComponent<Outlinable>().enabled = false;
                startTime = Time.time;
                ray.noiDay.SetActive(false);
                if ((PlayerData.daSua && gameObject.name == "tudien" )|| (PlayerData.daVeTrenDiary && gameObject.name == "DiaryCollider"))
                {
                    gameObject.layer = 0;
                }
                
                doOnceTwo = true;
                
                
            }
        }
        if (doOnceTwo)
        {
            float t = (Time.time - startTime) / ray.duration;
            player.RotatePlayer(ray.endRotationPlayer, ray.startRotationPlayer, ray.duration, player.gameObject, ray.endRotationCamera, ray.startRotationCamera, ray.gameObject, startTime, this);
            player.transform.position = new Vector3(Mathf.SmoothStep(ray.targetPosition[0], ray.startX, t), Mathf.SmoothStep(ray.targetPosition[1], ray.startY, t), Mathf.SmoothStep(ray.targetPosition[2], ray.startZ, t));
            //playerStats.RotateCamera(startRotationCamera, endRotationCamera, duration, gameObject, startTime);
            StartCoroutine(wait());
            IEnumerator wait()
            {
                yield return new WaitForSeconds(ray.duration);
                //Debug.Log("Fuck");
                //raycasted_obj.gameObject.layer = 9;
                //raycasted_obj.GetComponent<BoxCollider>().enabled = true;
                player.GetComponent<FirstPersonController>().enabled = true;
                ray.rhc.enabled = true;
                ray.rhcb.enabled = true;
                //ray.enabled = true;
                if (ray.floatingIconTuDien && PlayerData.moTuDien)
                {
                    ray.floatingIconTuDien.SetActive(true);
                    ray.floatingIconTuDien.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
                }
                
                //player.m_MouseLook.Init(player.transform, transform);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ray.crosshair.enabled = true;
                PlayerData.moTuDien = false;
                PlayerData.nhinDiary = false;
                ray.enabled = true;
                doOnceThree = true;
                doOnceTwo = false;


                //player.m_MouseLook.yRot = mouseX;
                //player.m_MouseLook.xRot = mouseY;
                //player.enabled = true;
                //player.m_MouseLook.Init(player.transform, transform);
                //doOnceTwo = false;
            }
            
        }
        if (doOnceThree)
        {
            StartCoroutine(wait());
            IEnumerator wait()
            {
                yield return new WaitForSeconds(0.8f);
                doOnceThree = false;
            }
        }
    }
}
