using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform platform;            // A plataforma que sobe/desce
    public float topY = 23.31212f;              // Altura máxima
    public float bottomY = 1.812117f;            // Altura mínima
    public float upSpeed = 5f;            // Velocidade de subida
    public float downSpeed = 20f;         // Velocidade de descida
    public float topWaitTime = 2f;        // Espera no topo
    public float bottomWaitTime = 10f;    // Espera antes de subir
    public SeatBeltController[] seatBelts;

    private bool movingUp = true;

    void Start()
    {
        StartCoroutine(ElevatorRoutine());
    }

    IEnumerator ElevatorRoutine()
    {
        while (true)
        {
            // Subir
            yield return StartCoroutine(MovePlatform(topY, upSpeed));
            yield return new WaitForSeconds(topWaitTime);

            // Descer rápido
            yield return StartCoroutine(MovePlatform(bottomY, downSpeed));

            // Abrir cintos
            foreach (var belt in seatBelts) belt.OpenBelt();
            yield return new WaitForSeconds(5f);

            // Fechar cintos
            foreach (var belt in seatBelts) belt.CloseBelt();
            yield return new WaitForSeconds(bottomWaitTime - 5f);
        }
    }

    IEnumerator MovePlatform(float targetY, float speed)
    {
        Vector3 pos = platform.position;

        while (Mathf.Abs(platform.position.y - targetY) > 0.1f)
        {
            float step = speed * Time.deltaTime;
            pos.y = Mathf.MoveTowards(platform.position.y, targetY, step);
            platform.position = pos;
            yield return null;
        }
    }
}
