using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicManager instance = null;

    public AudioClip[] Music;
    AudioSource PlayMusic;
    public int MusicIndex;
    public bool Go;
    void Start()
    {
        if (instance == null)
            instance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        DontDestroyOnLoad(gameObject);

        PlayMusic = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Go == true)
        {
            Play();
            Go = false;
        }
    }
    void Play()
    {
        PlayMusic.clip = Music[MusicIndex];
        PlayMusic.Play();
    }
}
