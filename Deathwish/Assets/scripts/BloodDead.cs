using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDead : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Blood");
        if (collision.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
