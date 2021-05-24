using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class SlowDown2 : MonoBehaviour
    {
        public FirstPersonController thePlayerOne;

        private void OnTriggerEnter(Collider other)
        {
            var m_WalkSpeed = other.GetComponent<FirstPersonController>();
            if (m_WalkSpeed)
            {
                thePlayerOne.m_WalkSpeed = 0.25f;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            thePlayerOne.m_WalkSpeed = 0.5f;
        }
    }


}
