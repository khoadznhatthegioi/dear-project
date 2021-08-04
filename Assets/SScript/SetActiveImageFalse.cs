using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExamineSystem;

namespace ExamineSystem
{
    public class SetActiveImageFalse : MonoBehaviour
    {
        [SerializeField] ZoomInTriggerRaycast smoothRaycast;
        [SerializeField] ExamineRaycast examineRay;
        //[SerializeField] ZoomInTriggerRaycast zoomRay;
        [SerializeField] BasicDoorRaycast doorRaycast;
        public SetFloatingIconTrue set;
        public bool i;

        public void SetImageFalse()
        {
            GetComponent<Image>().enabled = false;
        }

        public void CheckFarAway()
        {
            set.checkFarAway = false;
        }
        public void CheckInside()
        {
            //set.checkInside = false;
        }
        public void Awakssse()
        {
            //var iss = GetComponent<WorldPositionButton>();
            //if (!iss.initialPlaying)
            //    iss.initialPlaying = true;
            //else iss.initialPlaying = false;
        }
        public void CheckRaycast()
        {
            //Debug.Log("sss");
            if (smoothRaycast.isCrosshairActive || examineRay.interacting || doorRaycast.doOnce)
            {

                GetComponent<Animator>().Play("ExpandFloating"); 
            }
        }
        public void IsPlaying()
        {
            GetComponent<WorldPositionButton>().isPlaying = true;
        }
        public void CheckFaraway()
        {
            set.checkFaraway = false;
            GetComponent<WorldPositionButton>().isPlaying = false;
        }
        public void StopPlaying()
        {
            //gameObject.GetComponent<Animator>().Rebind(); = false;
        }
        public void SetActiveThis()
        {
            gameObject.SetActive(false);
        }
    }
}
