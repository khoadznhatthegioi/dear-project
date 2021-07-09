using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiongNoi : MonoBehaviour
{
    public GameObject triggerLoadZoo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //cua khoa
        if (other.CompareTag("Player"))
        {
            triggerLoadZoo.SetActive(true);
        }
        
    }
}
