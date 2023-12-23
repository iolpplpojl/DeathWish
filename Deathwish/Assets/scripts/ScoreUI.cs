using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    ScoreManager Score;
    Text M_Text;
    Slider M_Slider;
    void Start()
    {
        Score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        M_Text = transform.Find("Text").GetComponent<Text>();
        M_Slider = transform.Find("Slider").GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        M_Text.text = string.Format("{0}",Score.GetScore());
        M_Slider.value = Score.GetCombo();
    }


}
