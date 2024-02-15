using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Exit;
    public GameObject DownExit;
    public EnemyManager Enemy;
    public item item;
    SceneManage bar;
    Restart RestartManager;

    private void Start()
    {
         bar = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
         RestartManager = GameObject.FindWithTag("RestartManager").GetComponent<Restart>();
    }
    public void goCheck()
    {
        if (EnemyCheck() && ItemCheck())
        {
            if (bar.LastScene - 1 == bar.NowScene)
            {
                DownExit.gameObject.SetActive(true);
            }
            else
            {
                Exit.gameObject.SetActive(true);
            }
        }
    }

    public void Death()
    {
        if (DownExit != null)
        {
            DownExit.gameObject.SetActive(false);
        }
        if (Exit != null)
        {
            Exit.gameObject.SetActive(false);
        }
    }

    public void GoNext()
    {
        DownExit.gameObject.SetActive(true);
    }
    bool EnemyCheck()
    {
        if(Enemy == null)
        {
            return true;
        }
        else
        {
            if(Enemy.Getclear() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    bool ItemCheck()
    {
        if(item == null)
        {
            return true;
        }
        else
        {
            return item.ItemUsedCheck();
        }
    }
}
