using System.Collections;
using UnityEngine;

public class CrazyTeacup : MonoBehaviour
{
    public float baseRotationSpeed = 30f;
    public float cupRotationSpeed = 90f;
    public float pauseDuration = 10f;

    private bool rotating = true;

    void Start()
    {
        // Inicia o ciclo de rotação
        StartCoroutine(RotationCycle());
    }

    void Update()
    {
        if (!rotating) return;

        // Rotaciona a base
        transform.Rotate(Vector3.up * baseRotationSpeed * Time.deltaTime);

        // Rotaciona cada xícara individualmente
        foreach (Transform cup in transform)
        {
            cup.Rotate(Vector3.up * cupRotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator RotationCycle()
    {
        while (true)
        {
            rotating = true;
            yield return new WaitForSeconds(10f); // Roda por 10 segundos

            rotating = false;
            yield return new WaitForSeconds(pauseDuration); // Pausa por 10 segundos
        }
    }
}
