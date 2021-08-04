
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CheckBool : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    public FirstPersonController fpsc;
    //public static GameObject imageLoading;
    public static bool doneLoading;
    public static bool isBuffering;
    public void DoneLoading()
    {
        doneLoading = true;
    }
    public void Check10On()
    {
        PlayerStats.check10 = true;

        isBuffering = false;
        PlayerStats.isRight = false;
        PlayerStats.qv = false;
        //imageLoading.SetActive(false);
        playerStats.panel1.SetActive(false);
        
    }
    public void CheckBol()
    {
        isBuffering = true;
        fpsc.enabled = false;
    }
    public void CheckBol1()
    {
        fpsc.enabled = true;
    }
}

