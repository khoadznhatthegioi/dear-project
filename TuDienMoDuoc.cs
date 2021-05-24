using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;

    public class TuDienMoDuoc : MonoBehaviour
    {
        public ZoomInTriggerRaycast theRaycast;

        private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            var rayCast = other.GetComponent<FirstPersonController>();
            if (rayCast)
            {
                theRaycast.laTuDien = true;
            }
        }
            

        }
        private void OnTriggerExit(Collider other)
        {
            theRaycast.laTuDien = false;
        }

    }


