using UnityEngine;
using TMPro;

public class ShowInstruction : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    void Start()
    {
        instructionText.text = "DICAS:  COLETE TODAS AS MOEDAS E ARRUME O PAINEL DE ENERGIA";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instructionText.gameObject.SetActive(false); // Esconde o texto quando apertar espaço
        }
    }
}