using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text DialogueText;
    Animator animator;
    private Queue<string> words;


    bool LoadCheck;
    string[] SceneName;
    string[] FloorName;
    string StageName;
    int MusicIndex;


    public Dialouge[] Digs;
    public int DialogueLength;
    public int DialogueIndex;
    public bool DialogueOpened;
    private IEnumerator OpenCourtine;
    private IEnumerator DeadCourtine;
    void Start()
    {
        OpenCourtine = WaitUntilAnimOpen();
        DeadCourtine = WaitUntilAnimDead();
        words = new Queue<string>();
        animator = GetComponentInChildren<Animator>();
        DialogueOpened = false;
    }

    // Update is called once per frame

    public void RecieveDialogue(Dialouge[] Dig)
    {
        DialogueLength = Dig.Length;
        Digs = Dig;
        DialogueIndex = 0;
        StartDialogue(Digs[DialogueIndex]);
    }
    public void setLoadStatus(string[] SceneName, string[] FloorName,string StageName,int MusicIndex)
    {
        LoadCheck = true;
        this.SceneName = SceneName;
        this.FloorName = FloorName;
        this.StageName = StageName;
        this.MusicIndex = MusicIndex;
    }
    public void StartDialogue(Dialouge Dig)
    {
        Debug.Log("Start With" + Dig.name);
        words.Clear();
        foreach (string sentence in Dig.words)
        {
            words.Enqueue(sentence);
        }
        DialogueText.text = words.Dequeue();
        StartCoroutine(OpenCourtine);
        animator.SetBool("IsOpen", true);
        DialogueIndex++;
    }

    public void NextDialogue()
    {
        if (words.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (DialogueOpened == true)
        {
            DialogueText.text = words.Dequeue();
        }


    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("³¡³µ´Ù°í");
        if (DialogueIndex < DialogueLength)
        {
            Debug.Log("NewDIg");
            StartCoroutine(DeadCourtine);
        }
        else
        {
            if (LoadCheck)
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("LoadingDataScene",LoadSceneMode.Additive);
        StartCoroutine(LoadSceneCheck());
    }
    IEnumerator LoadSceneCheck()
    {
        bool LoadDone = false;
        while (LoadDone == false)
        {
            if (SceneManager.GetSceneByName("LoadingDataScene").isLoaded)
            {
                LoadingDataSender SCENE = GameObject.FindWithTag("LoadingDataScene").GetComponent<LoadingDataSender>();
                for(int i = 0; i<SceneManager.sceneCount; i++)
                {
                    Scene scene = SceneManager.GetSceneAt(i);
                    if(scene.name != "LoadingDataScene" && scene.name != "PlayLogicScene")
                    {
                        SceneManager.UnloadSceneAsync(scene);       
                    }
                }
                SCENE.SetScene(StageName, FloorName, SceneName, MusicIndex);
                SceneManager.UnloadSceneAsync("PlayLogicScene");

                LoadDone = true;
            }
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator WaitUntilAnimDead()
    {
        Debug.Log("WiatUntil2");
        while(true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DialogueClose"))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    Debug.Log("DialogueClosed");
                    DialogueOpened = false;
                    StartDialogue(Digs[DialogueIndex]);
                    StopCoroutine(DeadCourtine);
                }
            }
            Debug.Log("WiatUntil");
            yield return new WaitForSeconds(0.05f);
        }                                                                       
    }
    IEnumerator WaitUntilAnimOpen()
    {
        while(true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DialogueOpen"))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    Debug.Log("DialogueOpened");
                    DialogueOpened = true;
                    StopCoroutine(OpenCourtine);
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
