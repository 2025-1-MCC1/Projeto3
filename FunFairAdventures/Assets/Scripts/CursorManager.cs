using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Libera o cursor
        Cursor.visible = true;                  // Torna o cursor visível
    }
}
