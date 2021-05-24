using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiVatChay : MonoBehaviour
{
    public TriggerQuaiVat triggerQuaiVat;
    // Update is called once per frame
    void Update()
    {
        if (triggerQuaiVat.isQuaiVatAwake == true)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime);
            
        }
    }
 
}
