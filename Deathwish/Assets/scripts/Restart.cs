using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public string Scene;
    GameObject player;
    bool death = false;
    player PlayerPos;
    GunFire gun;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerPos = player.GetComponent<player>();
        gun = player.GetComponentInChildren<GunFire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPos.getded() == true)
        {
            death = true;
        }
        else
        {
            death = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && death == true)
        {
            player.SetActive(true);
            PlayerPos.Restart();
            gun.Refill();
        }
    }
    public bool GetDeath()
    {
        return death;
    }
}
