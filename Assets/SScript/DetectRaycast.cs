using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    //[SerializeField] GiayTestRaycast giayTestRaycast;
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;
    [SerializeField] CollideDoorFrame cdf;
    [SerializeField] AddForce af;
    bool isCrosshairActive;
    bool doOnce;
    bool doOnce2;
    float initD;
    bool once;
    bool avoidFail;
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;



        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("DoorTrigger"))
            {
                if (!doOnce)
                {
                    //if (hit.collider.CompareTag("DoorTrigger"))
                    //{
                    if (cdf.haltIsNear && !af.openedOutside)
                    {
                        if (!once)
                        {
                            initD = hit.distance;
                            once = true;
                        }
                        StartCoroutine(avoidFaill());
                        if (hit.distance < initD && avoidFail)
                        {
                            af.AddForceNear1();
                            doOnce = true;
                        }

                        IEnumerator avoidFaill()
                        {
                            yield return new WaitForSeconds(0.4f);
                            avoidFail = true;
                        }
                    }
                    //}
                }
                if (!doOnce2)
                {
                    if (hit.distance < 0.35f)
                    {
                        af.AddForceNear2();
                        doOnce2 = true;
                    }
                }
                //isCrosshairActive = true;
                //doOnce = true;
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                doOnce = false;
            }
        }

    }

}

