using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    public Transform player;
    [SerializeField] float distance = 1;
    public bool isNear;
    private void Update()
    {
        if(Vector3.Distance(this.transform.position, player.position) <= distance)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
    }
}
