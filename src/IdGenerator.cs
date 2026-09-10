namespace Vecs;
static internal class IdGenerator
{
    private static int Id = 1;
    public static int NextId
    {
        get
        {
           return Id++;
        }
    }
    public static EntityId CreateEntityId() => new(NextId);
}