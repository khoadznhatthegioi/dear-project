using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAvailable : MonoBehaviour
{
    public GameObject flashlightOnTable;
    public GameObject flashlightOnHand;
    private void Update()
    {
      if (flashlightOnTable == false)
        {
            Debug.Log("false");
            flashlightOnHand.SetActive(true);
        }
      
    }
}
