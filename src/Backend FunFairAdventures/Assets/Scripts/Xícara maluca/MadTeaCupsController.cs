using System.Collections;
using UnityEngine;

public class MadTeaCupsController : MonoBehaviour
{
    [Header("Referências")]
    public Transform baseTransform;        // A base giratória do brinquedo
    public Transform[] teacups;            // As xícaras

    [Header("Configurações")]
    public float baseRotationSpeed = 20f;  // Velocidade da base
    public float cupRotationSpeed = 100f;  // Velocidade das xícaras
    public float activeTime = 10f;         // Tempo girando
    public float pauseTime = 10f;          // Tempo de pausa

    private bool isRunning = true;

    void Start()
    {
        StartCoroutine(RunTeacupsCycle());
    }

    void Update()
    {
        if (isRunning)
        {
            // Gira a base
            baseTransform.Rotate(Vector3.up * baseRotationSpeed * Time.deltaTime);

            // Gira cada xícara
            foreach (Transform cup in teacups)
            {
                cup.Rotate(Vector3.up * cupRotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator RunTeacupsCycle()
    {
        while (true)
        {
            // Liga o giro
            isRunning = true;
            yield return new WaitForSeconds(activeTime);

            // Para o giro por 10 segundos
            isRunning = false;
            yield return new WaitForSeconds(pauseTime);
        }
    }
}
