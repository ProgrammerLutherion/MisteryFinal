using UnityEngine;

public class HandleMenu : MonoBehaviour
{
    [SerializeField]
    private Player MainChar;

    private void Start()
    {
        MainChar = FindObjectOfType<Player>();
        MainChar.GetComponent<MainCharPueblo_Movement>().enabled = false;
        MainChar.GetComponent<Mainchar_Movement>().enabled = true;
    }
    void OnGUI()
    {
        // We will only show the menu if displayMenu is true
        // and there is a menuTarget. This will prevent problems if
        // we forget to send the MenuManager the GameObject that was clicked on.
        if (MenuManager.displayMenu && MenuManager.menuTarget)
        {
            MainChar.GetComponent<Mainchar_Movement>().block= true;
            Vector2 position = GetComponent<Camera>().WorldToScreenPoint(MenuManager.menuTarget.transform.position);

            GUILayout.BeginArea(new Rect(position.x, position.y, 128, 80), GUI.skin.box);

            GUILayout.Label("Menú");

            if (GUILayout.Button("Atacar"))
            {

                if (MenuManager.menuTarget.GetComponent<Enemy_Movement>().isInRange)
                {
                    MenuManager.menuTarget.GetComponent<Enemy_Movement>().takeDamage(MainChar.GetComponent<Mainchar_Movement>().getAttackDamage());
                    MenuManager.displayMenu = false;
                    MainChar.GetComponent<Mainchar_Movement>().turnChange();
                    Debug.Log("Attack!");
                }
                else
                {
                    Debug.Log("No estás en rango");
                }


                MainChar.GetComponent<Mainchar_Movement>().block = false;
                MenuManager.menuTarget = null;
            }

            if (GUILayout.Button("Cancelar"))
            {
                MainChar.GetComponent<Mainchar_Movement>().block = false;
                MenuManager.displayMenu = false;
                MenuManager.menuTarget = null;
            }

            GUILayout.EndArea();
        }
    }
}