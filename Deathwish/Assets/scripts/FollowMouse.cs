using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform m_transform;
    StopManager stop;
    void Start()
    {
        stop = GameObject.FindWithTag("StopManager").GetComponent<StopManager>();
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop.GetStop() == false)
        {
            rotateToCamera();
        }

    }
    void rotateToCamera()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ���콺�� �������� ���ϴ� ���� ���
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        m_transform.rotation = rotation;

    }
}
