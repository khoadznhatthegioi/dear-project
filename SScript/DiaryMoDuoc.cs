using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using ExamineSystem;
    
        public class DiaryMoDuoc : MonoBehaviour
        {
            public ZoomInTriggerRaycast theRaycast;

            private void OnTriggerStay(Collider other)
            {
                var rayCast = other.GetComponent<FirstPersonController>();
                if (rayCast)
                {
                    theRaycast.laDiary = true;
                }

            }
            private void OnTriggerExit(Collider other)
            {
                theRaycast.laDiary = false;
            }

        }
    


