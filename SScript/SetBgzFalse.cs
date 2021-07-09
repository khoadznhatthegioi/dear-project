using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBgzFalse : MonoBehaviour
{
    public GameObject bgz;
    public void SetBgzToFalse()
    {
        bgz.SetActive(false);
    }
}
