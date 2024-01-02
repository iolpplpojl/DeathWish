using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] Clear;
    public int nowlevel = 0;

    void Cleared()
    {
        Clear[nowlevel] = true;
        nowlevel++;
    }
}
