using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    private bool shoted;
    public float firerate = 0.1f;
    public float nowfirerate = 0f;
    public bool GunType;
    AudioSource Gunfire;
    private void Start()
    {
        Gunfire = GetComponent<AudioSource>();
    }
    void Fire()
    { 
            Quaternion rotate = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-3.25f, 3.25f));
            Instantiate(bullet, transform.position, rotate);
            nowfirerate = firerate;
             Gunfire.Play();
    }

    // Update is called once per frame

    public void getFire()
    {
        firerateCalc();
        if (nowfirerate <= 0)
        {
            Fire();
        }
    }
    void Update()
    {
    }
    void firerateCalc()
    {
        if (nowfirerate > 0)
        {
            nowfirerate -= Time.deltaTime;
        }
    }
}
