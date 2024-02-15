using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingDataSender : MonoBehaviour
{
    // Start is called before the first frame update

    public void SetScene(string StageName, string[] FloorName, string[] SceneName, int MusicIndex,bool isitblank)
    {
        SceneManager.LoadScene("SceneManager",LoadSceneMode.Additive);
        StartCoroutine(LoadSceneCheck(StageName, FloorName, SceneName, MusicIndex,isitblank));

    }
    IEnumerator LoadSceneCheck(string StageName, string[] FloorName, string[] SceneName, int MusicIndex, bool isitblank)
    {
        bool LoadDone = false;
        while (LoadDone == false)
        {
            if (SceneManager.GetSceneByName("SceneManager").isLoaded)
            {
                SceneManage SCENE = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
                SCENE.SetScene(StageName, FloorName, SceneName,isitblank);
                SCENE.StartLoad(MusicIndex);
                LoadDone = true;
                SceneManager.UnloadSceneAsync("LoadingDataScene");
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
