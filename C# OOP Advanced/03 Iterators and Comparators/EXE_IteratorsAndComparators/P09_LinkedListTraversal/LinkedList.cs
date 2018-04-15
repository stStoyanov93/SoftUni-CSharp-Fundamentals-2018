using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;
    
    public LinkedList()
    {
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Node<T>(element);
        }
        else
        {
            var newTail = new Node<T>(element);
            newTail.PreviousNode = this.tail;

            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public bool Remove(T element)
    {
        if (this.Count == 0)
        {
            return false;
        }

        Node<T> node = this.head;
        Node<T> currentNode = this.head;
        Node<T> previousNode = null;

        while (node != null)
        {
            currentNode = node;

            if (node.Value.Equals(element))
            {
                if (previousNode != null)
                {
                    previousNode.NextNode = currentNode.NextNode;
                }
                else
                {
                    this.head = this.head.NextNode;
                }

                break;
            }

            previousNode = currentNode;
            node = node.NextNode;
        }

        int count = 0;
        Node<T> tempNode = this.head;

        while (tempNode != null)
        {
            count++;
            tempNode = tempNode.NextNode;
        }

        if (this.Count > count)
        {
            this.Count--;
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Node<T> NextNode { get; set; }

        public Node<T> PreviousNode { get; set; }        
    }
}
