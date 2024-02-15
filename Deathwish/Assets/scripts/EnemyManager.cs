using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Count = 0;
    bool clear = false;
    ExitManager Exit;
    void Start()
    {
        Count = transform.childCount;
        Debug.Log(Count);
        Exit = GameObject.FindWithTag("ExitManager").GetComponent<ExitManager>();
    }

    // Update is called once per frame

    public void Kill()
    {
        Count--;
        if (Count == 0)
        {
            Debug.Log("Clear");
            clear = true;
            Exit.goCheck();
        }
    }
    public void playerDead()
    {
        clear = false;
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
