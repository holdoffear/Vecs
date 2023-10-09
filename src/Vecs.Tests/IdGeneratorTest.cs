namespace Vecs.Tests
{
    [TestClass]
    public class IdGeneratorTest
    {
        [TestMethod]
        [DataRow(2)]
        [DataRow(100)]
        [DataRow(10000)]
        public void Guid_GuidIsUnique_ReturnsTrue(int iterations)
        {
            HashSet<long> guids = new HashSet<long>();
            bool result = true;
            for (var i = 0; i < iterations; i++)
            {
                result = guids.Add(IdGenerator.Guid) && result;
            }

            Assert.IsTrue(result);
        }
    }
}