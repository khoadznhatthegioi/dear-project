using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSth : MonoBehaviour
{
    int ioo = 0;
    public bool sth;
    public bool TestBool()
    {
        if (ioo == 0)
        {
            return true;
        }
        else return false;
    }
    public void Update()
    {
       if(TestBool() == true)
        {
            Debug.Log(TestBool());
            sth = true;
        }
    }
}
