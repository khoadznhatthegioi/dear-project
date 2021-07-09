using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAfterTrigger : MonoBehaviour
{
    public bool waitForEndAnimation;
    public SimplyABool boolean;
    public void TurnBool()
    {
        boolean.waitForAnimationEnd = true;
    }
    public void TurnBoolOff()
    {
        boolean.waitForAnimationEnd = false;
    }
}
