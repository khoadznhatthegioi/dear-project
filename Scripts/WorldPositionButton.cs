using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using ExamineSystem;

public class WorldPositionButton : MonoBehaviour
{
    [SerializeField] PauseMenuu pauseMenu;
    [SerializeField] DocumentsListDisappear documentsList;
    [SerializeField] InventoryDisappear inventoryDisappear;
    [SerializeField]
    private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;
    [SerializeField] bool doOnce;
    [SerializeField] private Image imagePanel;
    [SerializeField] SetFloatingIconTrue checkFarAway;
    public bool isPlaying;
    public bool initialPlaying;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    private void Update()
    { 
        if (!targetTransform)
        {
            gameObject.SetActive(false);
        }

        else if (targetTransform)
        {
            
            //else if (targetTransform)
            //{
            if (targetTransform.gameObject.activeInHierarchy == false )
            {
                gameObject.SetActive(false);
            }
            //}
            var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
            //screenPoint.y += 1;
            rectTransform.position = screenPoint;

            var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
            var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);

            var show = distanceFromCenter < 0.3f;
            if (screenPoint.z < 0.0f)
            {
                image.enabled = false;
                show = false;
            }

            if(!PauseMenuu.isPauseMenuAlreadyOn && !DocumentsListDisappear.isListAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !ExamineSystem.ExamineRaycast.isExamining)
            {
                if (show)
                {
                    image.enabled = show;
                }
                if (!show && checkFarAway.checkFaraway == false)
                {
                    GetComponent<Animator>().Play("InitialExpandReverse");
                }
                if (checkFarAway.checkFaraway)
                {
                    //GetComponent<Animator>().enabled = false;
                    //GetComponent<Animator>().en;

                    GetComponent<Animator>().Play("InitialExpandReverse1");
                    //isPlaying = true;
                }
                

                if (!show || checkFarAway.checkFarAway)
                {
                    doOnce = false;
                    //GetComponent<Animator>().Play("InitialExpandReverse
                }
                if (show && doOnce == false && isPlaying == false) 
                {
                    GetComponent<Animator>().Play("InitialExpand");
                    //Debug.Log("asd");
                    doOnce = true;
                }

               
                imagePanel.enabled = show;
            }
            else if(PauseMenuu.isPauseMenuAlreadyOn || DocumentsListDisappear.isListAlreadyOn || InventoryDisappear.isInventoryAlreadyOn || ExamineSystem.ExamineRaycast.isExamining)
            {
                image.enabled = false;
                imagePanel.enabled = false;
            }
            
        }


        
        
        

    }

   


}

