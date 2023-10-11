namespace Vecs
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        [DataRow(1000)]
        [DataRow(0)]
        [DataRow(1)]
        public void CreateEntity_MultipleEntities_ReturnsTrue(int iterations)
        {
            World world = new World();
            Entity entity = world.CreateEntity();
            for (int i = 0; i < iterations-1; i++)
            {
                world.CreateEntity();
            }

            ArchetypeId result = world.GetArchetype(entity.ArchetypeId).ArchetypeId;

            Assert.AreEqual(entity.ArchetypeId, result);
            Assert.IsTrue(new ArchetypeId(new Type[]{typeof(DefaultArchetype)}) == result);
            // Assert.IsTrue(new ArchetypeId(new Type[]{typeof(DefaultArchetype)}).Equals(result));
            // Assert.AreEqual(new ArchetypeId(new Type[]{typeof(DefaultArchetype)}), result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(bool)})]
        [DataRow(new Type[]{typeof(bool), typeof(int)})]
        public void GetArchetypes_MultipleTypes_ReturnsTrue(Type[] types)
        {
            World world = new World();
            ArchetypeId archetypeId = new ArchetypeId(types);
            SortedSet<Type> archetypeIdTypes = archetypeId.Types;

            world.AddArchetype(archetypeId);
            foreach (Type type in archetypeIdTypes)
            {
                Archetype[] archetypes = world.GetArchetypes(type);
                for (int i = 0; i < archetypes.Length; i++)
                {
                    bool result = archetypes[i].ArchetypeId.Contains(type);
                    Assert.IsTrue(result);
                }
            }
        }
    }   
}