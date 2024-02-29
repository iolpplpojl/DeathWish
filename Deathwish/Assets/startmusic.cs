using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    // Start is called before the first frame update

    MusicManager manager;
    void Start()
    {
        manager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();
        manager.ChangeIndex(3);
    }

    // Update is called once per frame

}
