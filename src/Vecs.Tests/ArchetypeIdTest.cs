using Vecs;

namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeIdTest
    {
        [TestMethod]
        [DataRow(new Type[]{typeof(string), typeof(bool)}, typeof(int))]
        [DataRow(new Type[]{}, typeof(int))]
        [DataRow(new Type[]{typeof(string)}, typeof(int))]
        [DataRow(new Type[]{typeof(string), typeof(bool), typeof(float)}, typeof(int))]
        public void ArchetypeIdConstructor_ConstructType_ReturnsTrue(Type[] inputTypeArray, Type inputType)
        {
            ArchetypeId archetypeId = new ArchetypeId(inputTypeArray, inputType);
            bool result = archetypeId.Count == inputTypeArray.Length + 1;
            Assert.IsTrue(result);

            result = archetypeId.Contains(inputType);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(int))]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(bool))]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(string))]
        public void Contains_SingleType_ReturnsTrue(Type[] input, Type expected)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            bool result = archetypeId.Contains(expected);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(new Type[0], 0)]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, 3)]
        [DataRow(new Type[]{typeof(int), typeof(string)}, 2)]
        public void Count_TypeArray_ReturnsSingleNumber(Type[] input, int expected)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            int result = archetypeId.Count;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)})]
        [DataRow(new Type[]{typeof(int), typeof(string)})]
        [DataRow(new Type[]{})]
        public void TypesProperty_TypeArray_ReturnsSameTypeArray(Type[] input)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            Type[] result = archetypeId.GetTypes();
            Assert.AreEqual(input.Length, result.Length);
            for (int i = 0; i < input.Length; i++)
            {
                bool hasType = result.Contains(input[i]);
                Assert.IsTrue(hasType);
            }
        }
    }
}
