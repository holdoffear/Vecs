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
}