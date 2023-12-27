using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool stop = false;

    public void changebool(bool stop)
    {
        this.stop = stop;
    }
    public bool GetStop()
    {
        return stop;
    }
}
