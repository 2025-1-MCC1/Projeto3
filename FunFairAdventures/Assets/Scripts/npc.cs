using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomPatrol : MonoBehaviour
{
    [Header("�rea de Patrulha")]
    public float limiteXMin = -30f;
    public float limiteXMax = 30f;
    public float limiteZMin = -30f;
    public float limiteZMax = 30f;

    public float waitTime = 2f;
    public float patrolRadius = 10f;

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Cada NPC come�a com uma espera aleat�ria
        timer = Random.Range(0f, waitTime);

        // Define uma posi��o inicial aleat�ria
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
        // Gera um ponto aleat�rio dentro dos limites
        float x = Random.Range(limiteXMin, limiteXMax);
        float z = Random.Range(limiteZMin, limiteZMax);
        Vector3 target = new Vector3(x, transform.position.y, z);

        // Garante que o ponto est� no NavMesh
        if (NavMesh.SamplePosition(target, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}