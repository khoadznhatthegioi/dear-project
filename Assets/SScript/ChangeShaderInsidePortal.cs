using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderInsidePortal : MonoBehaviour
{
    [SerializeField] public Renderer[] insidePortal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0; i < insidePortal.Length; i++)
            {
                insidePortal[i].material.shader = Shader.Find("HDRP/Lit");
            }
        }
    }
}
