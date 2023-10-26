using System.Diagnostics.CodeAnalysis;

namespace Vecs
{
    public struct Entity : IEquatable<Entity>
    {
        private long id;
        public long Id {get {return id;} set {id = value;}}
        private ArchetypeId archetypeId;
        public ArchetypeId ArchetypeId {get {return archetypeId;} set {archetypeId = value;} }
        public Entity(long id)
        {
            this.id = id;
            this.archetypeId = new ArchetypeId();
        }
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
    public class EntityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity x, Entity y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Entity obj)
        {
            return obj.Id.GetHashCode();
        }
    }

}