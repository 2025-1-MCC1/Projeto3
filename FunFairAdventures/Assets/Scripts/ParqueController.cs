using UnityEngine;

public class ParqueController : MonoBehaviour
{
    public BrinquedoController[] brinquedos;

    void Start()
    {
        // No início, garante que todos os brinquedos estejam desligados
        foreach (var b in brinquedos)
        {
            b.DesligarBrinquedo(); // Essa função você cria no BrinquedoController
        }

        // Se o jogador já venceu o minigame dos fios
        if (GameManager.Instance != null && GameManager.Instance.wireTaskCompleted)
        {
            foreach (var b in brinquedos)
            {
                b.LigarBrinquedo();
            }
        }
    }
}
