using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamCool : MonoBehaviour
{
    // Start is called before the first frame update
    float nowrecoil;
    CinemachineVirtualCamera Cam;
    CinemachineBasicMultiChannelPerlin shaky;
    void Start()
    {
        Cam = GetComponent<CinemachineVirtualCamera>();
        shaky = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {

        nowrecoil = shaky.m_AmplitudeGain;

        if (nowrecoil > 0)
        {
            nowrecoil -= Time.deltaTime * 10;
            shaky.m_AmplitudeGain = nowrecoil;
            shaky.m_FrequencyGain = nowrecoil;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            nowrecoil = 0;
            shaky.m_AmplitudeGain = 0;
            shaky.m_FrequencyGain = 0;
        }
    }
}
