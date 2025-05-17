using UnityEngine;
using UnityEngine.SceneManagement;

public class InteracaoPainel : MonoBehaviour
{
    public string mensagemInteracao = "Aperte 'E' para consertar o painel";
    public string nomeCenaMinigame = "JogoFio";
    public float distanciaInteracao = 2f; // Dist�ncia m�xima para intera��o
    private GameObject jogador;
    private bool dentroDoRaio = false;
    private bool podeInteragir = false;

    // Refer�ncia para a UI de mensagem (voc� precisar� criar isso)
    public GameObject textoInteracaoUI;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player"); // Assumindo que seu jogador tem a tag "Player"
        if (textoInteracaoUI != null)
        {
            textoInteracaoUI.SetActive(false); // Garante que a mensagem comece desativada
        }
        else
        {
            Debug.LogError("Texto de intera��o UI n�o atribu�do no Painel de Energia!");
        }
    }

    void Update()
    {
        if (jogador != null)
        {
            float distancia = Vector3.Distance(transform.position, jogador.transform.position);

            if (distancia <= distanciaInteracao)
            {
                dentroDoRaio = true;
                if (Input.GetKeyDown(KeyCode.E) && podeInteragir)
                {
                    // Carrega a cena do minigame
                    SceneManager.LoadScene(nomeCenaMinigame);
                }
            }
            else
            {
                dentroDoRaio = false;
                podeInteragir = false;
            }

            // Atualiza a visibilidade da mensagem na UI
            if (textoInteracaoUI != null)
            {
                textoInteracaoUI.SetActive(dentroDoRaio);
                // Aqui voc� pode atualizar o texto da UI se precisar ser din�mico
                // textoInteracaoUI.GetComponent<UnityEngine.UI.Text>().text = mensagemInteracao;
            }
        }
        else
        {
            Debug.LogError("Jogador n�o encontrado. Certifique-se de que o jogador tem a tag 'Player'.");
        }
    }

    // Este m�todo � chamado quando outro collider entra neste trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = true;
        }
    }

    // Este m�todo � chamado quando outro collider sai deste trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = false;
            dentroDoRaio = false; // Garante que a mensagem desapare�a ao sair
            if (textoInteracaoUI != null)
            {
                textoInteracaoUI.SetActive(false);
            }
        }
    }
}