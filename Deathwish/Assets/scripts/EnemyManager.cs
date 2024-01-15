using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Count = 0;
    bool clear = false;
    void Start()
    {
        Count = transform.childCount;
        Debug.Log(Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Kill()
    {
        Count--;
        if (Count == 0)
        {
            Debug.Log("Clear");
            clear = true;
            SceneManage bar = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
            if (bar.LastScene-1 == bar.NowScene)
            {
                GameObject.FindWithTag("DownExit").transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public bool Getclear()
    {
        return clear;
    }
    public void SetEnemy()
    {
        for (int i = 0; i < Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
