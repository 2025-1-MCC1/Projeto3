using UnityEngine;
using System.Collections;

public class MontanhaRussaController : MonoBehaviour
{
    public float velocidade = 50f;           // Velocidade da montanha-russa
    public float duracaoVolta = 5f;          // Tempo da volta (em segundos)
    public float tempoAberturaCintos = 10f;  // Tempo até abertura dos cintos

    private bool estaEmMovimento = false;
    private Vector3 direcao = Vector3.forward;

    void Start()
    {
        StartCoroutine(IniciarVolta());
    }

    IEnumerator IniciarVolta()
    {
        Debug.Log("🎢 Embarque autorizado. Fechando cintos...");
        yield return new WaitForSeconds(2f);

        Debug.Log("🔒 Cintos fechados. Preparando para partida!");
        yield return new WaitForSeconds(1f);

        Debug.Log("🚀 Iniciando o percurso!");
        estaEmMovimento = true;

        float tempoDecorrido = 0f;
        while (tempoDecorrido < duracaoVolta)
        {
            transform.Translate(direcao * velocidade * Time.deltaTime);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        estaEmMovimento = false;
        Debug.Log("🛑 Volta concluída. Parando o carrinho...");
        yield return new WaitForSeconds(2f);

        Debug.Log("⏳ Aguardando liberação dos cintos...");
        float contagemRegressiva = tempoAberturaCintos;
        while (contagemRegressiva > 0)
        {
            Debug.Log($"⌛ Abrindo cintos em {Mathf.CeilToInt(contagemRegressiva)} segundos...");
            yield return new WaitForSeconds(1f);
            contagemRegressiva -= 1f;
        }

        Debug.Log("🔓 Cintos abertos. Pode desembarcar com cuidado!");
        Debug.Log("🎠 Obrigado por usar a Montanha-Russa Turbo X!");
    }
}
