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
        public void ConstructorCorrectlyAddsTypeToArchetype(Type[] inputTypeArray, Type inputType)
        {
            ArchetypeId archetypeId;
            int count = 1;
            if (inputTypeArray.Contains(inputType) == true)
            {
                count = 0;
            }
            archetypeId = new ArchetypeId(inputTypeArray, inputType);

            bool result = archetypeId.Types.Count() == inputTypeArray.Length + count;
            Assert.IsTrue(result);

            int typeCount = archetypeId.Types.Count(x => x == inputType);
            Assert.AreEqual(1, typeCount);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(int))]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(bool))]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, typeof(string))]
        public void Contains_SingleType_ReturnsTrue(Type[] input, Type expected)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            int result = archetypeId.Types.Count(x => x == expected);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)}, 3)]
        [DataRow(new Type[]{typeof(int), typeof(string)}, 2)]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(string)}, 2)]
        public void ConstructorCorrectlyCreatesTypesWithNoDuplicates(Type[] input, int expected)
        {
            ArchetypeId archetypeId = new ArchetypeId(input);
            int result = archetypeId.Types.Count;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int), typeof(string), typeof(bool)})]
        [DataRow(new Type[]{typeof(int), typeof(string)})]
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
