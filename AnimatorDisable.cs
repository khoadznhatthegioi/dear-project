using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class AnimatorDisable : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent < FirstPersonController >().enabled = false;
        }
        void AnimatorDis()
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<FirstPersonController>().enabled = true;
        }

    }
}
