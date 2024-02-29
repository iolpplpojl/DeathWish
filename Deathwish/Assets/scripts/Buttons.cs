using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    Animator Anim;
    public Animator ParentAnim;
    StartManager StartManager;
    bool Entered = false;
    public string ButtonName;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Anim.SetBool("Selected", true);
        Entered = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Anim.SetBool("Selected", false);
        Entered = false;
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        StartManager = GetComponentInParent<StartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Entered)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked! Owner: " + ButtonName);
                Clicked();
            }
        }
    }

    void Clicked()
    {
        switch (ButtonName) {
            case "Start":
                ParentAnim.SetBool("Pressed", true);
                StartManager.Pressed = true;
                break;
            case "Mainmenu":
                GameObject.FindWithTag("pauser").GetComponent<pausegame>().mainmenu();
                SceneManager.LoadScene("mainmenu");
                break;
        }
        

    }
}
