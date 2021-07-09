using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    bool isEkeydown;
    void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.E))
        {
            isEkeydown = true;
        } 
        else 
        {
            isEkeydown = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            if (isEkeydown == true)
                anim.SetTrigger("OpenClose");
           
      
    }
    }
}
