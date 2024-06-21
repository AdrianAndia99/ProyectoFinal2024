using System.Collections;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Vector3 velocidad;
    private Node currentNode;
    public SimplyList linkedList;
    public float tiempoDireccion;
    private bool isPlayerInVision = false;
    private bool isCooldown = false;
    private float cooldownTime = 0.5f; // Ajusta este valor según sea necesario
    private float nodeThresholdDistance = 0.5f; // Distancia mínima para considerar que se ha alcanzado un nodo

    public PlayerScript player;

    public Transform Nodo1;
    public Transform Nodo2;
    public Transform Nodo3;
    public Transform Nodo4;
    public Transform Nodo5;
    public Transform Nodo6;
    public Transform Nodo7;
    public Transform Nodo8;
    public Transform Nodo9;
    public Transform Nodo10;
    public Transform Nodo11;
    public Transform Nodo12;
    public Transform Nodo13;
    public Transform Nodo14;
    public Transform Nodo15;
    public Transform Nodo16;
    public Transform Nodo17;

    private void Start()
    {
        linkedList = new SimplyList();

        // Agrega tus nodos aquí
        linkedList.AddNode(Nodo1);
        linkedList.AddNode(Nodo2);
        linkedList.AddNode(Nodo3);
        linkedList.AddNode(Nodo4);
        linkedList.AddNode(Nodo5);
        linkedList.AddNode(Nodo6);
        linkedList.AddNode(Nodo7);
        linkedList.AddNode(Nodo8);
        linkedList.AddNode(Nodo9);
        linkedList.AddNode(Nodo10);
        linkedList.AddNode(Nodo11);
        linkedList.AddNode(Nodo12);
        linkedList.AddNode(Nodo13);
        linkedList.AddNode(Nodo14);
        linkedList.AddNode(Nodo15);
        linkedList.AddNode(Nodo16);
        linkedList.AddNode(Nodo17);

        currentNode = linkedList.head;
    }

    private void Update()
    {
        if (isPlayerInVision)
        {
            MoveToPlayer();
        }
        else
        {
            MoveToNode();
        }
    }

    private void MoveToPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0f;
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocidad, tiempoDireccion);
        }
    }

    private void MoveToNode()
    {
        if (currentNode == null)
        {
            currentNode = linkedList.head;
        }

        if (currentNode != null)
        {
            Vector3 directionToNode = currentNode.point.transform.position - transform.position;
            directionToNode.y = 0f;
            transform.rotation = Quaternion.LookRotation(directionToNode);
            transform.position = Vector3.SmoothDamp(transform.position, currentNode.point.transform.position, ref velocidad, tiempoDireccion);

            // Verifica si está lo suficientemente cerca del nodo
            if (Vector3.Distance(transform.position, currentNode.point.transform.position) < nodeThresholdDistance)
            {
                if (currentNode.nextNode != null)
                {
                    currentNode = currentNode.nextNode;
                }
                else
                {
                    currentNode = linkedList.head; // Reinicia el ciclo si no hay más nodos
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nodo" && !isCooldown)
        {
            StartCoroutine(NodeCooldown());
            other.enabled = false; // Deshabilita el collider del nodo alcanzado para evitar múltiples colisiones
        }
    }

    private IEnumerator NodeCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
