using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rigid;
    StopManager stop;
    GunFire Gun;
    Vector2 inputVec;
    public float health;
    public float speed;
    Vector3 StartTransform;
    bool getted = false;
    ScoreManager GetAmmoCombo;
    bool ded;
    bool invinsiv = false;
    public GameObject Body;
    public GameObject Blood;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Gun = GetComponentInChildren<GunFire>();
        stop = GameObject.FindWithTag("StopManager").GetComponent<StopManager>();
        GetAmmoCombo = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        SetPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            if (!invinsiv)
            {
                Debug.Log("ah");
                health -= collision.GetComponent<bulletLogic>().damage;

                if (health <= 0)
                {
                    invinsiv = true;

                    for (int i = 0; i < 6; i++)
                    {
                        GameObject Blud = Instantiate(Blood, transform.position, collision.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f)));
                        Blud.GetComponent<BloodMove>().SetBlood(Random.Range(5, 20), Random.Range(3.0f, 14.0f));
                    }
                    GameObject body = Instantiate(Body, transform.position, Body.transform.rotation * collision.transform.rotation);
                    body.GetComponent<BodyMove>().SetBlood(Random.Range(10, 20), Random.Range(3.0f, 4.0f));
                    Death();
                }
            }
        }
        if (collision.CompareTag("Ammo") && !collision.GetComponent<AmmoDrop>().Getted)
        {
            collision.GetComponent<AmmoDrop>().Getted = true;
            getammo(collision);
        }
        if (collision.CompareTag("Exit") && GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().Getclear() == true)
        {
            collision.GetComponent<ExitDoor>().exitdoor();
            GameObject.FindWithTag("ExitManager").GetComponent<ExitManager>().GoNext();
            GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>().goNextFloor();
        }
        if (collision.CompareTag("DownExit"))
        {
            Debug.Log("asdadsa");
            collision.GetComponent<ExitDoor>().exitdoor();
            GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>().goBackFloor();
        }

    }
    // Update is called once per frame
    private void Update()
    {

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        if (stop.GetStop() == false)
        {
            Vector2 norVec = inputVec.normalized * speed * Time.fixedDeltaTime;
            Rigid.MovePosition(Rigid.position + norVec);
        }
    }
    void getammo(Collider2D collision)
    {
        Gun.ammoget(collision.GetComponent<AmmoDrop>().getammotype(), collision.GetComponent<AmmoDrop>().getammoamount());
        collision.GetComponent<AmmoDrop>().Get();
        GetAmmoCombo.GetAmmo();
    }
    public void Death()
    {
        Debug.Log("DED");
        GetComponentInChildren<MeleeAttack>().ResetMelee();
        for (int i = 0; i < 15; i++)
        {
            GameObject Blud = Instantiate(Blood, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-135f, 135f)));
            Blud.GetComponent<BloodMove>().SetBlood(Random.Range(5, 20), Random.Range(3.0f, 7.0f));
        }
        ded = true;
        gameObject.SetActive(false);
    }
    public void SetPos()
    {
        StartTransform = transform.position;
    }
    public void Restart()
    {
        transform.position = StartTransform;
        health = 100;
        ded = false;
    }
    
    public void Setinv(bool ah)
    {
        invinsiv = ah;
    }
    public bool getded()
    {
        return ded;
    }
}
