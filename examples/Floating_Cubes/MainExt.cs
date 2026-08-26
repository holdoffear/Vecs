using System;
using System.Diagnostics;
using Godot;
using SimpleECS;
namespace d;

public partial class MainExt : Node3D
{
	World world = World.Create("My World");
	Query query;
	int instances = 10000;
	Mesh Mesh;
	public override void _Ready()
	{
		Mesh = new SphereMesh();
		query = world.CreateQuery();
		// query = new Query();

		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < instances; i++)
		{
			Transform3D transform3D = new Transform3D(Basis.Identity, Vector3.Zero);
			MeshInstance3D meshInstance3D = new MeshInstance3D();
			meshInstance3D.Mesh = Mesh;
			// AddChild(meshInstance3D);
			Rid rid = meshInstance3D.GetInstance();

			Entity entity = world.CreateEntity();
			entity.Set(transform3D);
			entity.Set(rid);

			RenderingServer.InstanceSetScenario(rid, GetWorld3D().Scenario);
			// RenderingServer.InstanceSetBase(rid, Mesh);
			// RenderingServer.InstanceSetTransform(rid, transform3D);
		}
		stopwatch.Stop();
		GD.Print(stopwatch.ElapsedMilliseconds);
		stopwatch.Reset();

		query = query.Has(typeof(Rid), typeof(Transform3D));
	}
	public override void _PhysicsProcess(double delta)
	{
		// Stopwatch stopwatch = new Stopwatch();
		// stopwatch.Start();
		query.Foreach((ref Rid rid, ref Transform3D transform3D) => 
		{
			transform3D.Origin = new Vector3(GD.RandRange(-10, 10), GD.RandRange(-10, 10), GD.RandRange(-10, 10));
			RenderingServer.InstanceSetTransform(rid, transform3D);
		});
		// for (int i = 0; i < 100; i++)
		// {
		// 	Entity entity = world.CreateEntity();
		// 	entity.Set(4);
		// }
		// for (int i = 0; i < instances; i++)
		// {
		// 	Transform3D transform3D = new Transform3D(Basis.Identity, Vector3.Up);
		// 	InstanceRid instance = new InstanceRid(RenderingServer.InstanceCreate());

		// 	Entity entity = world.CreateEntity();
		// 	entity.Set(meshInstance3D);
		// 	entity.Set(transform3D);
		// 	entity.Set(instance);

		// 	RenderingServer.InstanceSetScenario(instance.Rid, GetWorld3D().Scenario);
		//     RenderingServer.InstanceSetBase(instance.Rid, meshInstance3D);
		//     RenderingServer.InstanceSetTransform(instance.Rid, transform3D);
		// }
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
