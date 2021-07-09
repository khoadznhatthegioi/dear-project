using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLayerChange : MonoBehaviour
{
    public bool isDark;
    public void ChangeLayerExamine(MeshRenderer meshRenderer)
    {
        if(isDark)
            meshRenderer.renderingLayerMask = 258;
    }

}
