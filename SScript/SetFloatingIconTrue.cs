using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatingIconTrue : MonoBehaviour
{
    [Header("FloatingIcons")]
    public GameObject icon;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //if(gameObject.name == "tudien=true (1)")
            //{
                icon.SetActive(true);
            //}
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (gameObject.name == "tudien=true (1)")
            //{
                icon.SetActive(false);
            //}
        }
    }


}
