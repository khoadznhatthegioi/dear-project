using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NewGame : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Button continueButton;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!File.Exists($"{Application.persistentDataPath}/save.dchanthavy"))
        {
            continueButton.interactable = false;
        }
        else { continueButton.interactable = true; }
    }
    public void NewGameButton()
    {
        SaveSystem.isNewGame = true;
        StartCoroutine(playerStats.LoadAsynchronously("level0"));
    }
}
