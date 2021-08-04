using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotForScene1 : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    
    float honrizontalRotation = 0;
    float verticalRotation = 0;
    public float leftRightRange = 60.0f;
    public float upDownRange = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        honrizontalRotation -= Input.GetAxis("Mouse X") * mouseSensitivity;
        honrizontalRotation = Mathf.Clamp(honrizontalRotation, -leftRightRange, leftRightRange);
        transform.localRotation = Quaternion.Euler(0, -honrizontalRotation + 180, 0);


        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity ;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

       
        

    }
}
