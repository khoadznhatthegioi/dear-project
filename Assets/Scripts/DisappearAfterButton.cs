using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAfterButton : MonoBehaviour
{
    public GameObject dissapearObject;
    public GameObject trigger;
    private void OnTriggerStay()
    {
        if (dissapearObject == true)
        {

            if (Input.GetKeyDown(key: KeyCode.E))
            {
                dissapearObject.SetActive(false);
                trigger.SetActive(false);
            }
                
                
                


        }
    
    }
}
