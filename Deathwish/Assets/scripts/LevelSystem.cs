using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level1") > 0)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Scene1") > 0)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
