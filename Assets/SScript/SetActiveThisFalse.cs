using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveThisFalse : MonoBehaviour
{
    //[SerializeField] GameObject thisGameObject;
    //[SerializeField] Animator animator;
    public void SetThisToFalse()
    {
        this.gameObject.SetActive(false);
        //animator.enabled = false;
    }
}
