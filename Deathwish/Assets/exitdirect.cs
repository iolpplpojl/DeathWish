using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitdirect : MonoBehaviour
{
    // Start is called before the first frame update

    float CircleR = 2.0f;
    bool on = false;
    Transform temp;
    [SerializeField]
    List<Transform> downtemp = new List<Transform>();

    public Transform player;

    // Update is called once per frame

    private void Start()
    {
        on = false;
    }
    void Update()
    {
        if (temp != null)
        {
            Vector3 direction = temp.transform.position - player.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = rotation;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float x = CircleR * Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = CircleR * Mathf.Sin(angle * Mathf.Deg2Rad);

            transform.position = player.position + new Vector3(x, y, 0f);
        }

        if (!on)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("aaaa");
        }
        else
        {
            Debug.Log("aaaa");
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void direction(Transform Direct)
    {
        temp = Direct;
        doored();
    }
    public void downdirectionadd(Transform Direct)
    {
        downtemp.Add(Direct);
    }
    public void Removed()
    {
        downtemp.RemoveAt(downtemp.Count - 1);
    }
    public void downdirectionpop()
    {
        if (downtemp.Count > 0)
        {
            direction(downtemp[downtemp.Count - 1]);
            downtemp.RemoveAt(downtemp.Count - 1);
        }
    }
    public void doored()
    {
        on = true;
    }
    public void exited()
    {
        on = false;
    }
}
