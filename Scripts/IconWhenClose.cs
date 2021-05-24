using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconWhenClose : MonoBehaviour
{
    public GameObject iconObject;
    public GameObject dissapearObject;
    public GameObject trigger;
    public GameObject flashlightOnHand;
    public GameObject lightFlashlight;
    public GameObject sound;
    private void Update()
    {
        if (dissapearObject == true)
        {
            lightFlashlight.SetActive(false);
            sound.SetActive(false);
        }
        if (flashlightOnHand == true)
        {
            sound.SetActive(true);
        }

       
       
    }

    private void OnTriggerStay()
    {
        
        iconObject.SetActive(true);
        if (dissapearObject == true)
        {
            

            if (Input.GetButtonUp("EKey"))
            {
                Debug.Log("E");
                dissapearObject.SetActive(false);
                iconObject.SetActive(false);
                trigger.SetActive(false);
                flashlightOnHand.SetActive(true);
            }





        }

    }
    private void OnTriggerExit(Collider other)
    {
        iconObject.SetActive(false);
    }
    
    
    

}


