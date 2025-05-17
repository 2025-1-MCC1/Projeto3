using UnityEngine;

public class ParqueController : MonoBehaviour
{
    public BrinquedoController[] brinquedos;

    void Start()
    {
        // No in�cio, garante que todos os brinquedos estejam desligados
        foreach (var b in brinquedos)
        {
            b.DesligarBrinquedo(); // Essa fun��o voc� cria no BrinquedoController
        }

        // Se o jogador j� venceu o minigame dos fios
        if (GameManager.Instance != null && GameManager.Instance.wireTaskCompleted)
        {
            foreach (var b in brinquedos)
            {
                b.LigarBrinquedo();
            }
        }
    }
}
