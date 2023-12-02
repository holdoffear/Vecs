namespace Vecs.Tests
{
    [TestClass]
    public class QueryTest
    {
        Query query = new Query();
        public static IEnumerable<object[]> QueryData
        {
            get
            {
                return new[]
                {
                    new object[] {new Type[]{}, new Type[]{}},
                    new object[] {new Type[]{typeof(bool), typeof(long)}, new Type[]{}},
                    new object[] {new Type[]{}, new Type[]{typeof(int), typeof(bool)}},
                    new object[] {new Type[]{typeof(string)}, new Type[]{typeof(string)}},
                };
            }
        }
        [TestMethod]
        [DynamicData(nameof(QueryData))]
        public void WithHasCorrectCount(Type[] with, Type[] without)
        {
            query.With(with).Without(without);

            int result = query.WithComponents.Count;

            Assert.AreEqual(with.Length, result);
        }
        [TestMethod]
        [DynamicData(nameof(QueryData))]
        public void WithHasCorrectTypes(Type[] with, Type[] without)
        {
            query.With(with).Without(without);

            for (int i = 0; i < with.Length; i++)
            {
                int result = query.WithComponents.Count(x => x == with[i]);
                Assert.AreEqual(1, result);
            }           
        }
        [TestMethod]
        [DynamicData(nameof(QueryData))]
        public void WithoutHasCorrectCount(Type[] with, Type[] without)
        {
            query.With(with).Without(without);

            int result = query.WithoutComponents.Count;

            Assert.AreEqual(without.Length, result);
        }
        [TestMethod]
        [DynamicData(nameof(QueryData))]
        public void WithoutHasCorrectTypes(Type[] with, Type[] without)
        {
            query.With(with).Without(without);

            for (int i = 0; i < without.Length; i++)
            {
                int result = query.WithoutComponents.Count(x => x == without[i]);
                Assert.AreEqual(1, result);
            }           
        }
        [TestMethod]
        [DynamicData(nameof(QueryData))]
        public void Clear(Type[] with, Type[] without)
        {
            query.With(with).Without(without);
            query.Clear();
            int result = query.WithComponents.Count + query.WithoutComponents.Count;
            Assert.AreEqual(0, result);
        }
    }
}