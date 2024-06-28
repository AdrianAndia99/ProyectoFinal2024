using UnityEngine;
using UnityEngine.AI;

public class DogScript : MonoBehaviour
{
    private NavMeshAgent agent;

    public float detectionRadius = 3.5f;
    public Transform player;
    private bool playerDetected = false;

    private SphereCollider detectionArea;

    //target
    [SerializeField]Vector3 TarjectPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        detectionArea = gameObject.GetComponent<SphereCollider>();
        detectionArea.radius = detectionRadius;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {

        //agent.destination = points[destPoint].position;
        agent.destination = TarjectPosition;
        /*if (forward)
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
        }*/
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
        if (other.gameObject.tag == ("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            playerDetected = false;
            GotoNextPoint();
        }
    }

    public void ChangeMovePosition(Vector3 destination)
    {
        TarjectPosition = destination;
    }
}