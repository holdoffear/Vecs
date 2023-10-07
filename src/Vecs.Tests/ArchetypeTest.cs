namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeTest
    {
        [TestMethod]
        [DataRow(new Type[]{typeof(int)})]
        [DataRow(new Type[]{})]
        [DataRow(new Type[]{typeof(int), typeof(bool)})]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)})]
        public void AddEntity_SingleEntity_ReturnsEntity(Type[] inputTypeArray)
        {
            ArchetypeId archetypeId = new ArchetypeId(inputTypeArray);
            Entity entity = new Entity(archetypeId);
            Archetype archetype = new Archetype(archetypeId);
            archetype.AddEntity(entity);

            bool result = archetype.Entities.Contains(entity);

            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, new object[] {new Type[]{typeof(string)}})]
        public void RemoveEntity_SingleEntity_ReturnsTrue(Type[] a, Type[] b)
        {
            Console.WriteLine(a.GetType().ToString());
            Console.WriteLine(b.GetType().ToString());
            Assert.AreNotEqual(a, b);
        }
    }
}