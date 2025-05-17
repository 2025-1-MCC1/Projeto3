using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelInteracao : MonoBehaviour
{
    public string nomeCenaMinigame = "JogoFio"; // ajuste conforme sua cena
    public GameObject textoInteracao;

    private bool jogadorPerto = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            // Salva a posição e rotação do jogador antes de trocar de cena (opcional)
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameState.posicaoRetorno = player.transform.position;
            GameState.rotacaoRetorno = player.transform.rotation;

            SceneManager.LoadScene(nomeCenaMinigame);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            textoInteracao.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            textoInteracao.SetActive(false);
        }
    }
}
