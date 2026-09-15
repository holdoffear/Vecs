namespace Vecs;
public partial class Query
{
    public void Process<T1>(Operation<T1> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i]);
            }
        }
    }
	public void Process<T1, T2>(Operation<T1, T2> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i]);
            }
        }
    }
	public void Process<T1, T2, T3>(Operation<T1, T2, T3> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4>(Operation<T1, T2, T3, T4> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5>(Operation<T1, T2, T3, T4, T5> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6>(Operation<T1, T2, T3, T4, T5, T6> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7>(Operation<T1, T2, T3, T4, T5, T6, T7> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>(); Span<T7> componentsG = archetype.GetComponentsAsSpan<T7>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i], ref componentsG[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7, T8>(Operation<T1, T2, T3, T4, T5, T6, T7, T8> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>(); Span<T7> componentsG = archetype.GetComponentsAsSpan<T7>(); Span<T8> componentsH = archetype.GetComponentsAsSpan<T8>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i], ref componentsG[i], ref componentsH[i]);
            }
        }
    }
    public void Process<T1>(OperationWithEntity<T1> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i]);
            }
        }
    }
	public void Process<T1, T2>(OperationWithEntity<T1, T2> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i]);
            }
        }
    }
	public void Process<T1, T2, T3>(OperationWithEntity<T1, T2, T3> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4>(OperationWithEntity<T1, T2, T3, T4> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5>(OperationWithEntity<T1, T2, T3, T4, T5> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6>(OperationWithEntity<T1, T2, T3, T4, T5, T6> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7>(OperationWithEntity<T1, T2, T3, T4, T5, T6, T7> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>(); Span<T7> componentsG = archetype.GetComponentsAsSpan<T7>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i], ref componentsG[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7, T8>(OperationWithEntity<T1, T2, T3, T4, T5, T6, T7, T8> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>(); Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>(); Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>(); Span<T4> componentsD = archetype.GetComponentsAsSpan<T4>(); Span<T5> componentsE = archetype.GetComponentsAsSpan<T5>(); Span<T6> componentsF = archetype.GetComponentsAsSpan<T6>(); Span<T7> componentsG = archetype.GetComponentsAsSpan<T7>(); Span<T8> componentsH = archetype.GetComponentsAsSpan<T8>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(entities[i], ref componentsA[i], ref componentsB[i], ref componentsC[i], ref componentsD[i], ref componentsE[i], ref componentsF[i], ref componentsG[i], ref componentsH[i]);
            }
        }
    }
    public void Process<T1>(OperationWithOnlyEntity<T1> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2>(OperationWithOnlyEntity<T1, T2> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3>(OperationWithOnlyEntity<T1, T2, T3> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4>(OperationWithOnlyEntity<T1, T2, T3, T4> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5>(OperationWithOnlyEntity<T1, T2, T3, T4, T5> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6>(OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7>(OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6, T7> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
	public void Process<T1, T2, T3, T4, T5, T6, T7, T8>(OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6, T7, T8> operation)
    {
        ArchetypeId GetId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId());
        Archetype[] archetypes = GetArchetypes(GetId);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            for (int i = 0; i < entities.Length; i++)
            {
                operation(entities[i]);
            }
        }
    }
}