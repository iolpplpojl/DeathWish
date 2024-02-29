using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    private bool shoted;
    public float firerate;
    public float nowfirerate;
    public bool GunType;
    public int maxammo;
    public float ReloadingTime;
    int ammo;
    bool reloading;
    AudioSource Gunfire;
    private void Start()
    {
        Gunfire = GetComponent<AudioSource>();
        ammo = maxammo;
    }
    void Fire()
    {
        if (!GunType)
        {
            GameObject createdObject = Instantiate(bullet, transform.position, transform.rotation);
        }
        else if(GunType)
        {
            for (int i = 0; i <= 12; i++)
            {
                Quaternion rotate = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-6.5f, 6.5f));
                GameObject createdObject = Instantiate(bullet, transform.position, rotate);
                bulletLogic objectvalues = createdObject.GetComponent<bulletLogic>();
                objectvalues.speed = Random.Range(18,40);
            }
        } 
        ammo--;
        nowfirerate = firerate;
        Gunfire.Play();

    }

    // Update is called once per frame

    public void getFire()
    {
        firerateCalc();
        if (ammo != 0 && nowfirerate <= 0 && !reloading)
        {
            Fire();
        }
        if (ammo <= 0 && reloading == false)
        {
            Invoke("Reload",ReloadingTime);
            reloading = true;
        }
    }
    void Reload()
    {
        ammo = maxammo;
        reloading = false;
    }
    void firerateCalc()
    {
        if (nowfirerate > 0)
        {
            nowfirerate -= Time.deltaTime;
        }
    }
}
