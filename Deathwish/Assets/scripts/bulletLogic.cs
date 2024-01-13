using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public BoxCollider2D playerCollider;
    public float speed;
    public float maxRayDistance;
    public float damage;
    public string whoshot;
    public bool hited = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (whoshot == "Player")
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());
        }
        if (whoshot == "Enemy")
        {
            GameObject playerObject = GameObject.FindWithTag("Enemy");
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());
        }

    }

    private void FixedUpdate()
    {
       // transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        rigid.velocity = transform.up * speed;
        //CheckCollision();
        Invoke("dead", 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (whoshot == "enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        else if (whoshot == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (whoshot == "enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        else if (whoshot == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * maxRayDistance);
    }
    void CheckCollision()
    {

        Vector2 dir = transform.up;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.up, maxRayDistance);

        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag == "Enemy")
            {
                Debug.Log(ray.collider.gameObject.name);

                dead();
            }
        }

     }
    void dead()
    {
        Destroy(gameObject);
    }
}
