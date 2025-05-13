using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomPatrol : MonoBehaviour
{
    [Header("Patrulha")]
    public Transform patrolCenter;      // Centro da patrulha (opcional)
    public float patrolRadius = 10f;    // Raio da área de patrulha
    public float waitTime = 2f;         // Tempo de espera ao chegar no destino

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
        // Define o ponto base (centro) da patrulha
        Vector3 basePosition = patrolCenter != null ? patrolCenter.position : transform.position;

        // Gera um ponto aleatório dentro do raio definido
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection.y = 0; // Mantém no plano horizontal
        Vector3 targetPosition = basePosition + randomDirection;

        // Garante que o ponto é navegável no NavMesh
        if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            // Pequeno desvio para reduzir sobreposição com outros NPCs
            Vector3 finalPosition = hit.position + (Random.insideUnitSphere * 0.5f);
            finalPosition.y = hit.position.y;

            agent.SetDestination(finalPosition);
        }
    }
}
