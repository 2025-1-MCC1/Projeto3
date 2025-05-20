using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    public void jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void AbrirOp��es()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOp��es()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }


    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit(); 
    }
} 