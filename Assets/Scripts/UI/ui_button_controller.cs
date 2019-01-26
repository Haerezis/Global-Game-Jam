using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_button_controller : MonoBehaviour
{
    public Button btn; // The button linked with this gameObject

    private void OnTriggerEnter2D(Collider2D collision)
    {
        btn.Select(); // Highlight the current button
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float triggerButton = Input.GetAxisRaw("Interact");
        if (triggerButton == 1.0)
        {
            btn.onClick.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem"); 
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); // Deselect the current selected GameObject
    }
}
