using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafoTest : MonoBehaviour
{

    public SimplyLinkedList<ControlNode> allNode;
    public GameObject nodePrefab;
    GameObject currentNode;
    public ControlNode currentNodeControl;
    public DogScript Enemy;
    void Awake()
    {

        allNode = new SimplyLinkedList<ControlNode>();
        GenerateNode();
    }
    void Start()
    {
        GeneratePath();
        currentNodeControl = allNode.ObtainNodeAtPosition(0);
        Enemy.ChangeMovePosition(currentNodeControl.gameObject.transform.position);
    }
    void AddNode(float positionx, float positiony, int nodeTag)
    {
        currentNode = Instantiate(nodePrefab, transform.position, transform.rotation);
        currentNode.transform.SetParent(transform);
        currentNode.GetComponent<ControlNode>().SetInitialValues(positionx, positiony, nodeTag);
        allNode.InsertNodeAtStart(currentNode.GetComponent<ControlNode>());
    }

    void AddNodeAdjacent(int nodeTag, int[] allAdjacentTags)
    {
        ControlNode selectedNode = SearchNode(nodeTag);

        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddNodeAdjacent(SearchNode(allAdjacentTags[i]));
        }
    }
    ControlNode SearchNode(int nodeTag)
    {
        int position = 0;
        for (int i = 0; i < allNode.length; i++)
        {
            if (allNode.ObtainNodeAtPosition(i).nodeTag == nodeTag)
            {
                position = i;
                break;
            }
        }
        return allNode.ObtainNodeAtPosition(position);
    }
    public void GeneratePath()
    {
        AddNodeAdjacent(0, new int[] { 1 });
        AddNodeAdjacent(1, new int[] { 2, 3 });
        AddNodeAdjacent(2, new int[] { 3 });
        AddNodeAdjacent(3, new int[] { 4 });
        AddNodeAdjacent(4, new int[] { 0, });
    }
    void GenerateNode()
    {
        AddNode(12f,28f,0);
        AddNode(-2, 32f, 1);
        AddNode(7.9f, 8.9f, 2);
        AddNode(18f, -12f, 3);
        AddNode(-16f, 11f, 4);
    }
}
