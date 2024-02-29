using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StartManager : MonoBehaviour
{
    Animator animator;
    public StageDatas[] Stages;
    int Level = 0;
    bool clicked = false;
    public bool Pressed = false;
    public TMP_Text text;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!clicked)
                {
                    Clicked();
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Pressed = false;
                animator.SetBool("Pressed", false);
            }
            float wheelInput = Input.GetAxis("Mouse ScrollWheel");
            if (wheelInput == 0.1f && Level != Stages.Length-1) 
            {
                Level++;
                Debug.Log("UP");
            }
            else if (wheelInput == -0.1f && Level != 0)
            {
                Level--;
                Debug.Log("DOWN");
            }
        }
        text.text = LatinNum();
        if (SceneManager.GetSceneByName("SceneManager").isLoaded)
        {
            SceneManage SCENE = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
            SCENE.SetScene(Stages[Level].StageName, Stages[Level].FloorNames, Stages[Level].SceneNames, Stages[Level].isitblank);
            SCENE.StartLoad(Stages[Level].MusicIndex);
            SceneManager.UnloadSceneAsync("Mainmenu");
        }
    }

    void Clicked()
    {
        clicked = false;
        SceneManager.LoadScene("SceneManager", LoadSceneMode.Additive);
        
    }

    string LatinNum()
    {
        string LatinNums = "STAGE ";
        int defLev = Level+1;
        while(defLev/10 > 0)
        {
            defLev -= 10;
            LatinNums += "X";
        }
        switch (defLev) {
            case 1:
                LatinNums += "I";
                break;
            case 2:
                LatinNums += "II";
                break;
            case 3:
                LatinNums += "III";
                break;
            case 4:
                LatinNums += "IV";
                break;
            case 5:
                LatinNums += "V";
                break;
            case 6:
                LatinNums += "VI";
                break;
            case 7:
                LatinNums += "VII";
                break;
            case 8:
                LatinNums += "VIII";
                break;
            case 9:
                LatinNums += "IX";
                break;
        }
        return LatinNums;
    }
    
}

