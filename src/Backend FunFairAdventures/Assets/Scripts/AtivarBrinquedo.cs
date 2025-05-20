using UnityEngine;

public class AtivarBrinquedo : MonoBehaviour
{
    public GameObject brinquedo; // Referência ao objeto do brinquedo

    void Start()
    {
        // Garantir que o brinquedo esteja desativado no início
        brinquedo.SetActive(false);
    }

    public void AtivarAposMinigame()
    {
        // Ativar o brinquedo após o minigame ser concluído
        brinquedo.SetActive(true);
    }
}
