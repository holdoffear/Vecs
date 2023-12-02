using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Vecs
{
    public partial struct World
    {
        public delegate void Operation<T1>(ref T1 componentA);
        public delegate void Operation<T1, T2>(ref T1 componentA, ref T2 componentB);
        public delegate void Operation<T1, T2, T3>(ref T1 componentA, ref T2 componentB, ref T3 componentC);
        private ArchetypeId[] GetArchetypeIds(Type[] withComponents, Type[] withoutComponents)
        {
            HashSet<ArchetypeId> queryArchetypeIds = new HashSet<ArchetypeId>();
            if (withComponents.Length > 0)
            {
                if (ArchetypeIds.TryGetValue(withComponents[0], out List<ArchetypeId> initialArchetypeIds) == true)
                {
                    queryArchetypeIds.UnionWith(initialArchetypeIds);
                }
                for (int i = 0; i < withoutComponents.Length; i++)
                {
                    if (ArchetypeIds.TryGetValue(withComponents[i], out List<ArchetypeId> withoutArchetypeIds) == true)
                    {
                        queryArchetypeIds.ExceptWith(withoutArchetypeIds);
                    }
                }
                for (int i = 1; i < withComponents.Length; i++)
                {
                    if (ArchetypeIds.TryGetValue(withComponents[i], out List<ArchetypeId> withArchetypeIds) == true)
                    {
                        queryArchetypeIds.IntersectWith(withArchetypeIds);
                    }
                }
            }
            return queryArchetypeIds.ToArray();
        }
        private Archetype[] GetArchetypes(ArchetypeId[] archetypeIdsArray)
        {
            List<Archetype> archetypes = new List<Archetype>();
            for (int i = 0; i < archetypeIdsArray.Length; i++)
            {
                // archetypes.Add(World.GetArchetype(ArchetypeIds.ElementAt(i)));
                if (Archetypes.TryGetValue(archetypeIdsArray[i], out Archetype archetype) == true)
                {
                    archetypes.Add(archetype);
                }
            }
            return archetypes.ToArray();
        }
        public void Query<T1, T2>(Query query, in Operation<T1, T2> operation)
        {
            ArchetypeId[] queryArchetypeIds = GetArchetypeIds(query.WithComponents.ToArray(), query.WithoutComponents.ToArray());
            Archetype[] archetypes = GetArchetypes(queryArchetypeIds);
            for (int i = 0; i < archetypes.Length; i++)
            {
                Archetype archetype = archetypes[i];
                Span<T1> componentA = CollectionsMarshal.AsSpan(archetype.GetComponents<T1>());
                Span<T2> componentB = CollectionsMarshal.AsSpan(archetype.GetComponents<T2>());
                for (int j = 0; j < componentA.Length; j++)
                {
                    operation(ref componentA[j], ref componentB[j]);
                }
            }
        }
    }
}