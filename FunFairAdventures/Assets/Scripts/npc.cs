using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomPatrol : MonoBehaviour
{
    [Header("Patrulha")]
    public Transform patrolCenter;      // Centro da patrulha (opcional)
    public float patrolRadius = 10f;    // Raio da área de patrulha
    public float waitTime = 2f;         // Tempo de espera ao chegar no destino

    [Header("Limites de Movimento")]
    public float limiteXMin = -10f;    // Limite mínimo no eixo X
    public float limiteXMax = 10f;     // Limite máximo no eixo X
    public float limiteZMin = -10f;    // Limite mínimo no eixo Z
    public float limiteZMax = 10f;     // Limite máximo no eixo Z

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = waitTime;
        SetNewDestination();
    }

    void Update()
    {
        // Verifica se o agente chegou ao destino
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SetNewDestination();
                timer = waitTime;
            }
        }
    }

    void SetNewDestination()
    {
        Vector3 basePosition = patrolCenter != null ? patrolCenter.position : transform.position;

        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection.y = 0;

        float newX = Mathf.Clamp(basePosition.x + randomDirection.x, limiteXMin, limiteXMax);
        float newZ = Mathf.Clamp(basePosition.z + randomDirection.z, limiteZMin, limiteZMax);

        Vector3 targetPosition = new Vector3(newX, basePosition.y, newZ);

        // 🔧 Esta linha estava faltando!
        agent.SetDestination(targetPosition);
    }
}
