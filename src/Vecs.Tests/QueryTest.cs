namespace Vecs.Tests
{
    [TestClass]
    public class QueryTest
    {
        public static IEnumerable<object[]> WorldData
        {
            get
            {
                return new[]
                {
                    new object[]
                    {

                    }
                };
            }
        }
        public World CreateWorld()
        {
            World world = new World();
            for (int i = 0; i < 1000; i++)
            {
                world.CreateEntity();
            }
            return world;
        }
        [TestMethod]
        [DataRow()]
        public void With()
        {
            World world = new World();
            Query query = new Query(world);
            query.With(new Type[]{typeof(int)});

            bool result = query.WithComponents.Contains(typeof(int));
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow()]
        public void Foreach()
        {
            World world = new World();
            Entity entity = new Entity(3);
            entity.ArchetypeId = new ArchetypeId(new Type[]{typeof(Mana)});
            world.AddEntity(entity);
            Archetype archetype = world.GetArchetype(entity.ArchetypeId);

            Query query = new Query(world);
            query.With(new Type[]{typeof(Mana)});
            query.Foreach((ref Mana mana) =>
            {
                mana.Amount = 1;
                Assert.AreEqual(mana.Amount, archetype.GetComponent<Mana>(entity).Amount);
            });
        }
        [TestMethod]
        [DataRow()]
        public void AddComponent()
        {
            World world = new World();
            Query query = new Query(world);
            Entity entity = world.CreateEntity();
            int num = 4;
            entity = query.AddComponent(ref entity, num);

            Archetype archetype = world.GetArchetype(entity.ArchetypeId);
            int result = archetype.GetComponent<int>(entity);
            Assert.AreEqual(num, result);
        }
    }

    struct Mana
    {
        public int Amount;
        Mana(int amount)
        {
            this.Amount = amount;
        }
    }
}