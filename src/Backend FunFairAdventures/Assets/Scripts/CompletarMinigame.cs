using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletarMinigame : MonoBehaviour
{
    public string cenaPrincipal = "Jogo"; // Nome da sua cena principal

    // Este m�todo deve ser chamado quando o minigame for conclu�do
    public void MinigameConcluido()
    {
        // Retorna para a cena principal
        SceneManager.LoadScene(cenaPrincipal);
    }
}