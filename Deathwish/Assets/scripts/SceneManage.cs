using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check;
    public int LastScene = 1;
    public int NowScene = 1;
    public int LoadingScene = 1;
    public bool Loading;
    Restart Restart;
    public string[] FloorNames;
    public GameObject[] Floors = {null,null};
    int FloorIndexs = 0;
    void Start() {
        Restart = GameObject.FindWithTag("RestartManager").GetComponent<Restart>();

        Floors[FloorIndexs] = GameObject.Find(FloorNames[FloorIndexs]);

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && NowScene == 1 && Restart.GetDeath() == true)
        {
            if (SceneManager.GetSceneByName("Scene1").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Scene1");
            }
            SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
            Loading = true;
            LoadingScene = 1;
        }

        if (LoadingScene == 1 && Loading == true && SceneManager.GetSceneByName("Scene1").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
            Floors[FloorIndexs] = GameObject.Find(FloorNames[FloorIndexs]);
            Debug.Log(Floors[FloorIndexs]);

            check = false;
            Loading = false;
        }


        if (Input.GetKeyDown(KeyCode.F) && NowScene == 2)
        {
            if (SceneManager.GetSceneByName("Scene2").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Scene2");
            }
            SceneManager.LoadScene("Scene2", LoadSceneMode.Additive);
            Loading = true;
            LoadingScene = 2;
        }

        if (LoadingScene == 2 && Loading == true && SceneManager.GetSceneByName("Scene2").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene2"));
            check = false;
            Loading = false;
            Floors[FloorIndexs] = GameObject.Find(FloorNames[FloorIndexs]);
            Debug.Log(Floors[FloorIndexs]);

        }
        if (check == true)
        {
            goBackFloor();
            check = false;
        }

    }
    public void goNextFloor()
    {
        Floors[0].SetActive(false);
        SceneManager.LoadScene("Scene2", LoadSceneMode.Additive);
        FloorIndexs++;
        Loading = true;
        LoadingScene = 2;
        NowScene++;
    }
    public void goBackFloor()
    {

        Floors[1].SetActive(false);
        Floors[0].SetActive(true);

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