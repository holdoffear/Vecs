using Vecs;

namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeIdTest
    {
        [TestMethod]
        [DataRow(new Type[0], 0)]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, 3)]
        [DataRow(new Type[]{typeof(int), typeof(string)}, 2)]
        public void Count_ReturnsSingleNumber(Type[] input, int expected)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            int result = archetypeId.Count;
            Assert.AreEqual(expected, result);
        }
    }
}
