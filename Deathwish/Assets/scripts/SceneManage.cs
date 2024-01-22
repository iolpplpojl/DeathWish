using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    private void Update()
    {
        playerScene();
        if (Input.GetKey(KeyCode.F) && Restart.GetDeath() == true && Loading == false)
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
        yield return new WaitForFixedUpdate();
        if (SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded)
        {
            SceneManager.UnloadSceneAsync(Scenes[NowScene]);
        }
        yield return new WaitUntil(() => !SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded);
        SceneManager.LoadScene(Scenes[NowScene], LoadSceneMode.Additive);
        yield return new WaitUntil(() => SceneManager.GetSceneByName(Scenes[NowScene]).isLoaded);
        LoadingScene = NowScene;
        setActiveScene();

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
        check = false;
        Loading = false;
        //GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().SetEnemy();
    }
    void setRestartData()
    {
        GameObject.FindWithTag("Player").GetComponent<player>().SetPos();
        GameObject.FindWithTag("gun").GetComponent<GunFire>().SetAmmo();
        GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>().Checkpoint();
        RestartDataSeted = true;
    }
    public void goBackFloor()
    {

        if (FloorIndexs != 0)
        {
            Floors[FloorIndexs].SetActive(false);
            FloorIndexs--;
            Floors[FloorIndexs].SetActive(true);
        }
        else
        {
            Debug.Log("Clear!!!");
            SceneManager.LoadScene("ResultScreen", LoadSceneMode.Additive);

        }


    }
    public void StartLoad(int MusicIndex)
    {
        Debug.Log("AAA");
        SceneManager.LoadScene("PlayLogicScene", LoadSceneMode.Additive);
        SceneManager.LoadScene(Scenes[NowScene], LoadSceneMode.Additive);
        Loading = true;
        LoadingScene = 0;
        Music = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
        Music.ChangeIndex(MusicIndex);
        StartCoroutine(WaitLoad());

    }
    public void SetScene(string Stage,string[] Floors, string[] SceneNames)
    {
        NowStage = Stage;
        FloorNames = Floors;
        Scenes = SceneNames;
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