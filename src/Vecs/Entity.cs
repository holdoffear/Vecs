namespace Vecs
{
    public struct Entity : IEquatable<Entity>
    {
        private long id;
        public long Id {get {return id;} set {id = value;}}
        private ArchetypeId archetypeId;
        public ArchetypeId ArchetypeId {get {return archetypeId;} set {archetypeId = value;} }
        public Entity(long id, ArchetypeId archetypeId)
        {
            this.id = id;
            this.archetypeId = archetypeId;
        }
        public bool Equals(Entity other)
        {
            return Id.Equals(other.Id);
        }
    }
}