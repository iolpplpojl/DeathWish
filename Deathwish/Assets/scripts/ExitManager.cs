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
    exitdirect exitdirect;
    SceneManage bar;
    Restart RestartManager;
    bool exitdirected = false;
    private void Start()
    {
         bar = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
         RestartManager = GameObject.FindWithTag("RestartManager").GetComponent<Restart>();
         exitdirect = GameObject.FindWithTag("exitdirect").GetComponent<exitdirect>();
    }
    public void goCheck()
    {
        if (EnemyCheck() && ItemCheck())
        {
            if (bar.LastScene - 1 == bar.NowScene)
            {
                DownExit.gameObject.SetActive(true);
                exitdirect.direction(DownExit.transform);
                exitdirected = true;

            }
            else
            {
                Exit.gameObject.SetActive(true);
                exitdirect.direction(Exit.transform);
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
        exitdirect.exited();

    }

    public void GoNext()
    {
        exitdirect.exited();
        DownExit.gameObject.SetActive(true);
        exitdirect.downdirectionadd(DownExit.transform);
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
