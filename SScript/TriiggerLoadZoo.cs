using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriiggerLoadZoo : MonoBehaviour
{
    public GameObject blockWayOut;
    public GameObject triggerLoadZoo2;
    [SerializeField] public GameObject giongNoi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            giongNoi.SetActive(true);
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                yield return new WaitForSeconds(15f);
                Debug.Log("LoadTronmgPhong");
                //load scene trong phong
                blockWayOut.SetActive(true);
                triggerLoadZoo2.SetActive(true);
            }

        }

    }
}
