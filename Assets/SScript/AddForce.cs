using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float force;
    private bool changed;
    bool l;
    float y;
    public float speed =33.37f;
    [SerializeField] float angleActive;
    [SerializeField] BasicDoorRaycast bdr;
    [SerializeField] Image crosshair;
    CollideDoorFrame cd;
    [SerializeField] CollideDoorFrame cd2;
    public bool collide;
    Vector3 initialD;
    bool i;
    public bool openedOutside;
    //public bool isAddedOnce;
    void Start()
    {
        y = rb.gameObject.transform.eulerAngles.y;
        cd = GetComponent<CollideDoorFrame>();
    }

    void Update()
    {
        

        if (rb.gameObject.transform.eulerAngles.y != y)
        {
            changed = true;
        }
        if(rb.gameObject.transform.eulerAngles.y>= y +angleActive)
        {
            l = true;
            
        }
        //if (l == true && rb.gameObject.transform.eulerAngles.y <y+115)
        //{
        //    rb.isKinematic= true;
        //    //Debug.Log("heheh");
        //    //Vector3 newDir = Vector3.RotateTowards(rb.gameObject.transform.eulerAngles, new Vector3(rb.gameObject.transform.eulerAngles.x, y + 125, rb.gameObject.transform.eulerAngles.z), Time.deltaTime * 0.01f, 0f);
        //    //rb.gameObject.transform.rotation = Quaternion.LookRotation(newDir);
        //    speed = speed * 0.995f;
        //    rb.gameObject.transform.Rotate(0, speed*Time.deltaTime, 0);
        //}
        if(rb.gameObject.transform.eulerAngles.y ==y + 115)
        {
            l = false;
        }

        if (cd.isNear && bdr.openedDoor1)
        {
            //rb.AddForce(new Vector3(-force, 0f, 0f), ForceMode.Impulse);
            AddForceNear1();
            //rb.gameObject.tag = "Untagged";
            //crosshair.sprite = bdr.crosshairUnclicked;
            //}
        }
        //if(cd2.isNear && bdr.openedDoor2)
        //{
        //    AddForceNear2();
        //}
    }

    void FixedUpdate()
    {
        if (bdr.openedDoor && !changed)
            Jump();
    }

    void Jump()
    {
        rb.AddForce(new Vector3(-force, 0f, 0f), ForceMode.Impulse);
        bdr.openedDoor = false;
        collide = true;
        rb.gameObject.tag = "Untagged";
        crosshair.sprite = bdr.crosshairUnclicked;
        if (!cd.alreadyInside)
        {
            openedOutside = true;
        }
    }
    public void AddForceNear1()
    {
        rb.AddForce(new Vector3(-0.6f, 0f, 0f), ForceMode.Impulse);
        bdr.openedDoor1 = false;
        //isAddedOnce = true;
    }

    public void AddForceNear2()
    {
        rb.AddForce(new Vector3(-0.35f, 0f, 0f), ForceMode.Impulse);
        bdr.openedDoor2 = false;
    }


}
