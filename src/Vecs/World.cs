namespace Vecs
{
    public class World
    {
        private Dictionary<ArchetypeId, Archetype> Archetypes;
        private Dictionary<Type, List<ArchetypeId>> ArchetypeIds;
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
        public Archetype GetArchetype(ArchetypeId archetypeId)
        {
            return Archetypes[archetypeId];
        }
        public Archetype[] GetArchetypes(Type type)
        {
            List<ArchetypeId> archetypeIds = ArchetypeIds[type];
            Archetype[] archetypes = new Archetype[archetypeIds.Count];
            for (int i = 0; i < archetypeIds.Count; i++)
            {
                archetypes[i] = Archetypes[archetypeIds[i]];
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