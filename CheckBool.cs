using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CheckBool : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    public FirstPersonController fpsc;
    public static bool isBuffering;
    public void Check10On()
    {
        PlayerStats.check10 = true;

        isBuffering = false;
        playerStats.panel1.SetActive(false);
        
    }
    public void CheckBol()
    {
        isBuffering = true;
        fpsc.enabled = false;
    }
    public void CheckBol1()
    {
        fpsc.enabled = true;
    }
}

