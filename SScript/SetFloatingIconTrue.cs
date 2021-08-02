using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatingIconTrue : MonoBehaviour
{
    [Header("FloatingIcons")]
    public GameObject icon;
    public bool checkFarAway;
    public bool checkFaraway;
    public bool checkInside;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //if(gameObject.name == "tudien=true (1)")
            //{
            checkFaraway = false;
            checkInside = true;
            if(icon)
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
            checkFarAway = true;
            checkFaraway = true;

            //icon.SetActive(false);
            if (icon)
            {
                if (icon.GetComponent<WorldPositionButtonSmallObjects>())
                {
                    icon.SetActive(false);
                }
            }
           
                
            //}
        }
    }


}
