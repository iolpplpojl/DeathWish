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

        // �ν��Ͻ��� �̹� �ִ� ��� ������Ʈ ����
        else if (instance != this)
            Destroy(gameObject);

        // �̷��� �ϸ� ���� scene���� �Ѿ�� ������Ʈ�� ������� �ʽ��ϴ�.
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
