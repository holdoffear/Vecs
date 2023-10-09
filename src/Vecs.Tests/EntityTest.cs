namespace Vecs.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, typeof(int))]
        [DataRow(new Type[]{typeof(bool)}, typeof(bool))]
        [DataRow(new Type[]{typeof(int), typeof(float), typeof(string)}, typeof(float))]
        public void EntityConstructor_ArchetypeId_ReturnsArchetype(Type[] types, Type type)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Entity entity = new Entity(IdGenerator.Guid, archetypeId);
            bool result = entity.ArchetypeId.Contains(type);

            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)})]
        [DataRow(new Type[]{})]
        [DataRow(new Type[]{typeof(int), typeof(float), typeof(string)})]
        public void PropertyArchetypeId_TypeArray_ReturnsSameTypeArray(Type[] inputTypeArray)
        {
            ArchetypeId archetypeId = new ArchetypeId(inputTypeArray);
            ArchetypeId separateArchetypeId = new ArchetypeId(inputTypeArray);
            Entity entity = new Entity(IdGenerator.Guid, archetypeId);
            
            bool result = entity.ArchetypeId.Equals(separateArchetypeId);

            Assert.IsTrue(result);
        }
    }
}