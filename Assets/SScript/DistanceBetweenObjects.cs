using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBetweenObjects : MonoBehaviour
{
    [SerializeField] float distance;

    [Header("GameObjects Comparing")]
    public GameObject tuDien;
    public GameObject chaiBia;
    //tiep tuc

    [Header("Floating Points")]
    public GameObject floatingPointTuDien;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.gameObject.transform.position, tuDien.transform.position)< distance){
            floatingPointTuDien.SetActive(true);
        }
        else if(Vector3.Distance(this.gameObject.transform.position, tuDien.transform.position) > distance)
        {
            floatingPointTuDien.SetActive(false);
        }
    }
}
