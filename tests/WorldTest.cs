namespace Vecs.Tests;
[TestClass]
public class WorldTest
{
    public static IEnumerable<(World world, Entity entity, int num)> AddComponentData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity('c');
            yield return (world, entity, i);
        }
    }
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
    public static IEnumerable<(World world, Entity entity)> RemoveEntityData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i);
            yield return (world, entity);
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
            world.AddComponent(ref entity, 'c');
            yield return (world, entity, count-i);
        }
    }
    [TestMethod]
    [DynamicData(nameof(AddComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(AddComponentData), dynamicDataSourceArguments: 100)]
    public void AddComponent<T>(World world, Entity entity, T component)
    {
        world.AddComponent(ref entity, component);
        T Value = world.GetComponent<T>(entity);
        Assert.AreEqual(component, Value);
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
    [DynamicData(nameof(AddComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(AddComponentData), dynamicDataSourceArguments: 100)]
    public void EntityArchetypeId<T>(World world, Entity entity, T component)
    {
        ArchetypeId archetypeId = entity.ArchetypeId;
        world.AddComponent(ref entity, component);
        ArchetypeId expectedArchetypeId = entity.ArchetypeId;
        Assert.AreNotEqual(archetypeId.Id, expectedArchetypeId.Id);
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
    [DynamicData(nameof(SetComponentTwoComponentData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(SetComponentTwoComponentData), dynamicDataSourceArguments: 100)]
    public void RemoveComponent<T>(World world, Entity entity, T component)
    {
        ArchetypeId prevArchetypeId = entity.ArchetypeId;
        world.RemoveComponent<T>(ref entity);
        ArchetypeId currentArchetypeId = entity.ArchetypeId;
        Assert.AreNotEqual(prevArchetypeId, currentArchetypeId);
    }
    [TestMethod]
    [DynamicData(nameof(RemoveEntityData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(RemoveEntityData), dynamicDataSourceArguments: 100)]
    public void RemoveEntity(World world, Entity entity)
    {
        world.RemoveEntity(entity);
        Assert.IsFalse(world.IsValid(entity));
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
