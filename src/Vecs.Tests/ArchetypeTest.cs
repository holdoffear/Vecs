namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeTest
    {
        World world;
        public ArchetypeTest()
        {
            world = new World();
        }
        [TestMethod]
        [DataRow(new int[]{}, new bool[]{}, new string[]{})]
        [DataRow(new int[]{3}, new bool[]{false}, new string[]{})]
        [DataRow(new int[]{3}, new bool[]{false}, new string[]{"stringA", "stringB"})]
        public void AddCorrectNumberOfArchetypes(int[] numbers, bool[] booleans, string[] strings)
        {
            Query query = world.CreateQuery();
            Entity entity = world.CreateEntity();
            int expected = 1;
            expected = numbers.Length > 0 ? expected+1 : expected;
            expected = booleans.Length > 0 ? expected+1 : expected;
            expected = strings.Length > 0 ? expected+1 : expected;

            for (int i = 0; i < numbers.Length; i++)
            {
                query.AddComponent(ref entity, numbers[i]);
            }
            for (int i = 0; i < booleans.Length; i++)
            {
                query.AddComponent(ref entity, booleans[i]);
            }
            for (int i = 0; i < strings.Length; i++)
            {
                query.AddComponent(ref entity, strings[i]);
            }

            int result = world.Archetypes.Count;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ComponentsAddedCorrectly()
        {

        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, 1)]
        [DataRow(new Type[]{}, 10)]
        [DataRow(new Type[]{typeof(int), typeof(bool)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)}, 0)]
        public void Length_MultipleEntity_ReturnsSingleNumber(Type[] types, int iterations)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Archetype archetype = new Archetype(archetypeId);
            for (int i = 0; i < iterations; i++)
            {
                archetype.AddEntity(new Entity(IdGenerator.Guid));  
            }
            //major error, when adding an entity no default data for the components are made, correct this to pass the test
            int result = archetype.Entities.Count;
            foreach (Type type in archetype.ArchetypeData.Keys)
            {
                Console.WriteLine(type);
                Assert.AreEqual(result, archetype.ArchetypeData[type].GetList().Count);
            }

            Assert.AreEqual(iterations, result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, 1000)]
        [DataRow(new Type[]{}, 1)]
        [DataRow(new Type[]{typeof(int), typeof(bool)}, 2)]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)}, 0)]
        public void AddEntity_MultipleEntity_ReturnsEntity(Type[] types, int iterations)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Archetype archetype = new Archetype(archetypeId);
            List<Entity> entities = new List<Entity>();
            bool result = true;
            for (int i = 0; i < iterations; i++)
            {
                entities.Add(new Entity(IdGenerator.Guid));
            }
            for (int i = 0; i < entities.Count; i++)
            {
                archetype.AddEntity(entities[i]);  
            }
            for (int i = 0; i < archetype.Entities.Count; i++)
            {
                result = archetype.Entities.Contains(entities[i]) && result;  
            }

            Assert.IsTrue(result);
        }
        // [TestMethod]
        // [DataRow(new Type[]{typeof(bool), typeof(int)}, false, 7)]
        // public void GetComponent_MultipleValues_ReturnsComponent(Type[] types, dynamic arg1, dynamic arg2)
        // {
        //     ArchetypeId archetypeId = new ArchetypeId(types);
        //     Archetype archetype = new Archetype(archetypeId);
        //     for (int i = 0; i < types.Length; i++)
        //     {
        //         Entity entity = new Entity(IdGenerator.Guid);
        //         archetype.AddEntity(entity);
        //         archetype.SetComponent(entity, arg1);
        //         archetype.SetComponent(entity, arg2);
        //         Assert.AreEqual(archetype.GetComponent(entity, arg1.GetType()), arg1);
        //         Assert.AreEqual(archetype.GetComponent(entity, arg2.GetType()), arg2);
        //     }
        // }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, 1000)]
        [DataRow(new Type[]{}, 10)]
        [DataRow(new Type[]{typeof(int), typeof(bool)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)}, 0)]
        public void RemoveEntity_MultipleEntity_ReturnsEntity(Type[] types, int iterations)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Archetype archetype = new Archetype(archetypeId);
            Entity[] entities;
            for (int i = 0; i < iterations; i++)
            {
                archetype.AddEntity(world.CreateEntity());  
            }
            entities = archetype.Entities.ToArray();
            for (int i = 0; i < entities.Length; i++)
            {
                archetype.RemoveEntity(entities[i]);  
            }

            int result = archetype.Entities.Count;

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        [DataRow(new Type[]{}, 10)]
        [DataRow(new Type[]{typeof(int)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)}, 0)]
        public void GetComponents_EntityAndComponents_ReturnsTrue(Type[] types, int iterations)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Archetype archetype = new Archetype(archetypeId);
            Entity[] entities;
            for (int i = 0; i < iterations; i++)
            {
                archetype.AddEntity(new Entity(IdGenerator.Guid));  
            }
            entities = archetype.Entities.ToArray();
            for (int i = 0; i < entities.Length; i++)
            {
                archetype.RemoveEntity(entities[i]);  
            }

            int result = archetype.Entities.Count;

            Assert.AreEqual(0, result);
        }
    }
}