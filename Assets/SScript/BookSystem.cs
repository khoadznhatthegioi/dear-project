using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSystem : MonoBehaviour
{
   

    public int i = 0;
    public GameObject[] book1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonTurnPage()
    {
        if (i < 2)
        {
            if (book1[i].activeInHierarchy == true)
            {
                book1[i + 1].SetActive(true);
                book1[i].SetActive(false);
            }

            i++;
        }
 
    }
    public void ButtonTurnPageBack()
    {
        if (i >= 1)
        {
            if (book1[i].activeInHierarchy)
            {
                book1[i - 1].SetActive(true);
                
                book1[i].SetActive(false);
                
            }
            i--; 
        }
       
    }
}
