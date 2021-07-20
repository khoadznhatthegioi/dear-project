using System.Collections; 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ExamineSystem;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour { 

    public InventoryObject inventory;
    public GameObject firstSavedObject;
    public GameObject violin;
    public GameObject denTv;
    public GameObject video;
    public GameObject fifthSavedObject;
    public GameObject labua;
    public GameObject nha;
    public GameObject cua;
    public GameObject nhungThuBenKia;
    public BasicDoorRaycast basicDoorRaycast;
    public InventoryObject inventoryObject;
    public GameObject violinStandCollider;
    public GameObject violinBieuDien;
    public GameObject diary;
    public GameObject fpsController;
    public FirstPersonController fpsc;
    //public DisplayInventory displayInventory;
    public SaveSystem saveSystem;
    public static bool isAlarmTurnedOff;
    public static bool check1;
    public static bool check2;
    public static bool check3;
    public static bool check4;
    public static bool check5= false;
    public static bool check6;
    public static bool check7;
    public static bool check8;
    public static bool check9;
    public static bool check11;
    public static bool check12;
    public static bool check13;
    public static bool check14;
    public static bool check15;
    public static bool check16;
    public static bool check17;
    public static bool check10;
    public static bool check20;
    public static bool check21;
    public static bool check22;
    public static bool qv;
    public GameObject panel1;


    public static bool isRight;
    [Header("Documents")]
    public GameObject[] documents;

    [Header("LoadingScreen")]
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject imageLoading;
    ImageLoading im;
    PlayerData data;
    // [SerializeField] public PlayerData playerData;
 
    private void Update()
    {
        if (!imageLoading)
        {
            if (Resources.FindObjectsOfTypeAll<ImageLoading>().Length>0)
            {
                im = Resources.FindObjectsOfTypeAll<ImageLoading>()[0];
                imageLoading = im.gameObject;
            }
                
        }
        if ( isRight == true || qv == true)
        {
            if (panel1)
            {
                panel1.SetActive(true);
                
                
            }
            
        }
        if(SaveSystem.isNewGame == false && check10 == false)
        {
            if(panel1)
            panel1.SetActive(true);
            
        }
        if(check1 == false)
        {
            if (PlayerData.firstSaved == true)
            {
                inventoryObject.Save();
                saveSystem.Save();
                if (DisplayInventory.sceneLoaded == false && check11 == false)
                {
                    //SceneManager.LoadSceneAsync("level1");
                    StartCoroutine(LoadAsynchronously("level1"));

                    
                    check11 = true;
                }
                
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);
                    if (firstSavedObject)
                        firstSavedObject.SetActive(false);
                    if (violin)
                        violin.SetActive(true);
                    if (denTv)
                        denTv.SetActive(true);
                    if (PlayerData.secondSaved == false && PlayerData.thirdSaved == false && PlayerData.fourthSaved == false && PlayerData.fifthSaved == false && PlayerData.sixthSaved == false && PlayerData.seventhSaved == false && DisplayInventory.sceneLoaded == false)
                    {
                        //fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(1, 0.88f, -2);
                        StartCoroutine(w());
                        IEnumerator w()
                        {
                            yield return new WaitForSeconds(0.1f);
                            //fpsc.enabled = true; 
                        }
                    }
                    check1 = true;
                }
                
               
                
            }
        }
        
        if(check2 == false)
        {
            if (PlayerData.secondSaved == true)
            {
                
                inventoryObject.Save();
                saveSystem.Save();
                if(DisplayInventory.sceneLoaded1 == false && check12 == false)
                {



                    //panel1.SetActive(true);
                    //SceneManager.LoadScene("level1");
                    StartCoroutine(LoadAsynchronously("level1"));
                    check12 = true;
                }
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);
                    //cac poster xuat hien,........
                    if(violin)
                    violin.SetActive(false);
                    if(violinStandCollider)
                    violinStandCollider.SetActive(false);
                    if(diary)
                    diary.SetActive(true);
                    if(PlayerData.thirdSaved == false && PlayerData.fourthSaved == false && PlayerData.fifthSaved == false && PlayerData.sixthSaved == false && PlayerData.seventhSaved == false && DisplayInventory.sceneLoaded1 == false)
                    {
                        //fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(1, 0.88f, 11);
                        StartCoroutine(w());
                        IEnumerator w()
                        {
                            yield return new WaitForSeconds(0.1f);
                            //fpsc.enabled = true; 
                        }
                    }
                    check2 = true;
                }
                
            }
        }
        
        if(check3 == false)
        {
            if (PlayerData.thirdSaved == true)
            {
                //Debug.Log("ASDJsakjdsklajdklsajdsklajdklasjdsklajdklsajdsklajdkslajdiowqdjiojdskajdwi");
                inventoryObject.Save();
                saveSystem.Save();
                if(DisplayInventory.sceneLoaded2 == false && check13 == false)
                {


                    //panel1.SetActive(true);
                    StartCoroutine(LoadAsynchronously("level1"));
                    check13 = true;
                }
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);

                    if (video && PlayerData.fourthSaved == false && DisplayInventory.videoLoaded == false)

                    {
                        //fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(1, 0.88f, 5);
                        video.SetActive(true);
                        if (diary)
                            Destroy(diary);
                        if (violinBieuDien)
                            violinBieuDien.SetActive(true);
                        StartCoroutine(w());

                        IEnumerator w()
                        {
                            yield return new WaitForSeconds(55f);
                            //fpsc.enabled = true;

                            Destroy(video);
                            check3 = true; 
                        }
                    }
                    else
                    {
                        check3 = true; 
                    }
                        
                    
                    
                    
                }
                //avideo.SetActive(true);
                //nhu o second, cac poster xuat hien, nhung co nhung canh sau khi video bat
                
            }
        }

        if(check4 == false)
        {
            if(PlayerData.fourthSaved == true)
            {
                //panel1.SetActive(true);
                //dung cai khac de lam cutscene dau level3
                StartCoroutine(LoadAsynchronously("level3"));
                inventoryObject.Save();
                saveSystem.Save();
                check4 = true;
            }
        }

        if(check5 == false)
        {
            if (PlayerData.fifthSaved == true)
            {
                
                inventoryObject.Save();
                saveSystem.Save();
                if (fifthSavedObject)
                    fifthSavedObject.SetActive(false);
                if (DisplayInventory.sceneLoaded3 == false && check14 == false)
                {


                    //panel1.SetActive(true);
                    StartCoroutine(LoadAsynchronously("level3"));
                    check14 = true;
                }
                StartCoroutine(w());
                IEnumerator w()
                {
                    yield return new WaitForSeconds(2f);
                    if (PlayerData.sixthSaved == false && PlayerData.seventhSaved == false && DisplayInventory.sceneLoaded3 == false)
                    {

                       // fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(-4, 0.88f, -1);
                        StartCoroutine(w1());
                        IEnumerator w1()
                        {
                            yield return new WaitForSeconds(0.1f);
                            //fpsc.enabled = true;
                        }
                        if (labua)
                            labua.SetActive(true);
                        check5 = true;
                    }
                    else check5 = true;
                    

                    
                    
                }
            }
        }

        if(check6 == false)
        {
            if(PlayerData.sixthSaved == true)
            {
                inventoryObject.Save();
                saveSystem.Save();
                if (BasicDoorRaycast.sceneLoaded1 == false && check15 == false)
                {


                    //panel1.SetActive(true);
                    StartCoroutine(LoadAsynchronously("level3"));
                    SceneManager.LoadSceneAsync("Zoo", LoadSceneMode.Additive);
                    check15 = true;
                }
                StartCoroutine(w());
                IEnumerator w()
                {
                    yield return new WaitForSeconds(2f);
                    if (nha)
                        nha.SetActive(false);
                    if (cua)
                        cua.SetActive(false);
                    if (PlayerData.seventhSaved == false && BasicDoorRaycast.sceneLoaded1 == false)
                    {
                        //fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(1, 0.88f, 6);
                        StartCoroutine(w1());
                        IEnumerator w1()
                        {
                            yield return new WaitForSeconds(0.1f);
                            //fpsc.enabled = true;
                            check6 = true;
                        }
                    }
                    
                    else check6 = true;
                }
               
                
                   
                
            }
        }

        if(check7 == false)
        {
            if (PlayerData.usedAmulet == true)
            {
                inventoryObject.Save();
                saveSystem.Save();
                check7 = true;
            }
        }

        if(check8 == false)
        {
            if(PlayerData.wasntAbleToEscapeFromQuaiVat == true)
            {
                inventoryObject.Save();
                saveSystem.Save();
                check8 = true;
            }
        }
        if(check9 == false)
        {
            if(PlayerData.seventhSaved == true)
            {
                inventoryObject.Save();
                saveSystem.Save();
                StartCoroutine(WaitSceneLoad4());
                if (BasicDoorRaycast.sceneLoaded2 == false)
                {
                    if(check16 == false)
                    {

                        //panel1.SetActive(true);
                        SceneManager.LoadSceneAsync("level4", LoadSceneMode.Additive);
                        check16 = true;
                    }
                    if(check17 == false)
                    {
                        StartCoroutine(w1());
                        IEnumerator w1()
                        {
                            yield return new WaitForSeconds(0.3f);

                            SceneManager.UnloadSceneAsync("Zoo", UnloadSceneOptions.None);
                            check17 = true;
                        }
                    }
                   
                }
                IEnumerator WaitSceneLoad4()
                {
                    yield return new WaitForSeconds(2f);
                    if (BasicDoorRaycast.sceneLoaded2 == false)
                    {
                        //fpsc.enabled = false;
                        fpsController.transform.position = new Vector3(1, 0.88f, 6);
                        
                        StartCoroutine(w());
                        IEnumerator w()
                        {
                            yield return new WaitForSeconds(0.1f);
                            //fpsc.enabled = true;
                            nhungThuBenKia.SetActive(false);
                            check9 = true;
                            
                        }

                    }
                    else
                    {
                        //nhungThuBenKia.SetActive(false);
                        check9 = true;
                    }
                }
                
                
            }
        }

        if (check20 == false)
        {
            if (PlayerData.eighthSaved == true)
            {
                //panel1.SetActive(true); 
                SceneManager.LoadScene("level5");
                inventoryObject.Save();
                saveSystem.Save();
                check20 = true;
            }
        }
        if(check21 == false)
        {
            if(PlayerData.document1 == true)
            {
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);
                    documents[0].SetActive(true);
                }
            }
        }

        if(check22 == false)
        {
            if(PlayerData.document2 == true)
            {
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);
                    documents[1].SetActive(true);
                }
            }
        }
       

    }
    public void SavePlayer()
    {
        Debug.Log("saysth");
        
        
    }

    public void LoadPlayer()
    {
        //SaveSystem.Load();
        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;
        saveSystem.Load();
        inventoryObject.Load();
    }
    public IEnumerator LoadAsynchronously(string sceneName)
    {

        imageLoading.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            //float progress = Mathf.Clamp01(operation.progress / .9f);
            //slider.value = progress;
        //    imageLoading.SetActive(true);
            yield return null;
        }
    }
    //public static PlayerStats instance;

    


    public IEnumerator LoadAsynchronouslyAdditive(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        if (operation.isDone)
        {
            loadingScreen.SetActive(false);
        }
    }

    public IEnumerator LoadUnloadAsynchronously(string sceneNameLoad, string sceneNameUnload)
    {
        AsyncOperation operation1 = SceneManager.LoadSceneAsync(sceneNameLoad, LoadSceneMode.Additive);
        AsyncOperation operation2 = SceneManager.UnloadSceneAsync(sceneNameUnload);

        while(!operation1.isDone && !operation2.isDone)
        {
            float progress = Mathf.Clamp01((operation1.progress + operation2.progress) / .9f);
            slider.value = progress;
            yield return null;
        }
        if (operation1.isDone && operation2.isDone)
        {
            loadingScreen.SetActive(false);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[6];
    }
}
