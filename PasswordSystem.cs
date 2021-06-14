using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExamineSystem;
using UnityEngine.SceneManagement;
using System.Linq;

public class PasswordSystem : MonoBehaviour
{

  

    [SerializeField] InventoryDisappear inventoryDisappear;
    [SerializeField] int[] password1 = { 3, 4, 5, 3, 2, 1 };
    static int[] _password1 = { 0, 0, 0, 0, 0, 0 };

    //int j = 5;
    //violin



    //FUNCTION FOR PASSWORD!
    public void Number3()
    {
        for(int i = 0; i < _password1.Length; i++)
        {
            if(_password1[i] == 0)
            {
                _password1[i] = 3;
                break;
            }
        }
    }
    public void Number4()
    {
        for (int i = 0; i < _password1.Length; i++)
        {
            if (_password1[i] == 0)
            {
                _password1[i] = 4;
                break;
            }
        }
    }
    public void Number5()
    {
        for (int i = 0; i < _password1.Length; i++)
        {
            if (_password1[i] == 0)
            {
                _password1[i] = 5;
                break;
            }
        }
    }
    public void Number2()
    {
        for (int i = 0; i < _password1.Length; i++)
        {
            if (_password1[i] == 0)
            {
                _password1[i] = 2;
                break;
            }
        }
    }
    public void Number1()
    {
        for (int i = 0; i < _password1.Length; i++)
        {
            if (_password1[i] == 0)
            {
                _password1[i] = 1;
                break;
            }
        }
    }

    //public static bool checkEquality<T>(T[] first, T[] second)
    //{
    //    return Enumerable.SequenceEqual(first, second);
    //}

    private void Update()
    {
        ////if(_password1[j] != 0)
        ////{
        ////    if (checkEquality(password1, _password1))
        ////    {
        //        //do something
        //        var position = inventoryDisappear.rectTransform.position;
        //        position.x = 6666;
        //        inventoryDisappear.rectTransform.position = position;
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Cursor.visible = false;
        //        inventoryDisappear.blur.enabled = false;
        //        inventoryDisappear.bgi.SetActive(false);
        //        inventoryDisappear.crosshair.enabled = true;
        //        inventoryDisappear.player.enabled = true;
        //        Time.timeScale = 1f;
        //        inventoryDisappear.blurOut.SetActive(false);
        //        (inventoryDisappear.mainCam.GetComponent(inventoryDisappear.examineRay) as MonoBehaviour).enabled = true;
        //        inventoryDisappear.isInventoryAlreadyOn = false;
        //        PlayerData.nhinViolinStand = false;
        //        inventoryDisappear.violinUi.SetActive(false);
        //        inventoryDisappear.violinBdCollider.enabled = false;
        //        //animation for violin bieu dien
        //        //amimation cho du thu
        //        //ngat xiu
        //        StartCoroutine(sauKhiNgatXiu());

        //        IEnumerator sauKhiNgatXiu()
        //        {
        //            yield return new WaitForSeconds(10f); //tam thoi la vay, sau khi lam hoan chinh se thay doi sau
        //            SceneManager.LoadScene("level3");
        //            PlayerData.fourthSaved = true;
        //        }
        //    }
        //}
        if((_password1[0] != password1[0] && _password1[0] != 0) || (_password1[1] != password1[1] && _password1[1] != 0) || (_password1[2] != password1[2] && _password1[2] != 0) || (_password1[3] != password1[3] && _password1[3] != 0) || (_password1[4] != password1[4] && _password1[4] != 0) || (_password1[5] != password1[5] && _password1[5] != 0))
        {
            Initialize(_password1);
        }
        if(_password1[5] == 1)
        {
               //do something
            var position = inventoryDisappear.rectTransform.position;
            position.x = 6666;
            inventoryDisappear.rectTransform.position = position;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryDisappear.blur.enabled = false;
            inventoryDisappear.bgi.SetActive(false);
            inventoryDisappear.crosshair.enabled = true;
            inventoryDisappear.player.enabled = true;
            Time.timeScale = 1f;
            inventoryDisappear.blurOut.SetActive(false);
            (inventoryDisappear.mainCam.GetComponent(inventoryDisappear.examineRay) as MonoBehaviour).enabled = true;
            inventoryDisappear.isInventoryAlreadyOn = false;
            PlayerData.nhinViolinStand = false;
            inventoryDisappear.violinUi.SetActive(false);
            inventoryDisappear.violinBdCollider.enabled = false;
            //animation for violin bieu dien
            //amimation cho du thu
            //ngat xiu
            StartCoroutine(sauKhiNgatXiu());

            IEnumerator sauKhiNgatXiu()
            {
                yield return new WaitForSeconds(10f); //tam thoi la vay, sau khi lam hoan chinh se thay doi sau
                SceneManager.LoadScene("level3");
                PlayerData.fourthSaved = true;
            }
        }
    }

    public void Initialize(int[] password)
    {
        for(int i = 0; i < password.Length; i++)
        {
            password[i] = 0;
        }
    }
}
