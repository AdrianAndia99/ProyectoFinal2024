using System.Collections;
using UnityEngine;

public class ControlNode : MonoBehaviour
{
    SimplyLinkedList<ControlNode> allAdjacentesNodes;
    private float positionx, positiony;
    public int nodeValue;
    void Awake()
    {
        allAdjacentesNodes = new SimplyLinkedList<ControlNode>();
    }

    public void SetInitialValues(float positionx, float positiony, int nodeValue)
    {
        this.positionx = positionx;
        this.positiony = positiony;
        transform.position = new Vector3(positionx, 0.2f, positiony);
        this.nodeValue = nodeValue;

    }
    public void AddNodeAdjacent(ControlNode nodo)
    {
        allAdjacentesNodes.InsertNodeAtStart(nodo);
    }// aca p esto puede ser 0(1) - 0(N) si se recorre todo

    public ControlNode SelectNextNode()
    {
        int nodeSelect = Random.Range(0, allAdjacentesNodes.length);
        return allAdjacentesNodes.ObtainNodeAtPosition(nodeSelect);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            other.GetComponent<DogScript>().ChangeMovePosition(SelectNextNode().gameObject.transform.position);
        }
    }
}