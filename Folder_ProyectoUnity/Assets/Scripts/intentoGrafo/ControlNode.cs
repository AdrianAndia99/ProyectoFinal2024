using UnityEngine;

public class ControlNode : MonoBehaviour
{
    SimplyLinkedList<ControlNode> allAdjacentesNodes;
    private float positionx, positiony;
    public int nodeTag;
    void Awake()
    {
        allAdjacentesNodes = new SimplyLinkedList<ControlNode>();
    }

    public void SetInitialValues(float positionx, float positiony, int nodeTag)
    {
        this.positionx = positionx;
        this.positiony = positiony;
        transform.position = new Vector3(positionx, 0.2f, positiony);
        this.nodeTag = nodeTag;

    }
    public void AddNodeAdjacent(ControlNode nodo)
    {
        allAdjacentesNodes.InsertNodeAtStart(nodo);
    }

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