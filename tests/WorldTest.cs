namespace Vecs.Tests;
[TestClass]
public class WorldTest
{
    public static IEnumerable<(World world, int num)> CreateEntityOneComponentData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            yield return (world, i);
        }
    }
    public static IEnumerable<(World world, Entity entity, int num)>GetComponentOneComponentData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i);
            yield return (world, entity, i);
        }
    }
    public static IEnumerable<(World world, Entity entity, int changeTo)>SetComponentOneComponentData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i);
            yield return (world, entity, count-i);
        }
    }
    public static IEnumerable<(World world, Entity entity, int changeTo)>SetComponentTwoComponentData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i);
            world.Add(entity, 'c');
            yield return (world, entity, count-i);
        }
    }
    [TestMethod]
    [DynamicData(nameof(CreateEntityOneComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(CreateEntityOneComponentData), dynamicDataSourceArguments: 100)]
    public void CreateEntity<T>(World world, T component)
    {
        Entity entity = world.CreateEntity(component);
        T value = world.GetComponent<T>(entity);
        Assert.AreEqual(component, value);
    }
    [TestMethod]
    [DynamicData(nameof(GetComponentOneComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(GetComponentOneComponentData), dynamicDataSourceArguments: 100)]
    public void GetComponent<T>(World world, Entity entity, T num)
    {
        T value = world.GetComponent<T>(entity);
        Assert.AreEqual(num, value);
    }
    [TestMethod]
    [DynamicData(nameof(SetComponentOneComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(SetComponentOneComponentData), dynamicDataSourceArguments: 100)]
    [DynamicData(nameof(SetComponentTwoComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(SetComponentTwoComponentData), dynamicDataSourceArguments: 100)]
    public void SetComponent<T>(World world, Entity entity, T newComponent)
    {
        world.SetComponent(entity, newComponent);
        T value = world.GetComponent<T>(entity);
        Assert.AreEqual(newComponent, value);
    }
}
