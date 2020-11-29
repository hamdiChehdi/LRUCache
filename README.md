# Least Recently Used (LRU) cache

Generic LRUCache implement using DoubleLinkedList + Dictionary to achieve constant time complexity:

- LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
- int get(T key) Return the value of the key if the key exists, otherwise return -1.
- void put(T key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key

get and put in O(1) time complexity

https://leetcode.com/problems/lru-cache/
