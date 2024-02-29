using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ColorChange : MonoBehaviour
{
    TMP_Text Text;
    Color32 RGB = new Color32(255, 255, 0,255);
    int colorindex = 1;
    int max = 0;
    bool plusminus = true;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TMP_Text>();
        Text.color = RGB;
        //StartCoroutine(ColorChanging());
    }


    IEnumerator ColorChanging()
    {
        while (true)
        {
            if (!plusminus)
            {
                switch (colorindex)
                {
                    case 0:
                        RGB.r++;
                        break;
                    case 1:
                        RGB.g++;
                        break;
                    case 2:
                        RGB.b++;
                        break;

                }
            }
            else
            {
                switch (colorindex)
                {
                    case 0:
                        RGB.r--;
                        break;
                    case 1:
                        RGB.g--;
                        break;
                    case 2:
                        RGB.b--;
                        break;

                }
            }
            max++;
            if(max == 255)
            {
                if(colorindex == 2)
                {
                    colorindex = 0;
                }
                else
                {
                    colorindex++;
                }
                plusminus = !plusminus;
                max = 0;
            }

            Text.color = RGB;

            yield return new WaitForFixedUpdate();

        }
    }


    private void FixedUpdate()
    {
        if (!plusminus)
        {
            switch (colorindex)
            {
                case 0:
                    RGB.r++;
                    break;
                case 1:
                    RGB.g++;
                    break;
                case 2:
                    RGB.b++;
                    break;

            }
        }
        else
        {
            switch (colorindex)
            {
                case 0:
                    RGB.r--;
                    break;
                case 1:
                    RGB.g--;
                    break;
                case 2:
                    RGB.b--;
                    break;

            }
        }
        max++;
        if (max == 255)
        {
            if (colorindex == 2)
            {
                colorindex = 0;
            }
            else
            {
                colorindex++;
            }
            plusminus = !plusminus;
            max = 0;
        }

        Text.color = RGB;

    }

    // Update is called once per frame

}
