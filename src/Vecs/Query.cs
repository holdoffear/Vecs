namespace Vecs
{
    public struct Query
    {
        public World World;
        public SortedSet<Type> WithComponents;
        public SortedSet<Type> WithoutComponents;
        //Push to use ArchetypeId instead
        public SortedSet<ArchetypeId> ArchetypeIds;
        public Query(World world)
        {
            this.World = world;
            this.WithComponents = new SortedSet<Type>();
            this.WithoutComponents = new SortedSet<Type>();
            this.ArchetypeIds = new SortedSet<ArchetypeId>();
        }
        public Query(Query query)
        {
            this.World = query.World;
            this.WithComponents = query.WithComponents;
            this.WithoutComponents = query.WithoutComponents;
            this.ArchetypeIds = query.ArchetypeIds;
        }
        // Doesn't handle non existent archetypes
        public delegate void Operation<T1>(ref T1 componentA);
        public delegate void Operation<T1, T2>(ref T1 componentA, ref T2 componentB);
        public delegate void Operation<T1, T2, T3>(ref T1 componentA, ref T2 componentB, ref T3 componentC);
        public Entity AddComponent<T>(ref Entity entity, T value)
        {
            ArchetypeId oldArchetypeId = entity.ArchetypeId;
            Type[] oldArchetypeIdTypes = oldArchetypeId.Types.ToArray();
            ArchetypeId newArchetypeId = new ArchetypeId(oldArchetypeIdTypes, typeof(T));
            Entity newEntity = new Entity(entity.Id, newArchetypeId);

            World.AddEntity(newEntity);

            Archetype oldArchetype = World.GetArchetype(oldArchetypeId);
            Archetype newArchetype = World.GetArchetype(newArchetypeId);

            for (int i = 0; i < oldArchetypeIdTypes.Length; i++)
            {
                newArchetype.SetComponent(entity,  oldArchetypeIdTypes[i], oldArchetype.GetComponent(entity, oldArchetypeIdTypes[i]));
            }
            newArchetype.SetComponent(entity, value);

            oldArchetype.RemoveEntity(entity);
            return newEntity;
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
        public static bool AND(Archetype archetype, Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (archetype.ArchetypeId.Contains(types[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool OR(Archetype archetype, Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (archetype.ArchetypeId.Contains(types[i]) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public void Refresh()
        {
            ArchetypeIds = new SortedSet<ArchetypeId>();
            for (int i = 0; i < WithComponents.Count; i++)
            {
                if (World.ArchetypeIds.TryGetValue(WithComponents.ElementAt(i), out List<ArchetypeId> archetypeIds) == true)
                {
                    ArchetypeIds.UnionWith(archetypeIds);
                }
            }

            // for (int i = 0; i < Archetypes.Count; i++)
            // {
            //     Archetype archetype = Archetypes.ElementAt(i);
            //     if (AND(archetype, withComponents) == false)
            //     {
            //         Archetypes.Remove(archetype);
            //     }
            // }

            // for (int i = 0; i < Archetypes.Count; i++)
            // {
            //     Archetype archetype = Archetypes.ElementAt(i);
            //     if (OR(archetype, withoutComponents) == true)
            //     {
            //         Archetypes.Remove(archetype);
            //     }
            // }
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
                ArchetypeId archetypeId = ArchetypeIds.ElementAt(i);
                Archetype? archetype = World.GetArchetype(archetypeId);
                if(archetype != null)
                {
                    archetypes.Add(archetype);
                }
            }
            return archetypes.ToArray();
        }
    }
}