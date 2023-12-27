using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamStop : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera cam;
    StopManager stop;
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        stop = GameObject.FindWithTag("StopManager").GetComponent<StopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop.GetStop() == false)
        {
            cam.enabled = true;
        }
        else
        {
            cam.enabled = false;

        }
    }
}
