namespace Vecs
{
    public struct Entity
    {
        public ArchetypeId ArchetypeId {get;}
        public Entity(ArchetypeId archetypeId)
        {
            this.ArchetypeId = archetypeId;
        }
    }
}