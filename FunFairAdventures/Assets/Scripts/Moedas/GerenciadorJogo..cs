using UnityEngine;
using TMPro;

public class GerenciadorJogo : MonoBehaviour
{
    public int moedasColetadas = 0;
    public int moedasNecessarias = 15;
    public int pontuacao = 0;

    public TextMeshProUGUI textoPontuacao;
    public CanvasGroup canvasPainelEnergia; // Usando CanvasGroup!

    void Start()
    {
        AtualizarTexto();
        BloquearPainel(); // Deixa visível mas bloqueado
    }

    public void ColetarMoeda()
    {
        moedasColetadas++;
        AtualizarTexto();

        if (moedasColetadas >= moedasNecessarias)
        {
            LiberarPainel();
        }
    }

    void AtualizarTexto()
    {
        textoPontuacao.text = $"Moedas: {moedasColetadas}";
    }

    void BloquearPainel()
    {
        canvasPainelEnergia.interactable = false;
        canvasPainelEnergia.blocksRaycasts = false;
    }

    void LiberarPainel()
    {
        canvasPainelEnergia.interactable = true;
        canvasPainelEnergia.blocksRaycasts = true;
        Debug.Log("Painel liberado para uso!");
    }
}