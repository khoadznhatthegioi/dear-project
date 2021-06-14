using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoCua : MonoBehaviour
{
    public static bool isDungTruocCua;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check = isDungTruocCua;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDungTruocCua = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDungTruocCua = false;
        }
    }
}
