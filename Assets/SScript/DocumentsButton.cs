using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentsButton : MonoBehaviour
{

    public GameObject[] documentsUI;
    public void Document1()
    {
        documentsUI[0].SetActive(true);
        for(int i = 1; i < documentsUI.Length; i++)
        {
            documentsUI[i].SetActive(false);
        }
    }
    public void Document2()
    {
        documentsUI[1].SetActive(true);
        for (int i = 0; i < documentsUI.Length; i++)
        {
            if(i!= 1)
            documentsUI[i].SetActive(false);
        }

    }
}
