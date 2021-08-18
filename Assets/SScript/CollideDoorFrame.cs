using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDoorFrame : MonoBehaviour
{
    public bool isNear;
    [SerializeField] AddForce af;
    public bool alreadyInside;
    public bool haltIsNear;
    //[SerializeField] CollideDoorFrame parentCdf;

    private void Update()
    {
        //if(gameObject.name == "GameObject")
        //{
        //    if(parentCdf.haltIsNear && af.isAddedOnce)
        //    {
        //        haltIsNear = true;
        //    }
        //}
        if(af.collide && alreadyInside /*&& gameObject.name != "GameObject"*/)
        {
            haltIsNear = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DoorTrigger")
        {
            alreadyInside = true;
        }
        if(other.tag == "DoorTrigger" && af.collide && !haltIsNear)
        {
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DoorTrigger")
        {
            isNear = false;
            alreadyInside = false;
        }
    }
}
