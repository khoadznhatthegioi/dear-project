using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;

namespace ExamineSystem {
    public class GroundItem : MonoBehaviour
    {
        public ItemObject item;

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "MainCamera")
        //    {
        //        other.GetComponent<ExamineRaycast>().enabled = true;
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if(other.tag == "MainCamera")
        //    {
        //        other.GetComponent<ExamineRaycast>().enabled = false;
        //    }
        //}
    }
}
