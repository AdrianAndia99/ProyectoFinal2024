using UnityEngine;
using UnityEngine.AI;

public class DogScript : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool forward = true;

    void Start()
    {
        SphereCollider detectionArea = gameObject.AddComponent<SphereCollider>();

        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
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
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}