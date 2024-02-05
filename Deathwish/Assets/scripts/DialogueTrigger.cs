using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialouge[] Diag;
    
    [Header("LoadScene")]
    public bool LoadScene;
    public string[] SceneName;
    public string[] FloorName;
    public string StageName;
    public int MusicIndex;

    public void TriggerDialogue()
    {
        DialogueManager Manager = GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>();
        Manager.RecieveDialogue(Diag);
        if (LoadScene) {
            Manager.setLoadStatus(SceneName,SceneName,StageName,MusicIndex);
        }
    }
}
