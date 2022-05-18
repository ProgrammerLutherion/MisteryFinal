using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        MenuManager.displayMenu = true;
        MenuManager.menuTarget = gameObject;
    }
}