using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey;
using CodeMonkey.Utils;
public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializeField] private FieldOfView fieldOfview;
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public int level;
    private bool itworked;
    private bool notreturn;
    private bool Checkpatrol;
    public bool hasgun;
    public Quaternion lastrotation;
    [SerializeField] Transform target;
    EnemyGunFire Fire;
    Vector3 lastwatch;
    NavMeshAgent agent;
    void Start()
    {
        level = 0;
        agent = GetComponent<NavMeshAgent>();
        Fire = GetComponent<EnemyGunFire>();
        agent.enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        itworked = true;
        Checkpatrol = false;
        lastwatch = Vector3.zero;
        Invoke("worked", 0.2f);
    }

    // Update is called once per frame

    void Update()
    {


        //  Vector3 targetPosition = patrolPoints[targetPoint].position;
        // Vector3 aimDir = (targetPosition - transform.position).normalized;
        //  fieldOfview.SetOrigin(transform.position);
        // fieldOfview.SetAimDirection(aimDir);
        if (patrolPoints.Length == 0)
        {
        }
        else if (level == 0 && notreturn == false)
        {
            Patrol();
        }
        else if (level == 0 && notreturn == true)
        {
            goPatrol();
        }
        if (level == 1 && hasgun == false)
        {
            Follow();
        }
        else if (level == 1 && hasgun == true)
        {
            bang();
        }
        if (level == 2)
        {
            goLastwatch();
        }
        if (level == 3)
        {
            bang();
        }
        if (level == 4)
        {
            transform.rotation = lastrotation;
        }
        // 발격음 위치로 이동
        // 만약 범위내에 플레이어가 있다면 : level 1


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, target.position - transform.position);
    }
    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position,target.position- transform.position, Vector2.Distance(target.position, transform.position), LayerMask.GetMask("ray"));
       // foreach (RaycastHit2D hit in hits)
       // {
       //     Debug.Log("Hit object: " + hit.collider.gameObject.name);
       // }

        if (hits.Length > 1)
        {
            if (hits[0].collider.name == "shotTrigger" && hits[1].collider.name == "player")
            {
                level = 1;

            }
            else if (level == 1)
            {
                level = 2;
            }
        } 
    }
    void increaseTarget()
    {
        targetPoint++;
        if (targetPoint == patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (patrolPoints.Length != 0)
        {
            if (collision.tag == patrolPoints[targetPoint].tag && itworked == false)
            {
                itworked = true;
                notreturn = false;
                increaseTarget();
                Invoke("worked", 0.2f);
            }
        }
    }
    void Patrol()
    {
        agent.enabled = false;
        Quaternion curr = transform.rotation;
        Quaternion dir = patrolPoints[targetPoint].rotation;
        transform.rotation = Quaternion.Slerp(curr, dir, Time.deltaTime * speed * 20);
        transform.position = Vector3.MoveTowards(transform.position,patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }
    void goPatrol()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward,agent.velocity);
        agent.SetDestination(patrolPoints[targetPoint].position);
    }

    void goLastwatch()
    {
        Debug.Log("Golast");
        agent.enabled = true;

        if (lastwatch != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, agent.velocity);
            if (transform.rotation != Quaternion.Euler(0,0,0))
            {
                lastrotation = transform.rotation;
            }
            agent.SetDestination(lastwatch);


            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Debug.Log("arivve");
                        level = 4;
                    }
                }
            }
        }
    }
    void Follow()
    {
        Debug.Log("Follow");
        agent.enabled = true;
        notreturn = true;
        lastwatch = target.position;
        agent.SetDestination(target.position);
        transform.rotation = Quaternion.LookRotation(Vector3.forward,agent.velocity);
    }

    void checkagain()
    {
        Checkpatrol = false;
    }
    void worked()
    {
        itworked = false;
    }
    void bang()
    {
        Debug.Log("Bang");
        agent.enabled = false;

        transform.rotation = Quaternion.LookRotation(Vector3.forward,target.position - transform.position);
        lastwatch = target.position;

        Fire.getFire();

    }
    void watch()
    {
        agent.enabled = false;

    }
}
