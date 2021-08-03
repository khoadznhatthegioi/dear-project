using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TestObjectSmoothStep : MonoBehaviour
{
    // Minimum and maximum values for the transition.
    float minimum;
    float maximum = -1f;

    // Time taken for the transition.
    float duration = 1;

    float startTime;

    void Start()
    {
        // Make a note of the time the script started.
        startTime = 5;
        minimum = transform.position.x;
    }

    void Update()
    {
        // Calculate the fraction of the total duration that has passed.
        float t = (Time.time - startTime) / duration;
        transform.position = new Vector3(Mathf.SmoothStep(minimum, maximum, t), transform.position.y, transform.position.z);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject.Find("FPSController_Prefab").GetComponent<FirstPersonController>().enabled = false;
        //    GameObject.Find("FPSController_Prefab").transform.eulerAngles = new Vector3(0, 0, 0);
        //    GameObject.Find("FPSController_Prefab").GetComponent<FirstPersonController>().m_MouseLook.Init(GameObject.Find("FPSController_Prefab").transform, GameObject.Find("MainCamera").transform);
        //   GameObject.Find("FPSController_Prefab").GetComponent<FirstPersonController>().enabled = true;
        //    //GameObject.Find("FPSController_Prefab").GetComponent<FirstPersonController>().mouseLook = true;
        //    //GameObject.Find("FPSController_Prefab").GetComponent<FirstPersonController>().enabled = true;
        //}
    }
}
