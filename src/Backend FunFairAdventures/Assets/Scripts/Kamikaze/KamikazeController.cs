using System.Collections;
using UnityEngine;

public class KamikazeController : MonoBehaviour
{
    public Transform arm;                        // Braço que gira
    public float swingSpeed = 50f;               // Velocidade da oscilação
    public float maxAngle = 135f;                // Ângulo máximo de cada lado
    public int swingsPerCycle = 2;               // Número de ciclos antes da pausa
    public float pauseDuration = 10f;

    public SeatBeltController2[] seatBelts;

    private bool isSwinging = true;

    void Start()
    {
        StartCoroutine(KamikazeRoutine());
    }

    IEnumerator KamikazeRoutine()
    {
        while (true)
        {
            // Movimento de ida e volta (1 ciclo = 2 lados)
            for (int i = 0; i < swingsPerCycle; i++)
            {
                yield return StartCoroutine(SwingToAngle(maxAngle));
                yield return StartCoroutine(SwingToAngle(-maxAngle));
            }

            // Espera o braço voltar para a posição inferior (próxima de 0°)
            yield return StartCoroutine(RotateToRestPosition());

            // Agora pode pausar e abrir cintos
            isSwinging = false;
            yield return StartCoroutine(PauseAndHandleBelts());

            isSwinging = true;
        }
    }

    IEnumerator RotateToRestPosition()
    {
        float restAngle = 0f;

        while (Mathf.Abs(NormalizeAngle(arm.localEulerAngles.z) - restAngle) > 1f)
        {
            float direction = Mathf.Sign(restAngle - NormalizeAngle(arm.localEulerAngles.z));
            float angleStep = swingSpeed * Time.deltaTime * direction;
            arm.Rotate(Vector3.forward, angleStep);
            yield return null;
        }

        // Corrige exatamente para o descanso
        Vector3 euler = arm.localEulerAngles;
        euler.z = 0f;
        arm.localEulerAngles = euler;
    }

    IEnumerator SwingToAngle(float targetAngle)
    {
        float direction = Mathf.Sign(targetAngle - arm.localEulerAngles.z);
        float currentAngle = NormalizeAngle(arm.localEulerAngles.z);
        float endAngle = NormalizeAngle(targetAngle);

        // Gira até o ângulo desejado
        while (Mathf.Abs(NormalizeAngle(arm.localEulerAngles.z) - endAngle) > 1f)
        {
            float angleStep = swingSpeed * Time.deltaTime * direction;
            arm.Rotate(Vector3.forward, angleStep);
            yield return null;
        }
    }

    IEnumerator PauseAndHandleBelts()
    {
        // Abre cintos
        foreach (var belt in seatBelts)
            belt.OpenBelt();

        yield return new WaitForSeconds(pauseDuration / 2f);

        // Fecha cintos
        foreach (var belt in seatBelts)
            belt.CloseBelt();

        yield return new WaitForSeconds(pauseDuration / 2f);
    }

    float NormalizeAngle(float angle)
    {
        angle = angle % 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
