namespace Vecs;
static class ComponentIdGenerator
{
    private static int Id = 0;
    public static int NextId
    {
        get
        {
           return Id++; 
        }
    }
}