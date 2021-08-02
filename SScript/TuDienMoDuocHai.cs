using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;

    public class TuDienMoDuocHai : MonoBehaviour
    {
        public ZoomInTriggerRaycastUnused theRaycast;

        private void OnTriggerStay(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            var rayCast = other.GetComponent<FirstPersonController>();
            if (rayCast)
            {
                theRaycast.laChaiBia = true;
            }

        }

    }
        private void OnTriggerExit(Collider other)
        {
            theRaycast.laChaiBia = false;
        }

    }

