using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public FirstPersonController movement;
    public GameObject player;
    public GameObject gameOverMenu;
    public GameObject quaiVat;
    public TriggerQuaiVat triggerQuaiVat;
    public GameObject ban;
    [SerializeField] PlayerStats playerStats;
    //public CheckQuaiVat checkQuaiVat;
    //public GameObject backGround;
    public bool aBool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuaiVat"))
        {
            movement.enabled = false;
            PlayerData.wasntAbleToEscapeFromQuaiVat = true;
            StartCoroutine(Waiter());

            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(5f);
                //gameOverMenu.SetActive(true);
                StartCoroutine(playerStats.LoadAsynchronously("level4"));
                PlayerStats.qv = true;
                //backGround.SetActive(true);
                aBool = true;
            }
        }
    }

//void OnTriggerEnter()
    //{
        
    //}

    

    public void RetryButton()
    {
        aBool = true;
        //gameOverMenu.SetActive(false);
        //backGround.SetActive(true);
    }

    public void Update()
    {
        if (aBool == true)
        {
            //ban.SetActive(true);
            //player.transform.position = new Vector3(0, 1, 7);
            //triggerQuaiVat.isQuaiVatAwake = false;
            //quaiVat.SetActive(false);
            //StartCoroutine(Waiter1());
            //IEnumerator Waiter1()
            //{
            //    yield return new WaitForSeconds(5f);
            //    movement.enabled = true;
            //    aBool = false;
            //}
           
        }
            
    }

}
