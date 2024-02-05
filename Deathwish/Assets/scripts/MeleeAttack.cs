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
        Vector2 fanDirection = transform.up; // �⺻������ ������ ������ �������� ��
        int numberOfRays = 20; // ������ ����

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = Mathf.Lerp(-90f, 90f, (float)i / (numberOfRays - 1)); // ��ä�� ���� ���

            // ������ ���� ȸ���� ���� ���� ���
            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angle) * fanDirection;

            // ���� �߻�
            RaycastHit2D hit = Physics2D.Raycast(shotpoint.position, rotatedDirection, fanRadius, targetLayer);

            // ���̿� �浹�� ��� ó��
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
