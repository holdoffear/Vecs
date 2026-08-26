namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeTest
    {
        World world = new World();

        public static IEnumerable<object[]> ArchetypeData
        {
            get
            {
                return new[]
                {
                    new object[] {new ArchetypeId(new Type[]{}), 5},
                    new object[] {new ArchetypeId(new Type[]{typeof(int)}), 0},
                    new object[] {new ArchetypeId(new Type[]{typeof(bool), typeof(string)}), 100}
                };
            }
        }

        [TestMethod]
        [DataRow(new int[]{}, new bool[]{}, new string[]{})]
        [DataRow(new int[]{3}, new bool[]{false}, new string[]{})]
        [DataRow(new int[]{3}, new bool[]{false}, new string[]{"stringA", "stringB"})]
        public void AddCorrectNumberOfArchetypes(int[] numbers, bool[] booleans, string[] strings)
        {
            Entity entity = world.CreateEntity();
            int expected = 1;
            expected = numbers.Length > 0 ? expected+1 : expected;
            expected = booleans.Length > 0 ? expected+1 : expected;
            expected = strings.Length > 0 ? expected+1 : expected;

            for (int i = 0; i < numbers.Length; i++)
            {
                world.AddComponent(ref entity, numbers[i]);
            }
            for (int i = 0; i < booleans.Length; i++)
            {
                world.AddComponent(ref entity, booleans[i]);
            }
            for (int i = 0; i < strings.Length; i++)
            {
                world.AddComponent(ref entity, strings[i]);
            }

            int result = world.Archetypes.Count;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DynamicData(nameof(ArchetypeData))]
        public void CorrectNumberOfEntities(ArchetypeId archetypeId, int entityCount)
        {
            Archetype archetype = new Archetype(archetypeId);
            for (int i = 0; i < entityCount; i++)
            {
                archetype.AddEntity(world.CreateEntity());
            }

            int result = archetype.Entities.Count;

            Assert.AreEqual(entityCount, result);
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
        public void ContainsCorrectEntity(Type[] types, int iterations)
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