namespace Vecs;
public partial class Query
{
    private World World;
    private int ExcludeBits = 0;
    private int WithBits = 0;
    private int GetBits = 0;
    public Query(World world)
    {
        World = world;
    }
}