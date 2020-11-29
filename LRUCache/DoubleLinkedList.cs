namespace LRUCache
{
    using System.Collections.Generic;

    public class DoubleLinkedList<T>
    {
        // the head represent the Last Recently Used 
        private DoubleLinkedNode<T> head;
        // the head represent the Least Recently Used 
        private DoubleLinkedNode<T> tail;
        private Dictionary<T, DoubleLinkedNode<T>> NodebyKey;
        private int capacity;
        private int size;

        private bool stillHaveCapacity => size < capacity;
        private bool TheKeyExist(T key) => NodebyKey.ContainsKey(key);

        public DoubleLinkedList(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            NodebyKey = new Dictionary<T, DoubleLinkedNode<T>>();
        }

        public int get(T key)
        {
            if (TheKeyExist(key))
            {
                MoveNodeToHead(NodebyKey[key]);
                return NodebyKey[key].data;
            }

            return -1;
        }

        public void Add(T key, int data)
        {
            if (TheKeyExist(key))
            {
                // Update
                NodebyKey[key].data = data;
                MoveNodeToHead(NodebyKey[key]);
                return;
            }

            // Create
            EnsureCapacity();
            AddNewNode(key, data);
        }

        private void MoveNodeToHead(DoubleLinkedNode<T> usedNode)
        {
            if (usedNode == head)
            {
                return;
            }

            if (usedNode == tail)
            {
                tail = tail.prev;
                head = usedNode;
                return;
            }

            usedNode.prev.next = usedNode.next;
            usedNode.next.prev = usedNode.prev;

            ChangeHead(usedNode);
        }

        private void FrontAdd(DoubleLinkedNode<T> newNode)
        {
            // first Added node
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            ChangeHead(newNode);
        }

        private void ChangeHead(DoubleLinkedNode<T> newHead)
        {
            head.prev = newHead;
            tail.next = newHead;

            newHead.next = head;
            newHead.prev = tail;

            head = newHead;
        }

        // Evict operation
        private void DeleteLastUsed()
        {
            NodebyKey.Remove(tail.key);
            DeleteTail();
        }

        private void DeleteTail()
        {
            if (size == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                var beforeTail = tail.prev;
                beforeTail.next = head;
                head.prev = beforeTail;
                tail = beforeTail;
            }
        }

        private void AddNewNode(T key, int data)
        {
            var newNode = new DoubleLinkedNode<T>(key, data);
            NodebyKey.Add(key, newNode);
            FrontAdd(newNode);
        }

        // Check capacity if we don't have enought capacity,
        // evict the least recently used key (delete the tail in our case)
        private void EnsureCapacity()
        {
            if (stillHaveCapacity)
            {
                size++;
            }
            else
            {
                DeleteLastUsed();
            }
        }
    }
}
