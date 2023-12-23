using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    // Start is called before the first frame update
    bool AmmoType = false;
    int AmmoAmount = 3;
    public bool Getted = false;
    public void setammotype(bool type, int Amount)
    {
        AmmoType = type;
        AmmoAmount = Amount;
    }
    public bool getammotype()
    {
        return AmmoType;
    }
    public int getammoamount()
    {
        return AmmoAmount;
    }

    public void Get()
    {
        Destroy(gameObject);
    }
}
