using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check;
    string NowStage;
    public int NowScene = 0;
    public int LoadingScene = 0;
    bool firstload = true;
    public bool Loading;
    Restart Restart;
    string[] FloorNames;
    GameObject[] Floors = {null,null,null,null};
    int FloorIndexs = 0;
    MusicManager Music;
    string[] Scenes;
    bool RestartDataSeted = false;
    public int LastScene;
    Image fadein;
    float fadein_A;
    bool isitblank;
    private void Start()
    {
        fadein = GetComponentInChildren<Image>();
        fadein_A = 1;
    }
    private void Update()
    {
        playerScene();
        if (Input.GetKeyDown(KeyCode.F) && Restart.GetDeath() == true && Loading == false)
        {
            Loading = true;
            RestartFloor();
        }

        //if (Loading == true && SceneManager.GetSceneByName(Scenes[LoadingScene]).isLoaded)
        //{
           // setActiveScene();
        //}

        if (check == true)
        {
            goBackFloor();
            check = false;
        }

    }
    public void goNextFloor()
    {
        FadeIn();
        Floors[FloorIndexs].SetActive(false);
        FloorIndexs++;
        Loading = true;
        NowScene++;
        LoadingScene = NowScene;
        SceneManager.LoadScene(Scenes[LoadingScene], LoadSceneMode.Additive);

        RestartDataSeted = false;
        StartCoroutine(WaitLoad());

    }

    void RestartFloor()
    {
        StartCoroutine(RestartFloorCR());
    }
    IEnumerator RestartFloorCR()
    {
        FadeIn();
        yield return new WaitForFixedUpdate();
        if (SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded)
        {
            SceneManager.UnloadSceneAsync(Scenes[NowScene]);
        }
        yield return new WaitUntil(() => !SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded);
        SceneManager.LoadScene(Scenes[NowScene], LoadSceneMode.Additive);
        yield return new WaitUntil(() => SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded);
        LoadingScene = NowScene;
        setActiveScene(true);

    }
    
    void FadeIn()
    {
        fadein.color = new Color(0, 0, 0, 1f);
        fadein_A = 1;
    }
    public float getFadeValue()
    {
        return fadein_A;
    }
    IEnumerator FadeOut()
    {
        while (fadein_A >= 0)
        {
            fadein_A -= 0.04f;
            fadein.color = new Color(0, 0, 0, fadein_A);
            yield return new WaitForFixedUpdate();
        }
    }

    public void goFadeIn()
    {
        StartCoroutine(FadeIn_Time());
    }

    IEnumerator FadeIn_Time()
    {
        while (fadein_A <= 1)
        {
            fadein_A += 0.06f;
            fadein.color = new Color(0, 0, 0, fadein_A);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator WaitLoad()
    {
        yield return new WaitUntil(() => SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded);
        setActiveScene();
    }
    void playerScene()
    {
        if (SceneManager.GetSceneByName("PlayLogicScene").isLoaded && firstload == true)
        {
            Debug.Log("Play");
            Restart = GameObject.FindWithTag("RestartManager").GetComponent<Restart>();
            firstload = false;
        }
    }
    void setActiveScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes[LoadingScene]));
        Floors[FloorIndexs] = GameObject.Find(FloorNames[FloorIndexs]);
        if (RestartDataSeted == false)
        {
            setRestartData();
        }
        StartCoroutine(FadeOut());
        check = false;
        Loading = false;
        //GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().SetEnemy();
    }
    void setActiveScene(bool ahah)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes[LoadingScene]));
        Floors[FloorIndexs] = GameObject.Find(FloorNames[FloorIndexs]);
        if (RestartDataSeted == false)
        {
            setRestartData();
        }
        StartCoroutine(FadeOut());
        check = false;
        Loading = false;
        Restart.Setinv();
        //GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().SetEnemy();
    }

    void setRestartData()
    {
        GameObject.FindWithTag("Player").GetComponent<player>().SetPos();
        if (!isitblank)
        {
            GameObject.FindWithTag("gun").GetComponent<GunFire>().SetAmmo();
        }
        GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>().Checkpoint();
        RestartDataSeted = true;
    }
    public void goBackFloor()
    {

        if (FloorIndexs != 0)
        {
            FadeIn();
            StartCoroutine(FadeOut());
            Floors[FloorIndexs].SetActive(false);
            FloorIndexs--;
            Floors[FloorIndexs].SetActive(true);
        }
        else
        {
            Debug.Log("Clear!!!");
            SceneManager.LoadScene("ResultScreen", LoadSceneMode.Additive);

        }
        exitdirect exitdirect = GameObject.FindWithTag("exitdirect").GetComponent<exitdirect>();
        exitdirect.downdirectionpop();

    }
    public void StartLoad(int MusicIndex)
    {
        Debug.Log("AAA");
        if (isitblank)
        {
            SceneManager.LoadScene("PlayLogicScene_Nohand", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("PlayLogicScene", LoadSceneMode.Additive);

        }
        SceneManager.LoadScene(Scenes[NowScene], LoadSceneMode.Additive);
        Loading = true;
        LoadingScene = 0;
        Music = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
        Music.ChangeIndex(MusicIndex);
        StartCoroutine(WaitLoad());

    }
    public void SetScene(string Stage,string[] Floors, string[] SceneNames,bool isitblank)
    {
        NowStage = Stage;
        FloorNames = Floors;
        Scenes = SceneNames;
        this.isitblank = isitblank;
        LastScene = Scenes.Length;

    }

    public string GetNowStage()
    {
        return NowStage;
    }
}


/* if (check && LastScene == 1 && Loading == false)
{
    SceneManager.UnloadSceneAsync("Scene1");
    SceneManager.LoadScene("Scene2", LoadSceneMode.Additive);
    Loading = true;

}
else if (check && LastScene == 1 && Loading == true && SceneManager.GetSceneByName("Scene2").isLoaded)
{
    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene2"));
    check = false;
    Loading = false;
    LastScene = 2;
}


if (check && LastScene == 2 && Loading == false)
{
    SceneManager.UnloadSceneAsync("Scene2");
    SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
    Loading = true;

}
else if (check && LastScene == 2 && Loading == true && SceneManager.GetSceneByName("Scene1").isLoaded)
{
    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
    check = false;
    Loading = false;
    LastScene = 1;
}

*/