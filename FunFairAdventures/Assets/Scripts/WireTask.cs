using UnityEngine;
using UnityEngine.SceneManagement;

public class WireTaskTrigger : MonoBehaviour
{
    public string cenaDoMiniGame = "JogoFio";
    public GameObject textoInteracao;

    private bool jogadorPerto = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameState.posicaoRetorno = player.transform.position;
            GameState.rotacaoRetorno = player.transform.rotation;
            SceneManager.LoadScene(cenaDoMiniGame);
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

