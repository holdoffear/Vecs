using System;
using System.Collections.Generic;
using System.Linq;

namespace Vecs
{
    public class World
    {
        public Dictionary<ArchetypeId, Archetype> Archetypes;
        public Dictionary<Type, List<ArchetypeId>> ArchetypeIds;
        public World()
        {
            Archetypes = new Dictionary<ArchetypeId, Archetype>(new ArchetypeIdComparer());
            ArchetypeIds = new Dictionary<Type, List<ArchetypeId>>();
        }
        public void AddArchetype(ArchetypeId archetypeId)
        {
            Archetype archetype = new Archetype(archetypeId);
            Archetypes.Add(archetypeId, archetype);
            foreach (Type type in archetypeId.Types)
            {
                if(ArchetypeIds.TryGetValue(type, out List<ArchetypeId>? list) == false)
                {
                    ArchetypeIds.Add(type, new List<ArchetypeId>());
                }
                ArchetypeIds[type].Add(archetypeId);
            }
        }
        public void AddEntity(Entity entity)
        {
            Archetype? archetype;
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
        public Archetype? GetArchetype(ArchetypeId archetypeId)
        {
            if (Archetypes.ContainsKey(archetypeId) == true)
            {
                return Archetypes[archetypeId];
            }
            return null;
        }
        public Archetype[] GetArchetypes(Type type)
        {
            List<Archetype> archetypes = new List<Archetype>();
            if (ArchetypeIds.ContainsKey(type) == true)
            {
                List<ArchetypeId> archetypeIds = ArchetypeIds[type];
                for (int i = 0; i < archetypeIds.Count; i++)
                {
                    archetypes.Add(Archetypes[archetypeIds[i]]);
                }
            }
            return archetypes.ToArray();
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