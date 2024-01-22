using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultUI : MonoBehaviour
{
    // Start is called before the first frame update
    ScoreManager scoreManager;
    SceneManage SceneManage;
    Text txt1;
    Text txt2;
    void Start()
    {
        txt1 = transform.GetChild(1).GetComponent<Text>();
        txt2 = transform.GetChild(2).GetComponent<Text>();

        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.DoScore();
        SceneManage = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
        GameObject.FindWithTag("StopManager").GetComponent<StopManager>().changebool(true);
        txt1.text = scoreManager.GetScore().ToString();

        if (PlayerPrefs.GetInt(SceneManage.GetNowStage()) < scoreManager.GetScore())
        {
            PlayerPrefs.SetInt(SceneManage.GetNowStage(), scoreManager.GetScore());
            Debug.Log("new High Score!");
            Debug.Log(scoreManager.GetScore());
            txt2.text = string.Format("new High Score!: \n{0} pts", PlayerPrefs.GetInt(SceneManage.GetNowStage()).ToString());

        }
        else
        {
            txt2.text = string.Format("High Score: \n{0} pts", PlayerPrefs.GetInt(SceneManage.GetNowStage()).ToString());

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Mainmenu"); 
        }
    }
}
