using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GunFire : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public Transform Shotpoint;
    private bool shoted;
    public float firerate;
    public float[] gunfirerate;
    public float nowfirerate = 0f;
    public int MainArm; // ÁÖ¹«±â
    public int SideArm;
    public int Sidemaxammo;
    public int Mainmaxammo;
    public int MainArmAmmo;
    public int SideArmAmmo;
    public int[] guntype;
    public bool Whicharm = false;
    public float[] reloadtime;
    bool MainReloading = false;
    bool SideReloading = false;
    public int[] gundamage;
    public int[] gunspeed;
    public bool[] Fullauto;
    public float[] recoil;
    public float nowrecoil;
    AudioSource Gunsound;
    CinemachineVirtualCamera Cam;
    CinemachineBasicMultiChannelPerlin shaky;
    private void Start()
    {
        Gunsound = GetComponent<AudioSource>();
        Cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        shaky = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        MainArm = Mainmaxammo;
        SideArm = Sidemaxammo;
        nowrecoil = 0f;
    }
    void Fire(int guntype, int gundamage,int gunspeed)
    {
        
        if (guntype == 0)
        {
            firerate = gunfirerate[0];
            Quaternion rotate = Shotpoint.rotation * Quaternion.Euler(0, 0, Random.Range(-3.25f, 3.25f));
            GameObject createdObject = Instantiate(bullet, transform.position, rotate);
            bulletLogic objectvalues = createdObject.GetComponent<bulletLogic>();
            objectvalues.damage = gundamage;
            objectvalues.speed = gunspeed;
            nowrecoil += recoil[0];
        }
        if (guntype == 1)
        {
            firerate = gunfirerate[1];
            for (int i = 0; i <= 12; i++)
            {
                Quaternion rotate = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-7.5f, 7.5f));
                GameObject createdObject = Instantiate(bullet, transform.position, rotate);
                bulletLogic objectvalues = createdObject.GetComponent<bulletLogic>();
                objectvalues.damage = gundamage;
                objectvalues.speed = Random.Range(gunspeed-10, gunspeed+10);
            }
            nowrecoil += recoil[1];
        }
        if (Whicharm)
        {
            SideArm -= 1;
        }
        else
        {
            MainArm -= 1;
        }
        shaky.m_AmplitudeGain = nowrecoil;
        shaky.m_FrequencyGain = nowrecoil;
        nowfirerate = firerate;
        Gunsound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        firerateCalc();
        CamCool();
        if (Input.GetMouseButton(0) && nowfirerate <= 0 && MainArm != 0 && Whicharm==false && MainReloading == false && Fullauto[0] == true)
        {
            Fire(guntype[0], gundamage[0], gunspeed[0]);
        }
        else if (Input.GetMouseButton(0) && nowfirerate <= 0 && SideArm != 0 && Whicharm == true && SideReloading == false && Fullauto[1] == true)
        {
            Fire(guntype[1], gundamage[1], gunspeed[1]);
        }
        else if (Input.GetMouseButtonDown(0) && nowfirerate <= 0 && MainArm != 0 && Whicharm == false && MainReloading == false && Fullauto[0] == false)
        {
            Fire(guntype[0], gundamage[0], gunspeed[0]);
        }
        else if (Input.GetMouseButtonDown(0) && nowfirerate <= 0 && SideArm != 0 && Whicharm == true && SideReloading == false && Fullauto[1] == false)
        {
            Fire(guntype[1], gundamage[1], gunspeed[1]);
        }
        else if (MainArm == 0 && Input.GetMouseButtonDown(0) && MainReloading == false && Whicharm == false && MainArmAmmo != 0)
        {
            MainReloading = true;
            Invoke("reloadMain", reloadtime[0]);

        }
        else if (SideArm == 0 && Input.GetMouseButtonDown(0) && SideReloading == false && Whicharm == true && SideArmAmmo != 0)
        {
            SideReloading = true;
            Invoke("reloadSide", reloadtime[1]);
        }

        if (Input.GetKeyDown(KeyCode.R) && Whicharm == false && MainReloading == false && MainArmAmmo != 0 && MainArm != Mainmaxammo)
        {
            MainReloading = true;
            Invoke("reloadMain", reloadtime[0]);
        }
        if (Input.GetKeyDown(KeyCode.R) && Whicharm == true && SideReloading == false && SideArmAmmo != 0 && SideArm != Sidemaxammo)
        {
            SideReloading = true;
            Invoke("reloadSide", reloadtime[1]);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ChangeGun();
        }
    }
    void firerateCalc()
    {
        if (nowfirerate > 0)
        {
            nowfirerate -= Time.deltaTime;
        }
    }
    void CamCool()
    {
        if (nowrecoil > 0)
        {
            nowrecoil -= Time.deltaTime*10;
            shaky.m_AmplitudeGain = nowrecoil;
            shaky.m_FrequencyGain = nowrecoil;
        }
    }

    void reloadMain()
    {
        if (MainArmAmmo >= Mainmaxammo) // 120 >= 30
        {
            MainArmAmmo -= (Mainmaxammo - MainArm); // 120 -= 30 - 12;
            MainArm = Mainmaxammo; // 12 = 30
        }
        else
        {
            if (MainArmAmmo + MainArm > Mainmaxammo) // 20/24, 44 > 30
            {
                MainArmAmmo = Mainmaxammo - MainArm;
                MainArm += Mainmaxammo - MainArm; // 20 += 24 - 20
            }
            else
            {
                MainArm += MainArmAmmo;
                MainArmAmmo = 0;
            }
        }
        MainReloading = false;

    }
    void reloadSide()           
    {
        if (SideArmAmmo >= Sidemaxammo) // 120 >= 30
        {
            SideArmAmmo -= (Sidemaxammo - SideArm); // 120 -= 30 - 12;
            SideArm = Sidemaxammo; // 12 = 30
        }
        else
        {
            if (SideArmAmmo + SideArm > Sidemaxammo) // 20/24, 44 > 30
            { 
                SideArmAmmo = Sidemaxammo - SideArm;
                SideArm += Sidemaxammo - SideArm; // 20 += 24 - 20
            }
            else
            {
                SideArm += SideArmAmmo;
                SideArmAmmo = 0;
            }
        }
        SideReloading = false;
    }
    void ChangeGun()
    {
        if (Whicharm == false)
        {
            Whicharm = true;
        }
        else
        {
            Whicharm = false;
        }
        nowfirerate = 0f;

    }

    public void ammoget(bool A, int B)
    {
        if (!A)
        {
            if (Mainmaxammo / B == 0)
            {
                MainArmAmmo += 1;
            }
            else
            {
                MainArmAmmo += Mainmaxammo / B;
            }
        }
        else
        {
            if (Sidemaxammo / B == 0)
            {
                SideArmAmmo += 1;
            }
            else
            {
                SideArmAmmo += Sidemaxammo / B;
            }
        }
    }
}