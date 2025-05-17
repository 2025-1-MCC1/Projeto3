using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        // Força o cursor a ficar visível quando a cena inicia
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Garante que o cursor permanece visível durante toda a execução
        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}