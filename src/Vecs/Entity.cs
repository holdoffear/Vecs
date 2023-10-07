namespace Vecs
{
    public struct Entity : IEquatable<Entity>
    {
        public ArchetypeId ArchetypeId {get;}
        public Entity(ArchetypeId archetypeId)
        {
            this.ArchetypeId = archetypeId;
        }
        public bool Equals(Entity other)
        {
            return ArchetypeId.Equals(other.ArchetypeId);
        }
    }
}