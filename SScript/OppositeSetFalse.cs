using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeSetFalse : MonoBehaviour
{
    public GameObject quadOpposite;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            quadOpposite.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            quadOpposite.SetActive(true);
        }
    }
}
