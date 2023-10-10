namespace Vecs.Tests
{
    [TestClass]
    public class ArchetypeTest
    {
        [TestMethod]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 3)]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 0)]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 7)]
        public void CreateSpan_Array_ReturnsArray(int[] array, int lastIndex)
        {
            Span<int> newSpan = Archetype.CreateSpan(array, 0, lastIndex);

            int result = newSpan.Length;

            Assert.AreEqual(lastIndex, result);
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

            int result = archetype.Entities.Length;

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
            for (int i = 0; i < archetype.Entities.Length; i++)
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
            Span<Entity> entities;
            for (int i = 0; i < iterations; i++)
            {
                archetype.AddEntity(new Entity(IdGenerator.Guid));  
            }
            entities = archetype.Entities;
            for (int i = 0; i < entities.Length; i++)
            {
                archetype.RemoveEntity(entities[i]);  
            }

            int result = archetype.Entities.Length;

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        [DataRow(new Type[]{typeof(int)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool)}, 1000)]
        [DataRow(new Type[]{typeof(int), typeof(bool), typeof(string)}, 0)]
        public void GetComponents_EntityAndComponents_ReturnsTrue(Type[] types, int iterations)
        {
            ArchetypeId archetypeId = new ArchetypeId(types);
            Archetype archetype = new Archetype(archetypeId);
            Span<Entity> entities;
            for (int i = 0; i < iterations; i++)
            {
                archetype.AddEntity(new Entity(IdGenerator.Guid));  
            }
            Entity entity = new Entity(IdGenerator.Guid);
            entities = archetype.Entities;
            for (int i = 0; i < entities.Length; i++)
            {
                archetype.RemoveEntity(entities[i]);  
            }

            int result = archetype.Entities.Length;

            Assert.AreEqual(0, result);
        }
    }
}