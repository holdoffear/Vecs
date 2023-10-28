namespace Vecs.Tests
{
    [TestClass]
    public class QueryTest
    {
        public static IEnumerable<object[]> WorldData
        {
            get
            {
                World worldA = new World();
                World worldB = new World();
                World worldC = new World();
                Entity entityA = new Entity(3, new ArchetypeId(new Type[]{typeof(float), typeof(bool), typeof(double)}));
                Entity entityB = new Entity(4, new ArchetypeId(new Type[]{typeof(string)}));
                Entity entityC = new Entity(7, new ArchetypeId(new Type[]{typeof(int)}));

                worldA.AddEntity(entityA);
                worldA.AddEntity(entityB);
                worldB.AddEntity(entityA);
                worldB.AddEntity(entityB);
                worldB.AddEntity(entityC);
                return new[]
                {
                    new object[] {worldA},
                    new object[] {worldB},
                    new object[] {worldC},
                };
            }
        }
        public static World CreateWorld(object[] types)
        {
            World world = new World();
            for (int i = 0; i < 1000; i++)
            {
                world.CreateEntity();
            }
            return world;
        }
        [TestMethod]
        [DynamicData(nameof(WorldData))]
        public void With_TwoTypes_ReturnsTrue(World world)
        {
            Query query = new Query(world);
            query.With(new Type[]{typeof(int), typeof(float)});

            bool result = query.WithComponents.Contains(typeof(int));
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DynamicData(nameof(WorldData))]
        public void Foreach_SingleComponent_ReturnsTrue(World world)
        {
            Entity entity = new Entity(3);
            entity.ArchetypeId = new ArchetypeId(new Type[]{typeof(Mana), typeof(Health)});
            world.AddEntity(entity);
            Archetype archetype = world.GetArchetype(entity.ArchetypeId);

            Query query = new Query(world);
            query
            .With(new Type[]{typeof(Mana), typeof(Health)})
            .Without(new Type[]{typeof(Health)})
            .Foreach((ref Mana mana, ref Health health) =>
            {
                mana.Amount = 1;
                Assert.AreNotEqual(mana.Amount, archetype.GetComponent<Mana>(entity).Amount);
            });
        }
        [TestMethod]
        [DynamicData(nameof(WorldData))]
        public void AddComponent_SingleComponent_ReturnsTrue(World world)
        {
            Query query = new Query(world);
            Entity entity = world.CreateEntity();
            Mana mana = new Mana(3);
            Health health = new Health(10);
            entity = query.AddComponent(entity, mana);
            entity = query.AddComponent(entity, health);

            Archetype archetype = world.GetArchetype(entity.ArchetypeId);
            Mana result = archetype.GetComponent<Mana>(entity);
            Assert.AreEqual(mana, result);

            Assert.AreEqual(archetype.GetComponent<Health>(entity), health);
        }
    }

    struct Mana
    {
        public int Amount;
        public Mana(int amount)
        {
            this.Amount = amount;
        }
    }
    struct Health
    {
        public int Amount;
        public Health(int amount)
        {
            this.Amount = amount;
        }
    }
}