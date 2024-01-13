using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    // Start is called before the first frame update
    int movement = 0;
    int maxmovement;
    float speed = 5f;
    public Sprite[] sptires;
    SpriteRenderer SpRender;
    void Start()
    {
        SpRender = GetComponent<SpriteRenderer>();
        SpRender.sprite = sptires[Random.Range(0, sptires.Length)];
        Debug.Log(maxmovement);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movement < maxmovement)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            movement++;
        }
    }
    public void SetBlood(int MaxMove, float speed)
    {
        maxmovement = MaxMove;
        this.speed = speed;
        
    }
}
