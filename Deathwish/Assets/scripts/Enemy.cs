using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public GameObject Ammo;
    public bool AmmoType = false;
    public int AmmoAmount;
    public bool hasammo;
    bool dead = false;
    EnemyGunFire Gun;
    public GameObject[] Blood;
    public GameObject Blood2;
    GameObject EM;
    public GameObject Body;
    // Update is called once per frame
    private void Awake()
    {
        EM = GameObject.Find("EnemyManager");
        Gun = GetComponent<EnemyGunFire>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && dead ==false)
        {
            bulletLogic bul = collision.GetComponent<bulletLogic>();
            if (bul.hited == false)
            {
                bul.hited = true;
                health -= bul.damage;
                for (int i = 0; i < 4; i++)
                {
                    GameObject Blud = Instantiate(Blood[Random.Range(0, Blood.Length)], transform.position, Quaternion.identity);
                    Blud.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f))*7f, ForceMode2D.Impulse);
                }
                for (int i = 0; i < 6; i++)
                {
                    GameObject Blud = Instantiate(Blood2, transform.position, collision.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f)));
                    Blud.GetComponent<BloodMove>().SetBlood(Random.Range(5, 20), Random.Range(3.0f, 14.0f));
                    Blud.transform.SetParent(EM.transform, true);

                }
                if (health <= 0 && dead == false)
                {
                    Debug.Log("DED");
                    Dead();
                    GameObject body = Instantiate(Body, transform.position, Body.transform.rotation*collision.transform.rotation);
                    body.transform.SetParent(EM.transform, true);
                }
                Debug.Log("ouch");
                Debug.Log(health);
                Debug.Log(bul.damage);

            }

        }
    }
    private void Update()
    {

    }
    void Dead()
    {
        dead = true;
        EnemyManager Count = EM.GetComponent<EnemyManager>();
        for (int i = 0; i < 15; i++)
        {
            GameObject Blud = Instantiate(Blood2, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-135f, 135f)));
            Blud.GetComponent<BloodMove>().SetBlood(Random.Range(5, 20), Random.Range(3.0f, 7.0f));
            Blud.transform.SetParent(EM.transform, true);
        }

        if (hasammo == true)
        {
            GameObject Mammo = Instantiate(Ammo, transform.position, Quaternion.identity);
            Mammo.transform.SetParent(EM.transform, true);
            Mammo.GetComponent<AmmoDrop>().setammotype(AmmoType, AmmoAmount);
        }


        ScoreManager Score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Score.Kill();
        Count.Kill();
        gameObject.SetActive(false);
    }
}
