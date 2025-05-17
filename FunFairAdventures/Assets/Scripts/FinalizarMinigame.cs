using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarMinigame : MonoBehaviour
{
    public string nomeCenaPrincipal = "Jogo";
    public Transform pontoDeRetorno;

    public void Finalizar()
    {
        GameState.posicaoRetorno = pontoDeRetorno.position;
        GameState.rotacaoRetorno = pontoDeRetorno.rotation;

        GameManager.Instance.wireTaskCompleted = true; // Marca o minigame como concluído

        SceneManager.LoadScene(nomeCenaPrincipal);
    }
}

