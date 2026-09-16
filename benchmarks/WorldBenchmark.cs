using BenchmarkDotNet.Attributes;
using Vecs;
public class WorldBenchmark
{
    // [Params(1, 100)]
    public int Count;
    public IEnumerable<object[]> GetSetEntityWithFiveComponentsData()
    {
        World world = new(100);
        Entity[] entities = new Entity[100];
        for (int i = 0; i < 100; i++)
        {
            entities[i] = world.CreateEntity('a', 1.0f, 1.0d, "value", 1);
        }
        yield return new object[] {world, entities};
    }
    public IEnumerable<object[]> AddComponentData()
    {
        World world = new(100);
        Entity[] entities = new Entity[100];
        for (int i = 0; i < 100; i++)
        {
            entities[i] = world.CreateEntity(new HealthComponent(100));
        }
        yield return new object[] {world, entities};
    }
    // [Benchmark]
    public void AddOneComponent()
    {
        World World = new World(Count);
        var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1});
        World.AddComponent(ref entity,  new HealthComponent(1));
    }
    [Benchmark]
    [ArgumentsSource(nameof(AddComponentData))]
    public void AddFiveComponents(World world, Entity[] entities)
    {
        for (int i = 0; i < entities.Length; i++)
        {
            world.AddComponent(ref entities[i],  new StaminaComponent(100));
            world.AddComponent(ref entities[i],  new ManaComponent(100));
            world.AddComponent(ref entities[i],  new HungerComponent(100));
            world.AddComponent(ref entities[i],  new VelocityComponent(10));
            world.AddComponent(ref entities[i],  new PositionComponent(10, 10));
        }
    }
    // [Benchmark]
    public void CreateEntityWithOneComponent()
    {
        World World = new World(Count);
        for (int i = 0; i < Count; i++)
        {
            var entity = World.CreateEntity(new PositionComponent(1, 1));
        }
    }
    // [Benchmark]
    public void CreateEntityWithThreeComponents()
    {
        World World = new World(Count);
        for (int i = 0; i < Count; i++)
        {
            var entity = World.CreateEntity(new PositionComponent(1, 1), new HealthComponent(100), new VelocityComponent(10));
        }
    }
    // [Benchmark]
    // [ArgumentsSource(nameof(GetSetEntityWithFiveComponentsData))]
    public void GetSetEntityWithFiveComponents(World world, Entity[] entities)
    {
        for (int i = 0; i < entities.Length; i++)
        {
            world.SetComponent(entities[i], world.GetComponent<char>(entities[i]));
            world.SetComponent(entities[i], world.GetComponent<float>(entities[i]));
            world.SetComponent(entities[i], world.GetComponent<double>(entities[i]));
            world.SetComponent(entities[i], world.GetComponent<string>(entities[i]));
            world.SetComponent(entities[i], world.GetComponent<int>(entities[i]));
        }
    }
    // [Benchmark]
    public void CreateWorld()
    {
        World world = new(Count);
    }
}