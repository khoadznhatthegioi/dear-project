using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriiggerLoadZoo2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        Debug.Log("loadzoo2");
        //xoa hoan toan scene cu
    }
}
