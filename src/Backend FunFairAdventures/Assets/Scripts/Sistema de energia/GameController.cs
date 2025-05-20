using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Chame este m�todo quando o jogador completar o minijogo
    public void OnMinigameCompleted()
    {
        EnergyManager.Instance.TryEnableEnergy();
    }

    // Se quiser resetar tudo (por ex. ao reiniciar)
    public void RestartMinigame()
    {
        EnergyManager.Instance.DisableEnergy();
        SceneManager.LoadScene("NomeDoSeuMinigame");
    }
}
