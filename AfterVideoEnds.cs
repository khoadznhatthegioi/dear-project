using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterVideoEnds : MonoBehaviour
{
    public GameObject video;
    public GameObject player;
    public GameObject cameraPhu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitForVideoToEnd());
    }
    IEnumerator waitForVideoToEnd()
    {
        yield return new WaitForSeconds(31f);
        video.SetActive(false);
        player.SetActive(true);
        cameraPhu.SetActive(false);
    }
}
