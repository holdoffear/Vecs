using System;
using System.Diagnostics;
using Godot;
using Vecs;

public partial class Main : Node3D
{
	World world = new World();
	Query query;
	int instances = 10000;
	Rid meshInstance3D;
	public override void _Ready()
	{
		meshInstance3D = new SphereMesh().GetRid();
		query = new Query(world);
		for (int i = 0; i < instances; i++)
		{
			Transform3D transform3D = new Transform3D(Basis.Identity, Vector3.Up);
			InstanceRid instance = new InstanceRid(RenderingServer.InstanceCreate());

			Entity entity = world.CreateEntity();
			query.AddComponent(ref entity, meshInstance3D);
			query.AddComponent(ref entity, transform3D);
			query.AddComponent(ref entity, instance);

			RenderingServer.InstanceSetScenario(instance.Rid, GetWorld3D().Scenario);
            RenderingServer.InstanceSetBase(instance.Rid, meshInstance3D);
            RenderingServer.InstanceSetTransform(instance.Rid, transform3D);
		}
		query.With(new Type[]{typeof(InstanceRid), typeof(Transform3D)});
	}
	public override void _PhysicsProcess(double delta)
	{
		// Stopwatch stopwatch = new Stopwatch();
		// stopwatch.Start();
		query.Foreach((ref InstanceRid instanceRid, ref Transform3D transform3D) => 
		{
			transform3D = transform3D.Translated(GD.RandRange(-1, 1) * new Godot.Vector3(GD.Randf(), GD.Randf(), GD.Randf()));
			RenderingServer.InstanceSetTransform(instanceRid.Rid, transform3D);
		});
		// stopwatch.Stop();
		// GD.Print(stopwatch.ElapsedMilliseconds);
		// stopwatch.Reset();
	}
}

struct InstanceRid : IEquatable<InstanceRid>
{
	public Rid Rid;
	public InstanceRid(Rid rid)
	{
		this.Rid = rid;
	}

    public int CompareTo(object obj)
    {
		return (int)(this.Rid.Id - ((InstanceRid)obj).Rid.Id);
    }


    public bool Equals(InstanceRid other)
    {
        return this.Rid.Equals(other.Rid);
    }
}
