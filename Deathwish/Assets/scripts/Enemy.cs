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

    // Update is called once per frame
    private void Awake()
    {
        Gun = GetComponent<EnemyGunFire>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            return;
        }
        if (health <= 0 && dead == false)
        {
            Debug.Log("DED");
            Dead();
        }
        else
        {
            health -= collision.GetComponent<bulletLogic>().damage;
        }
    }
    void Dead()
    {
        dead = true;
        if (hasammo == true)
        {
            GameObject Mammo = Instantiate(Ammo, transform.position, Quaternion.identity);
            Mammo.GetComponent<AmmoDrop>().setammotype(AmmoType, AmmoAmount);
        }
        ScoreManager Score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Score.Kill();
        gameObject.SetActive(false);
    }
}
