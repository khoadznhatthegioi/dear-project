using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInRoom : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<DistanceBetweenObjects>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<DistanceBetweenObjects>().enabled = false;
        }
    }
}
