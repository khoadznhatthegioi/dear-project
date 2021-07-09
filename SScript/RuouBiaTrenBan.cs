using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuouBiaTrenBan : MonoBehaviour
{
    public GameObject doKhui;
    public GameObject ruouBia;

    // Update is called once per frame
    void Update()
    {
        if (doKhui.activeInHierarchy == true)
        {
            ruouBia.SetActive(true);
        }
    }
}
