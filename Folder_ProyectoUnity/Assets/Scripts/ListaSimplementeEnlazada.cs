using System;
using UnityEngine;

public class Node
{
    public Transform point;
    public Node nextNode;
    public Node(Transform point)
    {
        this.point = point;
    }
}

public class SimplyList
{
    public Node head;
    public Node Head;

    public void AddNode(Transform point)
    {
        Node newNode = new Node(point);

        if (head == null)
        {
            head = newNode;
            Head = newNode;
        }
        else
        {
            Head.nextNode = newNode;
            Head = newNode;
        }
    }
}