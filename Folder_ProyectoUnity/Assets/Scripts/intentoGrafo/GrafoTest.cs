using UnityEngine;

public class GrafoTest : MonoBehaviour
{

    public SimplyLinkedList<ControlNode> allNode;
    public GameObject nodePrefab;
    GameObject currentNode;
    ControlNode currentNodeControl;
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
        AddNodeAdjacent(0, new int[] { 1, 2});
        AddNodeAdjacent(1, new int[] { 2, 3});
        AddNodeAdjacent(2, new int[] { 3, 5});
        AddNodeAdjacent(3, new int[] { 4, 2});
        AddNodeAdjacent(4, new int[] { 3, 2});
        AddNodeAdjacent(5, new int[] { 2, 6});
        AddNodeAdjacent(6, new int[] { 7, 5});
        AddNodeAdjacent(7, new int[] { 8, 6});
        AddNodeAdjacent(8, new int[] { 6, 9});
        AddNodeAdjacent(9, new int[] { 8});
        AddNodeAdjacent(10,new int[] { 2});

    }
    void GenerateNode()
    {
        AddNode(-2, 32f, 0);
        AddNode(12f,28f,1);    
        AddNode(7.9f, 8.9f, 2);
        AddNode(18f, -12f, 3);
        AddNode(-8f, -16f, 4);
        AddNode(-16f, 11f, 5);
        AddNode(-36f, 12f,6);
        AddNode(-39f, 36f,7);
        AddNode(-42.5f,20f,8);
        AddNode(-48f,0.5f,9);
        AddNode(26f, 28f, 10);
    }
}