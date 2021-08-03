using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExamineSystem;

public class WorldPositionButtonSmallObjects : MonoBehaviour
{

    [SerializeField] PauseMenuu pauseMenu;
    [SerializeField] DocumentsListDisappear documentsList;
    [SerializeField] InventoryDisappear inventoryDisappear;
    [SerializeField] PutOnRaycast ray;
    [SerializeField]
    private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;
    [SerializeField] bool doOnce;
    [SerializeField] private Image imagePanel;
    [SerializeField] SetFloatingIconTrue checkFarAway;
    public bool isPlaying;
    public bool initialPlaying;
    // Start is called before the first frame update
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null) 
        {
            gameObject.SetActive(false);
        }
        else if(targetTransform.gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(false);
        }
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);

        var show = distanceFromCenter < 0.5f;
        if (screenPoint.z < 0.0f) show = false;
        if (!PauseMenuu.isPauseMenuAlreadyOn && !DocumentsListDisappear.isListAlreadyOn && !InventoryDisappear.isInventoryAlreadyOn && !ExamineSystem.ExamineRaycast.isExamining)
        {
            if (show && !ray.isCrosshairActive)
            {
                image.enabled = true;
            }
            else if (!show || ray.isCrosshairActive)
            {
                image.enabled = false;
            }
        }
        else image.enabled = false;
            
    }
}
