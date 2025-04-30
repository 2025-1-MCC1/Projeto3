using UnityEngine;
using System.Collections;

public class ElevadorBrinquedo : MonoBehaviour
{
    public Transform pontoCima;
    public Transform pontoBaixo;
    public float velocidade = 2f;
    public float tempoEspera = 2f;

    private Vector3 destinoAtual;

    void Start()
    {
        destinoAtual = pontoCima.position;
        StartCoroutine(MovimentarElevador());
    }

    IEnumerator MovimentarElevador()
    {
        while (true)
        {
            while (Vector3.Distance(transform.position, destinoAtual) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoAtual, velocidade * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tempoEspera);

            destinoAtual = destinoAtual == pontoCima.position ? pontoBaixo.position : pontoCima.position;
        }
    }
}
