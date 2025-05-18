using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private bool lockCursorOnStart = true;
    private bool isCursorLocked = false;

    void Start()
    {
        if (lockCursorOnStart)
        {
            LockCursor();
        }
    }

    void Update()
    {
        // Verificar se o cursor deve estar bloqueado
        UpdateCursorState();

        // Permitir alternar com tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorLock();
        }
    }

    void UpdateCursorState()
    {
        if (isCursorLocked)
        {
            // Forçar o estado do cursor a cada frame
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void LockCursor()
    {
        isCursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Cursor locked");
    }

    public void UnlockCursor()
    {
        isCursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Cursor unlocked");
    }

    public void ToggleCursorLock()
    {
        if (isCursorLocked)
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus && isCursorLocked)
        {
            // Restaurar bloqueio quando a aplicação recuperar o foco
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Focus gained - cursor relocked");
        }
    }
}