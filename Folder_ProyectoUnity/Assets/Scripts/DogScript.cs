using UnityEngine;
using UnityEngine.AI;

public class DogScript : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool forward = true;

    public float detectionRadius = 5f;
    private Transform player;
    private bool playerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        // Añadir y configurar el SphereCollider
        SphereCollider detectionArea = gameObject.AddComponent<SphereCollider>();
        detectionArea.radius = detectionRadius;
        detectionArea.isTrigger = true;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0 || playerDetected)
        {
            return;
        }

        agent.destination = points[destPoint].position;

        if (forward)
        {
            destPoint++;
            if (destPoint >= points.Length)
            {
                destPoint = points.Length - 1;
                forward = false;
            }
        }
        else
        {
            destPoint--;
            if (destPoint < 0)
            {
                destPoint = 0;
                forward = true;
            }
        }
    }

    void Update()
    {
        if (!playerDetected)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        else if (player != null)
        {
            agent.destination = player.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            GotoNextPoint();
        }
    }
}
