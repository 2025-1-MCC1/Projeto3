using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColetarMoedas : MonoBehaviour
{
    public int pontuacao = 0;
    public Text textoPontuacao;

    void Start()
    {
        textoPontuacao = GameObject.Find("TextoPontuacao").GetComponent<Text>();
        textoPontuacao.text = "🪙 Moedas: " + pontuacao;
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Moeda"))
        {
            Destroy(outro.gameObject);
            pontuacao++;
            textoPontuacao.text = "🪙 Moedas: " + pontuacao;
        }
    }
}