using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public Transform player; // Oyuncunun transform'u
    public float chaseDistance = 5f; // Oyuncuyu kovalamaya başlayacağı mesafe
    private NavMeshAgent agent;
    private Vector3 randomDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            // Oyuncuyu kovala
            agent.destination = player.position;
        }
        else
        {
            // Rastgele dolaş
            if (agent.remainingDistance < 0.5f)
            {
                SetRandomDestination();
            }
        }
    }

    void SetRandomDestination()
    {
        float range = 10f;
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, range, 1);
        randomDestination = hit.position;
        agent.SetDestination(randomDestination);
    }
}