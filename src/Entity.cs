namespace Vecs;
// public struct Entity : IEquatable<Entity>
// {
//     public readonly EntityId EntityId;
//     public readonly ArchetypeId ArchetypeId;
//     public readonly int Index = -1;
//     internal Entity(EntityId entityId, ArchetypeId archetypeId, int index)
//     {
//         EntityId = entityId;
//         ArchetypeId = archetypeId;
//         Index = index;
//     }
//     public override bool Equals(object? obj) => obj is Entity entityId && Equals(entityId);
//     public bool Equals(Entity other) => EntityId.Equals(other.EntityId);
//     public static bool operator ==(Entity left, Entity right) => left.Equals(right);
//     public static bool operator !=(Entity left, Entity right) => !left.Equals(right);
//     public override int GetHashCode() => EntityId.GetHashCode();
// }
public readonly record struct Entity(EntityId EntityId, ArchetypeId ArchetypeId, int Index = -1);