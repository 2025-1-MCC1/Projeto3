using UnityEngine;

public class CavaloCarrossel : MonoBehaviour
{
    public float amplitude = 0.5f;       // Distância lateral máxima
    public float velocidade = 2f;        // Velocidade do movimento

    private Vector3 posicaoInicial;
    private float offsetFase;

    void Start()
    {
        posicaoInicial = transform.localPosition;

        // Cria uma diferença de fase entre os cavalos
        offsetFase = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float deslocamento = Mathf.Sin(Time.time * velocidade + offsetFase) * amplitude;

        // Movimento lateral (mude o eixo se necessário)
        transform.localPosition = posicaoInicial + new Vector3(deslocamento, 0, 0);
    }
}
