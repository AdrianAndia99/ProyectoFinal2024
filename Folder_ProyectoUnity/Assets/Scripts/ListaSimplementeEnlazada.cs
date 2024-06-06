using UnityEngine;
public class ListaSimplementeEnlazada<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
            Next = null;
        }
    }

    Node Head;
    public int length = 0;

    public void InsertNodeAtStart(T value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            length++;
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
            length++;
        }
    }

    public void InsertNodeAtEnd(T value)
    {
        if (Head == null)
        {
            InsertNodeAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            Node newNode = new Node(value);
            last.Next = newNode;
            length++;
        }
    }

    public void InsertNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            InsertNodeAtStart(value);
        }
        else if (position == length - 1)
        {
            InsertNodeAtEnd(value);
        }
        else if (position >= length)
        {
            Debug.Log("No existe esa posicion.");
        }
        else
        {
            Node previus = Head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                previus = previus.Next;
                iterator++;
            }
            Node next = previus.Next;
            Node newNode = new Node(value);
            previus.Next = newNode;
            newNode.Next = next;
            length++;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Debug.Log("No se puede.");
        }
        else
        {
            Head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        if (Head == null)
        {
            ModifyAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == length - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position >= length)
        {
            Debug.Log("No existe esa posicion.");
        }
        else
        {
            Node nodePosition = Head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator++;
            }
            nodePosition.Value = value;
        }
    }

    public T ObtainNodeAtStart()
    {
        if (Head == null)
        {
            throw new System.Exception("La lista se encuentra vacia.");
        }
        else
        {
            return Head.Value;
        }
    }

    public T ObtainNodeAtEnd()
    {
        if (Head == null)
        {
            return ObtainNodeAtStart();
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last.Value;
        }
    }

    public T ObtainNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return ObtainNodeAtStart();
        }
        else if (position == length - 1)
        {
            return ObtainNodeAtEnd();
        }
        else if (position >= length)
        {
            throw new System.Exception("No existe esa posicion.");
        }
        else
        {
            Node nodePosition = Head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator++;
            }
            return nodePosition.Value;
        }
    }

    public void DeleteAtStart()
    {
        if (Head == null)
        {
            throw new System.Exception("La lista se encuentra vacia.");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = newHead;
            length--;
        }
    }

    public void DeleteAtEnd()
    {
        if (Head == null)
        {
            DeleteAtStart();
        }
        else
        {
            Node previusLastNode = Head;
            while (previusLastNode.Next.Next != null)
            {
                previusLastNode = previusLastNode.Next;
            }
            Node lastNode = previusLastNode.Next;
            lastNode = null;
            previusLastNode.Next = null;
            length--;
        }
    }
    public void DeleteNodeAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == length - 1)
        {
            DeleteAtEnd();
        }
        else if (position >= length)
        {
            throw new System.Exception("No existe esa posicion.");
        }
        else
        {
            Node previous = Head;
            int iterator = 0;
            while (iterator < position - 1)
            {
                previous = previous.Next;
                iterator++;
            }
            Node next = previous.Next.Next;
            Node nodePosition = previous.Next;
            nodePosition.Next = null;
            nodePosition = null;
            previous.Next = null;
            previous.Next = next;
            length--;
        }
    }
    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Debug.Log("\n");
    }
    public int GetCapacity()
    {
        return length;
    }
    public void PrintNextNodeValue(T value)
    {
        dynamic current = Head;

        while (current != null)
        {
            if (current.Value == value)
            {
                if (current.Next != null)
                {
                    Debug.Log(current.Next.Value);
                    return;
                }
                else
                {
                    throw new System.Exception("El nodo consultado no tiene un nodo siguiente.");
                }
            }
            current = current.Next;
        }
        throw new System.Exception("El nodo consultado no se encuentra en la lista.");
    }

    public void FindElement(T value)
    {

        dynamic current = Head;
        while (current != null)
        {
            if (current.Value == value)
            {
                Debug.Log("Se encontró el elemento.");
                return;
            }
            current = current.Next;
        }
        Debug.Log("No se encontró el elemento.");
    }
}