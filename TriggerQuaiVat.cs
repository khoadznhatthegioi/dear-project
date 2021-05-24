using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuaiVat : MonoBehaviour
{
    //public GameObject quaiVat;
    //public float movementSpeed = 5.0f;
    public bool isQuaiVatAwake;
    public GameObject triggerCua;
    public GameObject cua;
    //public Animator cuaCua;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("LUKYSADSJHJKDHSJHD");
            isQuaiVatAwake = true;
            triggerCua.SetActive(true);
            cua.SetActive(true);
            //cua.tag = "CuaSauKhiBiRuot";
            //cuaCua.enabled = false;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
       // if(isQuaiVatAwake == true)
        //{
            //cua.transform.Rotate(-90, 0, 0);
            //cuaCua.enabled = true;
       // }
    }

    // Update is called once per frame

}
