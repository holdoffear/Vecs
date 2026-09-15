using BenchmarkDotNet.Attributes;
using Vecs;
public class WorldBenchmark
{
    [Params(1, 100)]
    public int Count;
    [Benchmark]
    public void AddComponent()
    {
        World World = new World(Count);
        var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1});
        World.AddComponent(ref entity,  new HealthComponent(){Health = 1});
    }
    [Benchmark]
    public void CreateEntityWithOneComponent()
    {
        World World = new World(Count);
        for (int i = 0; i < Count; i++)
        {
            var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1});
        }
    }
    [Benchmark]
    public void CreateEntityWithThreeComponents()
    {
        World World = new World(Count);
        for (int i = 0; i < Count; i++)
        {
            var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1}, new HealthComponent(){Health = 1}, new VelocityComponent(){Velocity = 1});
        }
    }
    [Benchmark]
    public void CreateWorld()
    {
        World world = new(Count);
    }
}