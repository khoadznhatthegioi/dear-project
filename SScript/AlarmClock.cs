using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.isAlarmTurnedOff == true)
        {
            audioSource.enabled = false;
        }
    }
}
