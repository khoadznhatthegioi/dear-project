using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //[SerializeField] CheckBool checkBool;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CanvasLoad");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

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
