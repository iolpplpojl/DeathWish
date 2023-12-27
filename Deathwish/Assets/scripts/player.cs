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
    bool getted = false;
    ScoreManager GetAmmoCombo;
    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Gun = GetComponentInChildren<GunFire>();
        stop = GameObject.FindWithTag("StopManager").GetComponent<StopManager>();
        GetAmmoCombo = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
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

    }
    // Update is called once per frame
    private void Update()
    {
        if (stop.GetStop() == false)
        {
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");
        }
        if (health < 0)
        {
            Debug.Log("DED");
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        Vector2 norVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        Rigid.MovePosition(Rigid.position + norVec);
    }
    void getammo(Collider2D collision)
    {
        Gun.ammoget(collision.GetComponent<AmmoDrop>().getammotype(), collision.GetComponent<AmmoDrop>().getammoamount());
        collision.GetComponent<AmmoDrop>().Get();
        GetAmmoCombo.GetAmmo();
    }
}
