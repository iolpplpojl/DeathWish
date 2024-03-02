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
    float[] gunrecoil = { 0f, 0f };
    int Sidemaxammo;
    int Mainmaxammo;
    int MainArmAmmo;
    int SideArmAmmo;
    int[] guntype = {0,0};
    float[] gunfirerate = {0,0};
    float[] reloadtime = { 0, 0 };

    int[] GunType = {999,999};

    public bool selected;
    GunFire Gun;

    void Awake()
    {
       /** // SoundManager 인스턴스가 이미 있는지 확인, 이 상태로 설정
        if (instance == null)
            instance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        DontDestroyOnLoad(gameObject);
       **/
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
    public float[] GetGunRecoil()
    {
        return gunrecoil;
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
    public void SetGunTypes(int[] Num)
    {


        GunType = Num;
        SetGunType(Num);
    }


    void SetGunType(int[] Num)
    {
        Debug.Log(Num[0]);
        Debug.Log(Num[1]);

        switch (Num[0])
        {
            case 1: //M4A1
                gundamage[0] = 100;
                gunspeed[0] = 50;
                Fullauto[0] = true;
                recoil[0] = 1f;
                Mainmaxammo = 18;
                MainArmAmmo = 0;
                guntype[0] = 0;
                gunfirerate[0] = 0.08f;
                reloadtime[0] = 0.50f;
                gunrecoil[0] = 1.5f;
                break;
            case 2: // MP9
                gundamage[0] = 50;
                gunspeed[0] = 50;
                Fullauto[0] = true;
                recoil[0] = 0.75f;
                Mainmaxammo = 30;
                MainArmAmmo = 15;
                guntype[0] = 0;
                gunfirerate[0] = 0.06f;
                reloadtime[0] = 0.22f;
                gunrecoil[0] = 1.5f;
                break;
            case 3: // M3
                gundamage[0] = 50;
                gunspeed[0] = 50;
                Fullauto[0] = false;
                recoil[0] = 3f;
                Mainmaxammo = 6;
                MainArmAmmo = 2;
                guntype[0] = 1;
                gunfirerate[0] = 0.75f;
                reloadtime[0] = 0.6f;
                gunrecoil[0] = 6.5f;
                break;
            case 999:
                gundamage[0] = 1;
                gunspeed[0] = 50;
                Fullauto[0] = false;
                recoil[0] = 3f;
                Mainmaxammo = 0;
                MainArmAmmo = 0;
                guntype[0] = 1;
                gunfirerate[0] = 0.75f;
                reloadtime[0] = 0.6f;
                gunrecoil[0] = 6.5f;
                break;
        }
        switch (Num[1])
        {
            case 1: // M1911
                gundamage[1] = 100;
                gunspeed[1] = 50;
                Fullauto[1] = false;
                recoil[1] = 0.75f;
                Sidemaxammo = 7;
                SideArmAmmo = 0;
                guntype[1] = 0;
                gunfirerate[1] = 0.03f;
                reloadtime[1] = 0.45f;
                gunrecoil[1] = 0.22f;
                break;
            case 2: // Sawed-off
                gundamage[1] = 20;
                gunspeed[1] = 50;
                Fullauto[1] = false;
                recoil[1] = 3f;
                Sidemaxammo = 2;
                SideArmAmmo = 2;
                guntype[1] = 1;
                gunfirerate[1] = 0.01f;
                reloadtime[1] = 0.45f;
                gunrecoil[1] = 7.5f;
                break;
            case 3: // Tec-9
                gundamage[1] = 70;
                gunspeed[1] = 50;
                Fullauto[1] = true;
                recoil[1] = 0.75f;
                Sidemaxammo = 12;
                SideArmAmmo = 18;
                guntype[1] = 0;
                gunfirerate[1] = 0.044f;
                reloadtime[1] = 0.45f;
                gunrecoil[1] = 2f;
                break;
            case 999:
                gundamage[0] = 1;
                gunspeed[0] = 50;
                Fullauto[0] = false;
                recoil[0] = 3f;
                Mainmaxammo = 0;
                MainArmAmmo = 0;
                guntype[0] = 1;
                gunfirerate[0] = 0.75f;
                reloadtime[0] = 0.6f;
                gunrecoil[0] = 6.5f;
                break;
        }
    }
}
