using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentsButton : MonoBehaviour
{

    public GameObject[] documentsUI;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
