using System;
using System.Collections.Generic;
using System.Linq;

// Implement a dictionary of arrays instead
namespace Vecs
{
    public struct Archetype
    {
        private ArchetypeId archetypeId;
        public ArchetypeId ArchetypeId {get {return archetypeId;}}
        private List<Entity> entities;
        public List<Entity> Entities {get{return entities;}}
        private Dictionary<Type, ArchetypeData> archetypeData;
        public Dictionary<Type, ArchetypeData> ArchetypeData {get {return archetypeData;}}
        public Archetype(ArchetypeId archetypeId)
        {
            this.archetypeId = new ArchetypeId(archetypeId.Types.ToArray());
            entities = new List<Entity>();
            archetypeData = new Dictionary<Type, ArchetypeData>();
            foreach (Type type in archetypeId.Types)
            {
                archetypeData[type] = Activator.CreateInstance(typeof(ArchetypeData<>).MakeGenericType(type)) as ArchetypeData;
            }
        }
        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
            foreach (Type type in archetypeData.Keys)
            {
                archetypeData[type].AddDefault();
            }
        }
        // public void AddEntity(Entity entity)
        // {
        //     entities.Add(entity);
        // }
        // public void AddComponent<T>(T Value)
        // {
        //     ((ArchetypeData<T>)archetypeData[typeof(T)]).List.Add(Value);
        // }
        public T GetComponent<T>(Entity entity)
        {
            int index = entities.IndexOf(entity);
            return ((ArchetypeData<T>)archetypeData[typeof(T)]).List[index];
        }
        public List<T> GetComponents<T>()
        {
            return ((ArchetypeData<T>)archetypeData[typeof(T)]).List;
        }
        public void RemoveEntity(Entity entity)
        {
            int index = entities.IndexOf(entity);
            int lastIndex = entities.Count > 1 ? entities.Count-1 : 0;
            foreach (Type key in ArchetypeData.Keys)
            {
                ArchetypeData[key].RemoveAt(index);
            }
            entities[index] = entities[lastIndex];
            entities.RemoveAt(lastIndex);
        }
        public void SetComponent<T>(Entity entity, T value)
        {
            int index = entities.IndexOf(entity);
            ((ArchetypeData<T>)archetypeData[typeof(T)]).List[index] = value;
        }
    }
    public interface ArchetypeData
    {
        void Add(object val);
        void AddDefault();
        void RemoveAt(int index);
        object GetComponent(int index);
        dynamic GetList();
    }
    public struct ArchetypeData<T> : ArchetypeData
    {
        public List<T> List;
        public ArchetypeData()
        {
            this.List = new List<T>();
        }

        public void Add(object val)
        {
            List.Add((T)val);
        }

        public void AddDefault()
        {
            List.Add(default(T));
        }

        public object GetComponent(int index)
        {
            return List[index];
        }
        public dynamic GetList()
        {
            return List;
        }
        public void RemoveAt(int index)
        {
            int lastIndex = List.Count > 1 ? List.Count-1 : 0;
            Console.WriteLine(index);
            Console.WriteLine(lastIndex);
            List[index] = List[lastIndex];
            List.RemoveAt(lastIndex);
        }
    }
    public interface ArchetypeHandler
    {
        // void AddComponent(Archetype archetype, object component);
        object GetComponent(Archetype archetype, Entity entity);
        void SetComponent(Archetype archetype, Entity entity, object component);
        void Transfer(Entity entity, Archetype oldArchetype, Archetype newArchetype);
    }
    public struct ArchetypeHandler<T> : ArchetypeHandler
    {
        // public void AddComponent(Archetype archetype, object component)
        // {
        //     archetype.AddComponent((T)component);
        // }
        public object GetComponent(Archetype archetype, Entity entity)
        {
            return archetype.GetComponent<T>(entity);
        }
        public void SetComponent(Archetype archetype, Entity entity, object component)
        {
            archetype.SetComponent(entity, (T)component);
        }
        public void Transfer(Entity entity, Archetype sourceArchetype, Archetype targetArchetype)
        {
            targetArchetype.SetComponent(entity, sourceArchetype.GetComponent<T>(entity));
        }
    }
}
