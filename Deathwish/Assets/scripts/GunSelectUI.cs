using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunSelectUI : MonoBehaviour
{
    // Start is called before the first frame update
    GunSelect GunSelect;
    StopManager stop;
    int Selectnum;
    int[] SelectGunNum = {1,1};
    Text M_Text1;
    Text M_Text2;
    GunFire Gunfire;
    void Start()
    {
        stop = GameObject.FindWithTag("StopManager").GetComponent<StopManager>();
        GunSelect = GameObject.FindWithTag("GunManager").GetComponent<GunSelect>();
        Gunfire = GameObject.FindWithTag("gun").GetComponent<GunFire>();

        if (GunSelect.selected == false)
        {
            stop.changebool(true);
            Selectnum = 0;
            M_Text1 = transform.Find("Text 1").GetComponent<Text>();
            M_Text2 = transform.Find("Text 2").GetComponent<Text>();
        }
        else if (GunSelect.selected == true)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput == 0.1f && SelectGunNum[Selectnum] != 3)
        {
            SelectGunNum[Selectnum]++;
        }
        else if (wheelInput == -0.1f && SelectGunNum[Selectnum] > 1)
        {
            SelectGunNum[Selectnum]--;
        }
        if (Input.GetMouseButtonDown(0) && Selectnum == 1)
        {
            GunSelect.SetGunTypes(SelectGunNum);
            Gunfire.SetGun();
            GunSelect.selected = true;
        }
        if (Input.GetMouseButtonDown(0) && Selectnum == 0)
        {
            Selectnum++;
        }
        else if (Input.GetMouseButtonDown(1) && Selectnum == 1)
        {
            Selectnum--;
        }


        if (GunSelect.selected == true)
        {
            stop.changebool(false);
            gameObject.SetActive(false);
        }
        if (Selectnum == 0)
        {
            M_Text1.color = Color.yellow;
            M_Text2.color = Color.white;

        }
        else if (Selectnum == 1)
        {
            M_Text1.color = Color.white;
            M_Text2.color = Color.yellow;
        }
        switch (SelectGunNum[0])
        {
            case 1:
                M_Text1.text = "1.MA41";
                break;
            case 2:
                M_Text1.text = "1.MP9";
                break;
            case 3:
                M_Text1.text = "1.M3";
                break;
        }
        switch (SelectGunNum[1])
        {
            case 1:
                M_Text2.text = "2.M1911";
                break;
            case 2:
                M_Text2.text = "2.Sawed-off";
                break;
            case 3:
                M_Text2.text = "2.Tec-9";
                break;
        }

    }
}
