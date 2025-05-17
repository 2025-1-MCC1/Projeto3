using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelInteracao : MonoBehaviour
{
    public Text mensagemTexto; // Referência ao Text UI para exibir a mensagem
    public Canvas mensagemCanvas; // Canvas que contém o texto da mensagem
    public string nomeScenaMinigame = "JogoFio"; // Nome da cena do minigame

    private bool jogadorNoAlcance = false;

    private void Start()
    {
        // Inicialmente oculta a mensagem
        if (mensagemCanvas != null)
            mensagemCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player"))
        {
            jogadorNoAlcance = true;

            // Mostra a mensagem
            if (mensagemCanvas != null)
            {
                mensagemCanvas.enabled = true;
                mensagemTexto.text = "Aperte \"E\" para consertar o painel";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger é o jogador
        if (other.CompareTag("Player"))
        {
            jogadorNoAlcance = false;

            // Esconde a mensagem
            if (mensagemCanvas != null)
                mensagemCanvas.enabled = false;
        }
    }

    private void Update()
    {
        // Verifica se o jogador está no alcance e pressionou a tecla E
        if (jogadorNoAlcance && Input.GetKeyDown(KeyCode.E))
        {
            // Salva o estado do cursor para restaurar depois
            bool cursorVisivel = Cursor.visible;
            CursorLockMode cursorLockState = Cursor.lockState;

            // Salva a posição e rotação atual do jogador
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            if (jogador != null)
            {
                // Salva a posição do jogador na classe Main (minigame)
                Main.SalvarPosicaoJogador(jogador.transform.position, jogador.transform.rotation);
            }

            // Garante que o cursor estará visível no minigame
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Carrega a cena do minigame
            SceneManager.LoadScene(nomeScenaMinigame);
        }
    }
}