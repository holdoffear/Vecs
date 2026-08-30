using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Vecs;
public class Program
{
    [Params(1, 100)]
    public int Count = 0;
    public World World;
    public Program()
    {
        World = new(Count);
    }
    public Program(int count)
    {
        Count = count;
        World = new(Count);
    }
    // [Benchmark]
    // public void AddComponent()
    // {
    //     World = new(1);
    //     var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1});
    //     World.Add(entity,  new HealthComponent(){Health = 1});
    //     World.Add(entity,  new VelocityComponent(){Velocity = 1});
    // }
    [Benchmark]
    public void CreateEntityThreeComponents()
    {
        World = new(Count);
        for (int i = 0; i < Count; i++)
        {
            var entity = World.CreateEntity(new PositionComponent(){X = 1, Y = 1}, new HealthComponent(){Health = 1}, new VelocityComponent(){Velocity = 1});
        }
    }
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Program>();
    }
}