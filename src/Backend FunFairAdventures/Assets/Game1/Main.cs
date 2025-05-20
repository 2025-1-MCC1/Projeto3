using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;
    public int switchCount;
    public GameObject winText;
    public string cenaPrincipal = "Jogo"; // Nome da sua cena principal
    public float tempoParaVoltar = 2f; // Tempo em segundos antes de voltar à cena principal

    private int onCount = 0;
    private bool minigameConcluido = false;

    // Variáveis estáticas para armazenar a posição original do jogador, acessíveis por outros scripts
    public static Vector3 posicaoOriginalJogador { get; private set; }
    public static Quaternion rotacaoOriginalJogador { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Garante que o cursor está visível e pode ser movido livremente
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Método para salvar a posição do jogador antes de iniciar o minigame
    public static void SalvarPosicaoJogador(Vector3 posicao, Quaternion rotacao)
    {
        posicaoOriginalJogador = posicao;
        rotacaoOriginalJogador = rotacao;
    }

    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == switchCount && !minigameConcluido)
        {
            minigameConcluido = true;
            winText.SetActive(true);

            // Inicia a contagem regressiva para voltar à cena principal
            StartCoroutine(VoltarParaCenaPrincipal());
        }
    }

    private IEnumerator VoltarParaCenaPrincipal()
    {
        // Aguarda o tempo definido
        yield return new WaitForSeconds(tempoParaVoltar);

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
            // Procura pelo jogador e reposiciona
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            if (jogador != null)
            {
                jogador.transform.position = posicaoOriginalJogador;
                jogador.transform.rotation = rotacaoOriginalJogador;
            }

            // Remove o callback para evitar chamadas múltiplas
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void Update()
    {
        // Garante que o cursor permanece visível durante todo o minigame
        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}