using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStencil : MonoBehaviour
{
    public GameObject armChair;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            armChair.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            armChair.SetActive(true);
        }
    }
}
