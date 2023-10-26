using System;
using System.Collections.Generic;

namespace Vecs
{
    public class Archetype
    {
        private Entity[] entities;
        public Span<Entity> Entities {get{return CreateSpan(entities, 0, NextIndex);}}
        private ArchetypeId archetypeId;
        public ArchetypeId ArchetypeId {get{return archetypeId;}}
        private int nextIndex;
        public int NextIndex {get => nextIndex;}
        private Dictionary<Type, Array> Components;
        public Archetype(ArchetypeId archetypeId)
        {
            int initialSize = 1000;
            nextIndex = -1;
            this.archetypeId = archetypeId;
            this.entities = new Entity[initialSize];
            this.Components = new Dictionary<Type, Array>();
            foreach (Type key in archetypeId.Types)
            {
                Components[key] = Array.CreateInstance(key, initialSize);
            }
        }
        public void AddEntity(Entity entity)
        {
            //resize
            if(entities.Length-1 <= nextIndex)
            {
                IncreaseCapacity();
            }
            if(nextIndex < 0)
            {
                nextIndex = 0;
            }
            entities[nextIndex] = entity;
            foreach (Type key in Components.Keys)
            {
                Components[key].SetValue(null, nextIndex);
            }
            nextIndex++;
        }
        public static Span<T> CreateSpan<T>(T[] array, int start, int length)
        {
            if(length > -1)
            {
                return new Span<T>(array, start, length);
            }
            return new Span<T>(new T[]{});
        }
        public T? GetComponent<T>(Entity entity)
        {
            int index = Array.IndexOf(entities, entity);
            if (index == -1)
            {
                throw new NotImplementedException();
            }
            return (T?)Components[typeof(T)].GetValue(index);
        }
        public dynamic GetComponent(Entity entity, Type type)
        {
            int index = Array.IndexOf(entities, entity);
            return Components[type].GetValue(index);
        }
        public Span<T> GetComponents<T>()
        {
            Array components = Components[typeof(T)];
            return CreateSpan((T[])components!, 0, NextIndex);
        }
        private void IncreaseCapacity()
        {
            int newSize = entities.Length*2;
            Array.Resize(ref entities, newSize);
            foreach (Type key in Components.Keys)
            {
                Array newArray = Array.CreateInstance(key, newSize);
                Array.Copy(Components[key], newArray, Components[key].Length);  
                Components[key] = newArray;
            }
        }
        public void RemoveEntity(Entity entity)
        {
            int removeIndex = Array.IndexOf(entities, entity);
            if(removeIndex > -1)
            {
                if(nextIndex > 0)
                {
                    SwapIndices(entities, removeIndex, nextIndex);
                    foreach (Type key in Components.Keys)
                    {
                        SwapIndices(Components[key], removeIndex, Components[key].Length-1);
                    }
                }
                nextIndex--;
            }
        }
        public void SetComponent<T>(Entity entity, T value)
        {
            int index = Array.IndexOf(entities, entity);
            Components[typeof(T)].SetValue(value, index);
        }
        public void SetComponent(Entity entity, Type type, dynamic value)
        {
            int index = Array.IndexOf(entities, entity);
            Components[type].SetValue(value, index);
        }
        public static void SwapIndices(Array array, int indexA, int indexB)
        {
            dynamic? temp = array.GetValue(indexA);
            array.SetValue(array.GetValue(indexB), indexA);
            array.SetValue(temp, indexB);
        }
    }

    public struct DefaultArchetype
    {
        
    }
}
