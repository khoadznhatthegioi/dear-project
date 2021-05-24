using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBoolAnotherScene : MonoBehaviour
{
    public bool u;
    public bool check;

    // Update is called once per frame
    void Update()
    {
        //ok = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Jkdlsk.ok = true;
        }
        StartCoroutine(Waiter());

        IEnumerator Waiter()
        {
            yield return new WaitForSeconds(5f);
            if(u == false)
            {
                SceneManager.LoadScene("ss 1");
                u = true;
            }
           
        }
        if (Jkdlsk.ok == true)
            check = true;
    }
}
