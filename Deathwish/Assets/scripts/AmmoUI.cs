using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoUI : MonoBehaviour
{
    // Start is called before the first frame update
    int M_Ammos;
    int M_MaxAmmos;
    int S_Ammos;
    int S_MaxAmmos;
    Text M_Text1;
    Text M_Text2;
    GunFire player;

    void Start()
    {
        player = GameObject.Find("gun").GetComponent<GunFire>();
        M_Text1 = transform.Find("Text 1").GetComponent<Text>();
        M_Text2 = transform.Find("Text 2").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        M_MaxAmmos = player.MainArmAmmo;
        M_Ammos = player.MainArm;
        S_MaxAmmos = player.SideArmAmmo;
        S_Ammos = player.SideArm;
        if (player.Whicharm == false)
        {

            M_Text1.text = string.Format("{0}/{1}", M_Ammos, M_MaxAmmos);
            M_Text2.text = string.Format("{0}/{1}", S_Ammos, S_MaxAmmos);

        }
        else if (player.Whicharm == true)
        {
            M_Text2.text = string.Format("{0}/{1}", M_Ammos, M_MaxAmmos);
            M_Text1.text = string.Format("{0}/{1}", S_Ammos, S_MaxAmmos);

        }

    }
}
