using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarMinigame : MonoBehaviour
{
    public string nomeCenaPrincipal = "Jogo";
    public Transform pontoDeRetorno;

    public void Finalizar()
    {
        // Salva posição para voltar do minigame
        GameState.posicaoRetorno = pontoDeRetorno.position;
        GameState.rotacaoRetorno = pontoDeRetorno.rotation;

        // Marca tarefa como concluída
        GameManager.Instance.wireTaskCompleted = true;

        // Retorna ao parque
        SceneManager.LoadScene(nomeCenaPrincipal);
    }
}
