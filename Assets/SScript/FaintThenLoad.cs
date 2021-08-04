using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;


public class FaintThenLoad : MonoBehaviour
{
    
    


    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(waiter());

        
        IEnumerator waiter()
        {
            yield return new WaitForSeconds(10f);
            SceneManager.LoadScene("level1");
        }
        
    }
}
