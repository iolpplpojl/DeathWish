using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    int Score;
    int MidScore;
    float Combo;
    int WeaponDIff = 8;
    int WhileCombo;
    bool gocombo;
    Restart Restart;
    void Start()
    {
        Score = 0;
        Restart = GameObject.FindWithTag("RestartManager").GetComponent<Restart>();
        MidScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Combo > 0)
        {
            Combo -= Time.deltaTime;
        }
        else if (gocombo == true)
        {
            Scoring();
        }
        if (Input.GetKeyDown(KeyCode.F) && Restart.GetDeath()==true)
        {
           Combo = 0;
           WhileCombo = 0;
           gocombo = false;
           Score = MidScore;
        }
    }
    public int GetScore()
    {
        return Score;
    }
    public void Kill()
    {
        gocombo = true;
        Score += (1000*WeaponDIff)/10;
        Combo = 1.5f;
        WhileCombo++;
    }
    public void GetAmmo()
    {
        if (gocombo == true)
        {
            Score += 200;
            Combo += 0.2f;
        }
    }
    void Scoring()
    {
        gocombo = false;
        int mScore = 300;
        for (int i = 1; i<WhileCombo; i++)
        {
            mScore = (mScore*13)/10;
        }
        Score += (mScore/10)*10;
        WhileCombo = 0;
    }
    public void DoScore()
    {
        if (gocombo == true)
        {
            Scoring();
        }
    }
    public float GetCombo()
    {
        return Combo;
    }
    public void Checkpoint()
    {
        if(gocombo == true)
        {
            Scoring();
        }
        Combo = 0;
        WhileCombo = 0;
        gocombo = false;
        MidScore = Score;
    }
}
