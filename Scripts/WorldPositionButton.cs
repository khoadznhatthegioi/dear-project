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
    [SerializeField] private Image imagePanel;


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
                if (targetTransform.gameObject.activeInHierarchy == false)
                {
                    gameObject.SetActive(false);
                }
            //}
            var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
            rectTransform.position = screenPoint;

            var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
            var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);

            var show = distanceFromCenter < 0.3f;
            if (screenPoint.z < 0.0f) show = false;
            if(!pauseMenu.isPauseMenuAlreadyOn && !documentsList.isListAlreadyOn && !inventoryDisappear.isInventoryAlreadyOn && !ExamineSystem.ExamineRaycast.isExamining)
            {
                image.enabled = show;
                imagePanel.enabled = show;
            }
            else if(pauseMenu.isPauseMenuAlreadyOn || documentsList.isListAlreadyOn || inventoryDisappear.isInventoryAlreadyOn || ExamineSystem.ExamineRaycast.isExamining)
            {
                image.enabled = false;
                imagePanel.enabled = false;
            }
            
        }


        
        
        

    }

   


}

