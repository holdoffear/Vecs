using System;
using System.Collections.Generic;
using System.Linq;

namespace Vecs
{
    public class Query
    {
        private World World;
        private HashSet<Type> withComponents;
        private HashSet<Type> withoutComponents;
        public HashSet<Type> WithComponents {get {return withComponents;}}
        public HashSet<Type> WithoutComponents {get {return withoutComponents;}}
        private HashSet<ArchetypeId> ArchetypeIds;
        public Query(World world)
        {
            this.World = world;
            this.withComponents = new HashSet<Type>();
            this.withoutComponents = new HashSet<Type>();
            this.ArchetypeIds = new HashSet<ArchetypeId>();
        }
        // Doesn't handle non existent archetypes
        public delegate void Operation<T1>(ref T1 componentA);
        public delegate void Operation<T1, T2>(ref T1 componentA, ref T2 componentB);
        public delegate void Operation<T1, T2, T3>(ref T1 componentA, ref T2 componentB, ref T3 componentC);
        public void AddComponent<T>(ref Entity entity, T value)
        {
            ArchetypeId oldArchetypeId = entity.ArchetypeId;
            Type[] oldArchetypeIdTypes = oldArchetypeId.Types.ToArray();
            ArchetypeId newArchetypeId = new ArchetypeId(oldArchetypeIdTypes, typeof(T));
            Entity newEntity = new Entity(entity.Id, newArchetypeId);
            Archetype oldArchetype;
            Archetype newArchetype;

            World.AddEntity(newEntity);

            oldArchetype = World.GetArchetype(oldArchetypeId);
            newArchetype = World.GetArchetype(newArchetypeId);

            for (int i = 0; i < oldArchetypeIdTypes.Length; i++)
            {
                newArchetype.SetComponent(entity,  oldArchetypeIdTypes[i], oldArchetype.GetComponent(entity, oldArchetypeIdTypes[i]));
            }
            newArchetype.SetComponent(entity, value);

            oldArchetype.RemoveEntity(entity);
            entity = newEntity;
        }
        public void RemoveComponent<T>(ref Entity entity)
        {
            ArchetypeId oldArchetypeId = entity.ArchetypeId;
            Type[] oldArchetypeIdTypes = oldArchetypeId.Types.ToArray();
            ArchetypeId newArchetypeId = new ArchetypeId(oldArchetypeIdTypes, typeof(T));
            Entity newEntity = new Entity(entity.Id, newArchetypeId);
            Archetype oldArchetype;
            Archetype newArchetype;

            World.AddEntity(newEntity);

            oldArchetype = World.GetArchetype(oldArchetypeId);
            newArchetype = World.GetArchetype(newArchetypeId);

            for (int i = 0; i < oldArchetypeIdTypes.Length; i++)
            {
                newArchetype.SetComponent(entity,  oldArchetypeIdTypes[i], oldArchetype.GetComponent(entity, oldArchetypeIdTypes[i]));
            }

            oldArchetype.RemoveEntity(entity);
            entity = newEntity;
        }
        public void RemoveEntity(Entity entity)
        {
            World.RemoveEntity(entity);
        }
        public void Clear()
        {
            withComponents = new HashSet<Type>();
            withoutComponents = new HashSet<Type>();
        }
        private void Refresh()
        {
            ArchetypeIds = new HashSet<ArchetypeId>();
            if (WithComponents.Count < 1)
            {
                return;
            }

            List<ArchetypeId> archetypeIds = new List<ArchetypeId>();
            if (World.ArchetypeIds.TryGetValue(WithComponents.ElementAt(0), out archetypeIds) == true)
            {
                ArchetypeIds.UnionWith(archetypeIds);
            }

            for (int i = 1; i < WithComponents.Count; i++)
            {
                if (World.ArchetypeIds.TryGetValue(WithComponents.ElementAt(i), out archetypeIds) == true)
                {
                    for (int j = ArchetypeIds.Count-1; j > -1; j--)
                    {
                        if (archetypeIds.Contains(ArchetypeIds.ElementAt(j)) == false)
                        {
                            ArchetypeIds.Remove(ArchetypeIds.ElementAt(j));
                        }
                    }
                }
                else
                {
                    ArchetypeIds = new HashSet<ArchetypeId>();
                    return;
                }
            }

            for (int i = 0; i < WithoutComponents.Count; i++)
            {
                if (World.ArchetypeIds.TryGetValue(WithoutComponents.ElementAt(i), out archetypeIds) == true)
                {
                    for (int j = ArchetypeIds.Count-1; j > -1; j--)
                    {
                        if (archetypeIds.Contains(ArchetypeIds.ElementAt(j)) == true)
                        {
                            ArchetypeIds.Remove(ArchetypeIds.ElementAt(j));
                        }
                    }
                }
            }
        }
        public Query With(Type[] components)
        {
            WithComponents.UnionWith(components);
            Refresh();
            return this;
        }
        public Query Without(Type[] components)
        {
            WithoutComponents.UnionWith(components);
            Refresh();
            return this;
        }
        private Archetype[] GetArchetypes()
        {
            List<Archetype> archetypes = new List<Archetype>();
            for (int i = 0; i < ArchetypeIds.Count; i++)
            {
                if (World.Archetypes.TryGetValue(ArchetypeIds.ElementAt(i), out Archetype archetype) == true)
                {
                    archetypes.Add(archetype);
                }
            }
            return archetypes.ToArray();
        }
        public void Foreach(in Operation<Entity> operation)
        {
            Archetype[] archetypes = GetArchetypes();
            for (int i = 0; i < archetypes.Length; i++)
            {
                Archetype archetype = archetypes[i];
                Span<Entity> entities = archetype.Entities;
                for (int j = 0; j < archetype.Entities.Length; j++)
                {
                    operation(ref entities[j]);
                }
            }
        }
        public void Foreach<T1>(in Operation<T1> operation)
        {
            Archetype[] archetypes = GetArchetypes();
            for (int i = 0; i < archetypes.Length; i++)
            {
                Archetype archetype = archetypes[i];
                Span<T1> componentA = archetype.GetComponents<T1>();
                for (int j = 0; j < archetype.Entities.Length; j++)
                {
                    operation(ref componentA[j]);
                }
            }
        }
        public void Foreach<T1, T2>(in Operation<T1, T2> operation)
        {
            Archetype[] archetypes = GetArchetypes();
            for (int i = 0; i < archetypes.Length; i++)
            {
                Archetype archetype = archetypes[i];
                Span<T1> componentA = archetype.GetComponents<T1>();
                Span<T2> componentB = archetype.GetComponents<T2>();
                for (int j = 0; j < archetype.Entities.Length; j++)
                {
                    operation(ref componentA[j], ref componentB[j]);
                }
            }
        }
        public void Foreach<T1, T2, T3>(in Operation<T1, T2, T3> operation)
        {
            Archetype[] archetypes = GetArchetypes();
            for (int i = 0; i < archetypes.Length; i++)
            {
                Archetype archetype = archetypes[i];
                Span<T1> componentA = archetype.GetComponents<T1>();
                Span<T2> componentB = archetype.GetComponents<T2>();
                Span<T3> componentC = archetype.GetComponents<T3>();
                for (int j = 0; j < archetype.Entities.Length; j++)
                {
                    operation(ref componentA[j], ref componentB[j], ref componentC[j]);
                }
            }
        }
    }
}