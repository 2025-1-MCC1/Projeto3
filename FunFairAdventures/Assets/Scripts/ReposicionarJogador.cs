using UnityEngine;

public class ReposicionarJogador : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && GameState.posicaoRetorno != Vector3.zero)
        {
            player.transform.position = GameState.posicaoRetorno;
            player.transform.rotation = GameState.rotacaoRetorno;

            GameState.posicaoRetorno = Vector3.zero;
            GameState.rotacaoRetorno = Quaternion.identity;
        }
    }
}
