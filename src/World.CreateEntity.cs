namespace Vecs;
public partial class World
{
    public Entity CreateEntity<T1>(T1 componentA)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA);
        return entity;
    }
	public Entity CreateEntity<T1, T2>(T1 componentA, T2 componentB)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3>(T1 componentA, T2 componentB, T3 componentC)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4>(T1 componentA, T2 componentB, T3 componentC, T4 componentD)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU, T22 componentV)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId() | Component<T22>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size), Component<T22>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU); archetypeBuffer.Archetype.Set(entity, componentV);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU, T22 componentV, T23 componentW)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId() | Component<T22>.GetComponentId() | Component<T23>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size), Component<T22>.GetComponentData(size), Component<T23>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU); archetypeBuffer.Archetype.Set(entity, componentV); archetypeBuffer.Archetype.Set(entity, componentW);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU, T22 componentV, T23 componentW, T24 componentX)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId() | Component<T22>.GetComponentId() | Component<T23>.GetComponentId() | Component<T24>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size), Component<T22>.GetComponentData(size), Component<T23>.GetComponentData(size), Component<T24>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU); archetypeBuffer.Archetype.Set(entity, componentV); archetypeBuffer.Archetype.Set(entity, componentW); archetypeBuffer.Archetype.Set(entity, componentX);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU, T22 componentV, T23 componentW, T24 componentX, T25 componentY)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId() | Component<T22>.GetComponentId() | Component<T23>.GetComponentId() | Component<T24>.GetComponentId() | Component<T25>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size), Component<T22>.GetComponentData(size), Component<T23>.GetComponentData(size), Component<T24>.GetComponentData(size), Component<T25>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU); archetypeBuffer.Archetype.Set(entity, componentV); archetypeBuffer.Archetype.Set(entity, componentW); archetypeBuffer.Archetype.Set(entity, componentX); archetypeBuffer.Archetype.Set(entity, componentY);
        return entity;
    }
	public Entity CreateEntity<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(T1 componentA, T2 componentB, T3 componentC, T4 componentD, T5 componentE, T6 componentF, T7 componentG, T8 componentH, T9 componentI, T10 componentJ, T11 componentK, T12 componentL, T13 componentM, T14 componentN, T15 componentO, T16 componentP, T17 componentQ, T18 componentR, T19 componentS, T20 componentT, T21 componentU, T22 componentV, T23 componentW, T24 componentX, T25 componentY, T26 componentZ)
    {
        ArchetypeId archetypeId = new(Component<T1>.GetComponentId() | Component<T2>.GetComponentId() | Component<T3>.GetComponentId() | Component<T4>.GetComponentId() | Component<T5>.GetComponentId() | Component<T6>.GetComponentId() | Component<T7>.GetComponentId() | Component<T8>.GetComponentId() | Component<T9>.GetComponentId() | Component<T10>.GetComponentId() | Component<T11>.GetComponentId() | Component<T12>.GetComponentId() | Component<T13>.GetComponentId() | Component<T14>.GetComponentId() | Component<T15>.GetComponentId() | Component<T16>.GetComponentId() | Component<T17>.GetComponentId() | Component<T18>.GetComponentId() | Component<T19>.GetComponentId() | Component<T20>.GetComponentId() | Component<T21>.GetComponentId() | Component<T22>.GetComponentId() | Component<T23>.GetComponentId() | Component<T24>.GetComponentId() | Component<T25>.GetComponentId() | Component<T26>.GetComponentId());
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            int size = ArchetypeEntityCount;
            ComponentData[] components = [Component<T1>.GetComponentData(size), Component<T2>.GetComponentData(size), Component<T3>.GetComponentData(size), Component<T4>.GetComponentData(size), Component<T5>.GetComponentData(size), Component<T6>.GetComponentData(size), Component<T7>.GetComponentData(size), Component<T8>.GetComponentData(size), Component<T9>.GetComponentData(size), Component<T10>.GetComponentData(size), Component<T11>.GetComponentData(size), Component<T12>.GetComponentData(size), Component<T13>.GetComponentData(size), Component<T14>.GetComponentData(size), Component<T15>.GetComponentData(size), Component<T16>.GetComponentData(size), Component<T17>.GetComponentData(size), Component<T18>.GetComponentData(size), Component<T19>.GetComponentData(size), Component<T20>.GetComponentData(size), Component<T21>.GetComponentData(size), Component<T22>.GetComponentData(size), Component<T23>.GetComponentData(size), Component<T24>.GetComponentData(size), Component<T25>.GetComponentData(size), Component<T26>.GetComponentData(size)];
            archetypeBuffer = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetypeBuffer.Archetype.CreateEntity();
        archetypeBuffer.Archetype.Set(entity, componentA); archetypeBuffer.Archetype.Set(entity, componentB); archetypeBuffer.Archetype.Set(entity, componentC); archetypeBuffer.Archetype.Set(entity, componentD); archetypeBuffer.Archetype.Set(entity, componentE); archetypeBuffer.Archetype.Set(entity, componentF); archetypeBuffer.Archetype.Set(entity, componentG); archetypeBuffer.Archetype.Set(entity, componentH); archetypeBuffer.Archetype.Set(entity, componentI); archetypeBuffer.Archetype.Set(entity, componentJ); archetypeBuffer.Archetype.Set(entity, componentK); archetypeBuffer.Archetype.Set(entity, componentL); archetypeBuffer.Archetype.Set(entity, componentM); archetypeBuffer.Archetype.Set(entity, componentN); archetypeBuffer.Archetype.Set(entity, componentO); archetypeBuffer.Archetype.Set(entity, componentP); archetypeBuffer.Archetype.Set(entity, componentQ); archetypeBuffer.Archetype.Set(entity, componentR); archetypeBuffer.Archetype.Set(entity, componentS); archetypeBuffer.Archetype.Set(entity, componentT); archetypeBuffer.Archetype.Set(entity, componentU); archetypeBuffer.Archetype.Set(entity, componentV); archetypeBuffer.Archetype.Set(entity, componentW); archetypeBuffer.Archetype.Set(entity, componentX); archetypeBuffer.Archetype.Set(entity, componentY); archetypeBuffer.Archetype.Set(entity, componentZ);
        return entity;
    }
}