namespace Vecs.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(1000)]
        public void EntityConstructor_Guid_ReturnDifferentEntity(int iterations)
        {
            HashSet<Entity> entities = new HashSet<Entity>();
            bool result = true;
            
            for (int i = 0; i < iterations; i++)
            {
                result = entities.Add(new Entity(IdGenerator.Guid)) && result;
            }

            Assert.IsTrue(result);
        }
        // [TestMethod]
        // [DataRow(new Type[]{typeof(int)})]
        // [DataRow(new Type[]{})]
        // [DataRow(new Type[]{typeof(int), typeof(float), typeof(string)})]
        // public void PropertyArchetypeId_TypeArray_ReturnsSameTypeArray(Type[] inputTypeArray)
        // {
        //     ArchetypeId separateArchetypeId = new ArchetypeId(inputTypeArray);
        //     Entity entity = new Entity(IdGenerator.Guid);
            
        //     bool result = entity.ArchetypeId.Equals(separateArchetypeId);

        //     Assert.IsTrue(result);
        // }
    }
}