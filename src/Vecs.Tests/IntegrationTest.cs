namespace Vecs.Tests
{
    [TestClass]
    class IntergrationTests
    {
        [TestMethod]
        public void World()
        {
            World world = new World();
            List<Entity> entities = new List<Entity>();
            for (int i = 0; i < 1000; i++)
            {
                entities.Add(world.CreateEntity());
            }
            for (int i = 0; i < entities.Count/2; i++)
            {

            }
        }
    }
}