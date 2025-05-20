using UnityEngine;
using System.Collections;

public class BrinquedoController : MonoBehaviour
{
    public float tempoFuncionamento = 120f;
    private bool estaFuncionando = false;

    public MonoBehaviour[] scriptsParaAtivar;

    private void Start()
    {
        estaFuncionando = false;
        foreach (var script in scriptsParaAtivar)
            script.enabled = false;

        // gameObject.SetActive(false); // opcional
    }

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.wireTaskCompleted && !estaFuncionando)
            {
                LigarBrinquedo();
            }
            else if (!GameManager.Instance.wireTaskCompleted && estaFuncionando)
            {
                DesligarBrinquedo();
            }
        }
    }

    public void LigarBrinquedo()
    {
        if (!estaFuncionando)
        {
            estaFuncionando = true;

            foreach (var script in scriptsParaAtivar)
                script.enabled = true;

            gameObject.SetActive(true);

            StartCoroutine(TemporizadorFuncionamento());
        }
    }

    private IEnumerator TemporizadorFuncionamento()
    {
        yield return new WaitForSeconds(tempoFuncionamento);
        DesligarBrinquedo();
    }

    public void DesligarBrinquedo()
    {
        if (estaFuncionando)
        {
            estaFuncionando = false;

            foreach (var script in scriptsParaAtivar)
                script.enabled = false;

            // Se quiser deixar o brinquedo visível mesmo desligado, comente essa linha:
            // gameObject.SetActive(false);

            GameManager.Instance.wireTaskCompleted = false;
        }
    }
}
