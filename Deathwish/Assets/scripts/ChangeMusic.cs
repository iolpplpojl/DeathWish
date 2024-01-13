using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    MusicManager Music;
    void Start()
    {
        Music = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
