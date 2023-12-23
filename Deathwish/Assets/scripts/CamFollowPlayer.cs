using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    bool followPlayer = true;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(followPlayer == true)
        {
            camFollow();        
        }
    }
    void camFollow()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
}
