using System;
using System.Collections.Generic;
using System.Linq;

namespace Vecs
{
    public struct World
    {
        private Dictionary<ArchetypeId, Archetype> archetypes;
        private Dictionary<Type, List<ArchetypeId>> archetypeIds;
        public Dictionary<ArchetypeId, Archetype> Archetypes{get {return archetypes;}}
        public Dictionary<Type, List<ArchetypeId>> ArchetypeIds {get {return archetypeIds;}}
        public World()
        {
            archetypes = new Dictionary<ArchetypeId, Archetype>(new ArchetypeIdComparer());
            archetypeIds = new Dictionary<Type, List<ArchetypeId>>();
        }
        public void AddArchetype(ArchetypeId archetypeId)
        {
            Archetypes.Add(archetypeId, new Archetype(archetypeId));

            foreach (Type type in archetypeId.Types)
            {
                if(ArchetypeIds.TryGetValue(type, out List<ArchetypeId> list) == false)
                {
                    ArchetypeIds.Add(type, new List<ArchetypeId>());
                }
                ArchetypeIds[type].Add(archetypeId);
            }
        }
        public void AddComponentToEntity<T>(ref Entity entity, T value)
        {
            Archetype currentArchetype;
            Archetype newArchetype;
            Entity newEntity = new Entity(entity.Id, new ArchetypeId(entity.ArchetypeId.Types.ToArray(), typeof(T)));

            currentArchetype = archetypes[entity.ArchetypeId];
            // AddEntity(newEntity);
            // newArchetype = Archetypes[newEntity.ArchetypeId];
            if (archetypes.TryGetValue(newEntity.ArchetypeId, out newArchetype) == false)
            {
                AddArchetype(newEntity.ArchetypeId);
                newArchetype = Archetypes[newEntity.ArchetypeId];
            }
            newArchetype.AddEntity(newEntity);

            foreach (Type type in currentArchetype.ArchetypeId.Types)
            {
                ArchetypeHandler handler = Activator.CreateInstance(typeof(ArchetypeHandler<>).MakeGenericType(type)) as ArchetypeHandler;
                handler.Transfer(entity, currentArchetype, newArchetype);
            }
            newArchetype.SetComponent(entity, value);
            currentArchetype.RemoveEntity(entity);
            entity = newEntity;
        }
        public void AddEntity(Entity entity)
        {
            Archetype archetype;
            if(Archetypes.TryGetValue(entity.ArchetypeId, out archetype) == false)
            {
                AddArchetype(entity.ArchetypeId);
                archetype = Archetypes[entity.ArchetypeId];
            }
            archetype.AddEntity(entity);
        }
        public Entity CreateEntity()
        {
            Entity entity = new Entity(IdGenerator.Guid);
            AddEntity(entity);
            return entity;
        }
        public Query CreateQuery()
        {
            return new Query(this);
        }
        public Archetype GetArchetype(ArchetypeId archetypeId)
        {
            return Archetypes[archetypeId];
        }
        public Archetype[] GetArchetypes(Type type)
        {
            List<ArchetypeId> archetypeIds = ArchetypeIds[type];
            Archetype[] archetypes = new Archetype[archetypeIds.Count];
            for (int i = 0; i < archetypes.Length; i++)
            {
                archetypes[i] = Archetypes[archetypeIds[i]];
            }
            return archetypes;
        }
        public Archetype[] GetArchetypes()
        {
            Archetype[] archetypes = new Archetype[Archetypes.Count];
            int index = 0;
            foreach (var key in Archetypes.Keys)
            {
                archetypes[index] = Archetypes[key];
                index += 1;
            }
            return archetypes;
        }
        public void RemoveArchetype(ArchetypeId archetypeId)
        {
            Archetypes.Remove(archetypeId);
            SortedSet<Type> types = archetypeId.Types;
            for (int i = 0; i < types.Count; i++)
            {
                ArchetypeIds[types.ElementAt(i)].Remove(archetypeId);
            }
        }
        public void RemoveEntity(Entity entity)
        {
            Archetypes[entity.ArchetypeId].RemoveEntity(entity);
        }
    }
}