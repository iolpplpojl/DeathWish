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
    public float health = 500f;
    public float speed = 3f;
    Vector3 StartTransform;
    bool getted = false;
    ScoreManager GetAmmoCombo;
    bool ded;
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
            Debug.Log("ah");
            health -= collision.GetComponent<bulletLogic>().damage;
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
        if (health < 0)
        {
            Death();
        }
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
    public bool getded()
    {
        return ded;
    }
}
