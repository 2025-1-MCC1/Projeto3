using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelInteracao : MonoBehaviour
{
    public Text mensagemTexto; // Referência ao Text UI para exibir a mensagem
    public Canvas mensagemCanvas; // Canvas que contém o texto da mensagem
    public string nomeScenaMinigame = "JogoFio"; // Nome da cena do minigame

    public GerenciadorJogo gerenciador; // <<< NOVO: Referência ao contador de moedas

    private bool jogadorNoAlcance = false;

    private void Start()
    {
        if (mensagemCanvas != null)
            mensagemCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNoAlcance = true;

            if (mensagemCanvas != null)
            {
                if (gerenciador != null && gerenciador.moedasColetadas >= gerenciador.moedasNecessarias)
                {
                    mensagemTexto.text = "Aperte \"E\" para consertar o painel";
                }
                else
                {
                    mensagemTexto.text = "Colete todas as moedas para usar o painel!";
                }

                mensagemCanvas.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNoAlcance = false;

            if (mensagemCanvas != null)
                mensagemCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (jogadorNoAlcance && Input.GetKeyDown(KeyCode.E))
        {
            if (gerenciador != null && gerenciador.moedasColetadas >= gerenciador.moedasNecessarias)
            {
                // Salva a posição e rotação do jogador
                GameObject jogador = GameObject.FindGameObjectWithTag("Player");
                if (jogador != null)
                {
                    Main.SalvarPosicaoJogador(jogador.transform.position, jogador.transform.rotation);
                }

                // Libera o cursor e troca de cena
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                SceneManager.LoadScene(nomeScenaMinigame);
            }
            else
            {
                Debug.Log("⛔ Você ainda não coletou todas as moedas.");
            }
        }
    }
}
