namespace Vecs;
static class IdGenerator
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