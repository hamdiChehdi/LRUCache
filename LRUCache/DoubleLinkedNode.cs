namespace LRUCache
{
    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode<T> prev;
        public DoubleLinkedNode<T> next;
        public T key;
        public int data;

        public DoubleLinkedNode(T key, int data)
        {
            this.key = key;
            this.data = data;
            prev = this;
            next = this;
        }
    }
}
