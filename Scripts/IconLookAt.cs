using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLookAt : MonoBehaviour
{
    public Transform cameraTransform;


void Update()
    {
        transform.LookAt(cameraTransform);
    }

}
