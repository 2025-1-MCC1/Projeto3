using UnityEngine;

public class ColetarMoedas : MonoBehaviour
{
    public GerenciadorJogo gerenciadorJogo; // Referência ao gerenciador que controla o jogo

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se colidiu com uma moeda
        if (other.CompareTag("Moeda"))
        {
            // Destroi a moeda
            Destroy(other.gameObject);

            // Informa ao GerenciadorJogo que uma moeda foi coletada
            if (gerenciadorJogo != null)
            {
                gerenciadorJogo.ColetarMoeda();
            }
            else
            {
                Debug.LogWarning("GerenciadorJogo não está atribuído no ColetarMoedas!");
            }
        }
    }
}
