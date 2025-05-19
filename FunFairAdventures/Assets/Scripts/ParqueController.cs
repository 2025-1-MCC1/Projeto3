using UnityEngine;

public class ParqueController : MonoBehaviour
{
    public BrinquedoController[] brinquedos;

    void Start()
    {
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
