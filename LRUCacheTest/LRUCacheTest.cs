namespace LRUCacheTest
{
    using Xunit;
    using LRUCache;

    public class LRUCacheTest
    {
        [Fact]
        public void SimpleSenario()
        {
            var cache = new LRUCache<int>(2);

            cache.Put(1, 1);
            cache.Put(2, 2);

            Assert.Equal(1, cache.Get(1));

            cache.Put(3, 3);

            Assert.Equal(-1, cache.Get(2));

            cache.Put(4, 4);

            Assert.Equal(-1, cache.Get(1));
            Assert.Equal(3, cache.Get(3));
            Assert.Equal(4, cache.Get(4));
        }
    }
}
