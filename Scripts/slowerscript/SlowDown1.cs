using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class SlowDown1 : MonoBehaviour
    {
        public FirstPersonController thePlayer;

        private void OnTriggerEnter(Collider other)
        {
            var m_WalkSpeed = other.GetComponent<FirstPersonController>();
            if (m_WalkSpeed)
            {
                thePlayer.m_WalkSpeed = 0.5f;
            }

        }
        private void OnTriggerExit(Collider other)
        {
            thePlayer.m_WalkSpeed = 1f;
        }

    }

    
}
