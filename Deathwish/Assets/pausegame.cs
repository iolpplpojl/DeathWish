using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausegame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    bool ispaused = false;
    public StopManager stopManager;
    public GunSelect gunSelect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gunSelect.selected)
        {
            if (ispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }


    void pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        stopManager.stop = true;
        ispaused = true;
    }
    public void mainmenu()
    {
        Time.timeScale = 1f;
        stopManager.stop = false;
        ispaused = false;
    }
    void resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        stopManager.stop = false;
        ispaused = false;
    }
}
