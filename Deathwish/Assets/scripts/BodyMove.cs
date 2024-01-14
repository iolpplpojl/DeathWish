using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    // Start is called before the first frame update
    int movement = 0;
    int maxmovement;
    float speed = 5f;

    void Start()
    {
        StartCoroutine(MoveBlud());
    }

    // Update is called once per frame


    IEnumerator MoveBlud()
    {
        for (int i = 0; i < maxmovement; i++)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("BloodDead");

    }
    public void SetBlood(int MaxMove, float speed)
    {
        maxmovement = MaxMove;
        this.speed = speed;

    }
}
