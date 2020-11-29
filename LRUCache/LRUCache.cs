namespace LRUCache
{
    public class LRUCache<T>
    {
        private DoubleLinkedList<T> linkedList;

        public LRUCache(int capacity)
        {
            linkedList = new DoubleLinkedList<T>(capacity);
        }

        public int Get(T key)
        {
            return linkedList.get(key);
        }

        public void Put(T key, int value)
        {
            linkedList.Add(key, value);
        }
    }
}
