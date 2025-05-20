using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    public string cenaPrincipal = "Jogo"; // Nome da sua cena principal

    private void Start()
    {
        // Adiciona o listener ao botão
        Button botao = GetComponent<Button>();
        if (botao != null)
        {
            botao.onClick.AddListener(VoltarParaCenaPrincipal);
        }
    }

    public void VoltarParaCenaPrincipal()
    {
        // Carrega a cena principal
        SceneManager.LoadScene(cenaPrincipal);

        // Registra callback para quando a cena terminar de carregar
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se a cena carregada é a cena principal
        if (scene.name == cenaPrincipal)
        {
            // Procura pelo jogador e reposiciona usando a posição salva pelo Main
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            if (jogador != null && Main.posicaoOriginalJogador != null)
            {
                jogador.transform.position = Main.posicaoOriginalJogador;
                jogador.transform.rotation = Main.rotacaoOriginalJogador;
            }

            // Remove o callback para evitar chamadas múltiplas
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}