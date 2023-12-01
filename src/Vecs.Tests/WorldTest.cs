namespace Vecs.Tests
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
            Archetype archetype;
            World world = new World();
            Entity entity = world.CreateEntity();
            for (int i = 0; i < iterations-1; i++)
            {
                world.CreateEntity();
            }

            archetype = world.GetArchetype(entity.ArchetypeId);

            bool result = archetype.Entities.Contains(entity);

            Assert.IsTrue(result);
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
        [TestMethod]
        [DataRow(new Type[]{typeof(bool)})]
        [DataRow(new Type[]{typeof(bool), typeof(int)})]
        public void GetArchetypes_SameReference_ReturnsTrue(Type[] types)
        {
            World world = new World();
            ArchetypeId archetypeId = new ArchetypeId(types);
            SortedSet<Type> archetypeIdTypes = archetypeId.Types;

            world.AddArchetype(archetypeId);
            Entity entity = new Entity(3);
            foreach (Type type in archetypeIdTypes)
            {
                Archetype[] archetypes = world.GetArchetypes(type);
                for (int i = 0; i < archetypes.Length; i++)
                {
                    archetypes[i].AddEntity(entity);
                    bool result = world.GetArchetypes(type)[i].Entities.Contains(entity);
                    Assert.IsTrue(result);
                }
            }
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(bool)})]
        [DataRow(new Type[]{typeof(bool), typeof(int)})]
        public void RemoveArchetype_MultipleTypes_ReturnsTrue(Type[] types)
        {
            World world = new World();
            ArchetypeId archetypeId = new ArchetypeId(types);
            SortedSet<Type> archetypeIdTypes = archetypeId.Types;

            world.AddArchetype(archetypeId);
            world.RemoveArchetype(archetypeId);
            foreach (Type type in archetypeIdTypes)
            {
                Archetype[] archetypes = world.GetArchetypes(type);
                for (int i = 0; i < archetypes.Length; i++)
                {
                    bool result = archetypes[i].ArchetypeId.Contains(type);
                    Assert.IsFalse(result);
                }
            }
        }
        [TestMethod]
        [DataRow(1000)]
        [DataRow(0)]
        [DataRow(1)]
        public void RemoveEntity_MultipleEntities_ReturnsTrue(int iterations)
        {
            World world = new World();
            Entity[] entities = new Entity[iterations];
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = world.CreateEntity();
            }
            for (int i = 0; i < entities.Length; i++)
            {
                world.RemoveEntity(entities[i]);
                Archetype archetype = world.GetArchetype(entities[i].ArchetypeId);
                bool result = archetype.Entities.Contains(entities[i]);
                Assert.IsFalse(result);

                Assert.AreEqual(entities.Length - i-1, archetype.Entities.Count);
            }
        }
    }   
}