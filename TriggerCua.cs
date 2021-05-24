using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCua : MonoBehaviour
{
    public bool isInFrontOfDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInFrontOfDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInFrontOfDoor = false;
        }
    }
}
