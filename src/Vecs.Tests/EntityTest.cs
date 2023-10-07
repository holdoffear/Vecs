namespace Vecs.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        [DataRow(new Type[]{typeof(int)})]
        [DataRow(new Type[]{})]
        [DataRow(new Type[]{typeof(int), typeof(float), typeof(string)})]
        public void PropertyArchetypeId_TypeArray_ReturnsSameTypeArray(Type[] inputTypeArray)
        {
            ArchetypeId archetypeId = new ArchetypeId(inputTypeArray);
            ArchetypeId separateArchetypeId = new ArchetypeId(inputTypeArray);
            Entity entity = new Entity(archetypeId);
            bool result = entity.ArchetypeId.Equals(separateArchetypeId);
            Assert.IsTrue(result);
        }
    }
}