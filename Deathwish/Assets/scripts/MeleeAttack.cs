using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    bool Attacked;
    float AttackTime = 0.3f;
    float fanAngle = 150f;
    float fanRadius = 1.5f;
    public LayerMask targetLayer;
    public Transform shotpoint;
    void Start()
    {
        Attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Attacked == false)
        {
            StartCoroutine(Melee(transform.rotation));
        }
    }

    public void ResetMelee()
    {
        Attacked = false;
    }
    IEnumerator Melee(Quaternion rotate)
    {
        Attacked = true;
        Vector2 fanDirection = transform.up; // 기본적으로 오른쪽 방향을 기준으로 함
        int numberOfRays = 20; // 레이의 갯수

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = Mathf.Lerp(-90f, 90f, (float)i / (numberOfRays - 1)); // 부채꼴 각도 계산

            // 각도에 따라 회전된 레이 방향 계산
            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angle) * fanDirection;

            // 레이 발사
            RaycastHit2D hit = Physics2D.Raycast(shotpoint.position, rotatedDirection, fanRadius, targetLayer);

            // 레이에 충돌한 경우 처리
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("melee");
                    hit.collider.GetComponent<Enemy>().MeleeAttacked(rotate);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, rotatedDirection * fanRadius, Color.red);
            }
        }
        yield return new WaitForSeconds(AttackTime);
        Attacked = false;
    }
}
