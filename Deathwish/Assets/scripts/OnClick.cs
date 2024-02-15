using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class OnClick : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public string[] FloorNames;
    public string[] SceneNames;
    public string StageName;
    public int buttonindex;
    public int MusicIndex;
    int onbutton;
    public bool isitblank;
    //public Datas[] Mapdata;
  //  public int index;
  //  [Serializable]
  //  public struct Datas {
  //      public string[] FloorNames;
   //     public string[] SceneNames;
    //}

    public void Clicked()
    {
        SceneManager.LoadScene("SceneManager", LoadSceneMode.Additive);
        onbutton = buttonindex;
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName("SceneManager").isLoaded && onbutton == buttonindex)
        {
            SceneManage SCENE = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
            SCENE.SetScene(StageName,FloorNames, SceneNames,isitblank);
            SCENE.StartLoad(MusicIndex);
            SceneManager.UnloadSceneAsync("Mainmenu");
        }
    }
}
