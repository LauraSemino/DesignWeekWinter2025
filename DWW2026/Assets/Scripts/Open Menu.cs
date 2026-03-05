using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void openManual(InputAction.CallbackContext c)
    {
        menu.SetActive(!menu.activeSelf);
    }
}
