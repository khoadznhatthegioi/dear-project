using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    float y;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        y = door.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
