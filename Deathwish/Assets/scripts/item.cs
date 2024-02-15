using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // Start is called before the first frame update
    bool ItemUsed = false;
    public bool Dialogue;
    public void ItemUse()
    {
        if (!ItemUsed)
        {
            ItemUsed = true;
            if (Dialogue)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            }

            GameObject.FindWithTag("ExitManager").GetComponent<ExitManager>().goCheck();
        }
    }

    public bool ItemUsedCheck()
    {
        return ItemUsed;
    }
}
