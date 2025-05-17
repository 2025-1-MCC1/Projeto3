using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        // For�a o cursor a ficar vis�vel quando a cena inicia
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Garante que o cursor permanece vis�vel durante toda a execu��o
        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}