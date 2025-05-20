using UnityEngine;

public class AtivarBrinquedo : MonoBehaviour
{
    public GameObject brinquedo; // Refer�ncia ao objeto do brinquedo

    void Start()
    {
        // Garantir que o brinquedo esteja desativado no in�cio
        brinquedo.SetActive(false);
    }

    public void AtivarAposMinigame()
    {
        // Ativar o brinquedo ap�s o minigame ser conclu�do
        brinquedo.SetActive(true);
    }
}
