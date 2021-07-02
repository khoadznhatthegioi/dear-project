using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //[SerializeField] CheckBool checkBool;
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (CheckBool.doneLoading)
        {
            StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(0.1f);
                this.gameObject.SetActive(false);
            }
            CheckBool.doneLoading = false;
        }
    }


}
