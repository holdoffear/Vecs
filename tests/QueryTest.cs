namespace Vecs.Tests;
[TestClass]
public class QueryTest
{
    public static IEnumerable<(World world, Entity entity, int num)> CreateQueryData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i);
            yield return (world, entity, count-i);
        }
    }
    public static IEnumerable<(World world, Entity entity, int elementA, char elementB)> CreateQueryTwoComponentsData(int count)
    {
        World world = new(count);
        for (int i = 0; i < count; i++)
        {
            world.CreateEntity(i, 1.0d);
        }
        for (int i = 0; i < count; i++)
        {
            Entity entity = world.CreateEntity(i, 'c');
            yield return (world, entity, i, 'c');
        }
    }
    [TestMethod]
    [DynamicData(nameof(CreateQueryData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(CreateQueryData), dynamicDataSourceArguments: 100)]
    public void CreateQuery<T>(World world, Entity entity, T num)
    {
        Query query = world.CreateQuery();
        query.Get<T>();
        query.Foreach((ref T component) =>
        {
            component = num;
        });
        T value = world.GetComponent<T>(entity);
        Assert.AreEqual(num, value);
    }
    [TestMethod]
    [DynamicData(nameof(CreateQueryTwoComponentsData), dynamicDataSourceArguments: 1)]
    [DynamicData(nameof(CreateQueryTwoComponentsData), dynamicDataSourceArguments: 100)]
    public void CreateQuery<T1, T2>(World world, Entity entity, T1 elementA, T2 elementB)
    {
        Query query = world.CreateQuery();
        query.Get<T1, T2>();
        query.Foreach((ref T1 componentA, ref T2 componentB) =>
        {
            componentA = elementA;
            componentB = elementB;
        });
        T1 valueA = world.GetComponent<T1>(entity);
        T2 valueB = world.GetComponent<T2>(entity);
        Assert.AreEqual(elementA, valueA);
    }
}