namespace Vecs;
static class ComponentIdGenerator
{
    private static int Id = 1;
    public static int NextId
    {
        get
        {
           return Id++; 
        }
    }
}