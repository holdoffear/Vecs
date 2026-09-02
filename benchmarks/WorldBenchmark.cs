using BenchmarkDotNet.Attributes;
using Vecs;
public class WorldBenchmark
{
    [Params(100)]
    public int Count;
    // private World World;
    // public WorldBenchmark()
    // {
    //     World = new(100000);
    // }
    // public WorldBenchmark(int count)
    // {
    //     Count = count;
    //     World = new(Count);
    // }
    [GlobalSetup]
    // public void Setup()
    // {
    //     World = new(Count);
    // }
    // [Benchmark]
    // public void AddComponent()
    // {
    //     World = new(1);
    //     var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1});
    //     World.Add(entity,  new HealthComponent(){Health = 1});
    //     World.Add(entity,  new VelocityComponent(){Velocity = 1});
    // }
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