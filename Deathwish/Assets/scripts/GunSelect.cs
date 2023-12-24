using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public static GunSelect instance = null;
    int[] gundamage = { 0,0 };
    int[] gunspeed = { 0,0 };
    bool[] Fullauto = {false,false};
    float[] recoil ={0f,0f};
    int Sidemaxammo;
    int Mainmaxammo;
    int MainArmAmmo;
    int SideArmAmmo;
    int[] guntype = {0,0};
    float[] gunfirerate = {0,0};
    float[] reloadtime = { 0, 0 };

    int[] GunType = { 1, 1 };

    public bool selected;
    GunFire Gun;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SetGunType(GunType);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[] GetDamage()
    {
        return gundamage;
    }

    public int[] GetSpeed()
    {
        return gunspeed;
    }

    public bool[] GetFullAuto()
    {
        return Fullauto;
    }

    public float[] GetRecoil()
    {
        return recoil;
    }

    public int GetMainMaxAmmo()
    {
        return Mainmaxammo;
    }

    public int GetMainAmmo()
    {
        return MainArmAmmo;
    }

    public int GetSideMaxAmmo()
    {
        return Sidemaxammo;
    }

    public int GetSideAmmo()
    {
        return SideArmAmmo;
    }

    public int[] GetGunType()
    {
        return guntype;
    }

    public float[] GetGunFireRate()
    {
        return gunfirerate;
    }

    public float[] GetReloadTime()
    {
        return reloadtime;
    }


    void SetGunType(int[] Num)
    {
        switch (Num[0])
        {
            case 1:
                gundamage[0] = 50;
                gunspeed[0] = 50;
                Fullauto[0] = true;
                recoil[0] = 0.75f;
                Mainmaxammo = 24;
                MainArmAmmo = 24;
                guntype[0] = 0;
                gunfirerate[0] = 0.06f;
                reloadtime[0] = 0.22f;
                break;
        }
        switch (Num[1])
        {
            case 1:
                gundamage[1] = 20;
                gunspeed[1] = 50;
                Fullauto[1] = false;
                recoil[1] = 3f;
                Sidemaxammo = 6;
                SideArmAmmo = 6;
                guntype[1] = 1;
                gunfirerate[1] = 0.6f;
                reloadtime[1] = 0.3f;
                break;
        }
    }
}
